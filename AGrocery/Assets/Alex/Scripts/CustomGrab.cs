using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This script should be put on two different 'hands' in the hierarchy. It allows someone to teleport an object to their hand from a distance using an oculus touch controller.
/// Objects to be grabbed need a collider, a rigidbody, be set to a specific layer, and share the same tag as the empty transform used to designate the snap-to point.
/// Each hand needs to be designated as a right or left controller respectively. Place the opposite hand as the otherHandObj.
/// </summary>

public class CustomGrab : MonoBehaviour
{
    // How fast objects fly towards the hand
    public float grabSpeed = 10f;

    // Does the object teleport to hand or move through space to it
    public bool teleport = false;

    // Grabbed object is flying to hand
    private bool isFlying = false;

    // Raycast Origin
    public GameObject rayCastPosition;

    // The other hand
    public GameObject otherHandObj;
    private CustomGrab otherHand;

    // Controller
    public OVRInput.Controller controller;

    // Snap Positions
    public Transform[] snapPositions;
    private Transform snap;

    private bool itemInHand = false;

    // Item to interact with
    private GameObject itemInFocus;
    public GameObject grabbedItem;
    private Rigidbody grabbedItemRigidbody;

    private Animator handAnimator;

    // LineRenderer
    public LineRenderer lineRenderer;
    private float lineWidth = 0.01f;
    // Designates the distance an object can be grabbed from
    public float grabMaxDistance = 2f;
    private Vector3[] initLaserPositions;

    // Start is called before the first frame update
    void Start()
    {
        initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        lineRenderer = GetComponent<LineRenderer>();
        otherHand = otherHandObj.GetComponent<CustomGrab>();
        handAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        RenderLine();
        if (isFlying == false)
        {
            GrabItem();
        }        
        DropItem();
        if (snap != null && isFlying)
        {
            if (grabbedItem.transform.position != snap.transform.position)
            {
                moveObj();
            }
            else
            {
                snap = null;
                isFlying = false;
            }
        }
    }

    private void DropItem()
    {
        if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, controller) && itemInHand == true)
        {
            itemInHand = false;
            //handAnimator.SetBool("GrabItem", false);

            if (grabbedItem.name.Contains("Loaded") == false)
            {
                grabbedItem.transform.parent = null;
                grabbedItemRigidbody.isKinematic = false;
                grabbedItemRigidbody.useGravity = true;
            }
            grabbedItem = null;
        }
    }

    private void GrabItem()
    {
        // Debugging
        if (itemInFocus != null)
        {
            Debug.Log("itemInFocus: " + itemInFocus.name);
        }
        else
        {
            Debug.Log("itemInFocus: null");
        }

        // Grabs the object set to itemInFocus when the player press the Hand Trigger button on a controller
        if (itemInHand == false && OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, controller) && itemInFocus != null && otherHand.grabbedItem != itemInFocus)
        {
            Debug.Log("Attempting to Grab Item!");
            grabbedItem = itemInFocus;
            itemInHand = true;

            // Get snap position and place

            // compares the tag of the object picked up with the snap position to find the correct one in case of multiple snap positions
            // Requires the snap transform and the object to snap to have the same tag
            snap = snapPositions.Where(x => x.CompareTag(grabbedItem.tag)).FirstOrDefault();

            if (snap != null)
            {
                Debug.Log("snap: Not null");
                // The object grabbed is parented to the empty snap transform in the hand                              
                grabbedItem.transform.parent = snap.transform;

                // If set to true, the object will teleport to the hand's designated snap transform
                // If set to false, the object will fly to it at grab speed
                if (teleport == true)
                {
                    grabbedItem.transform.position = snap.position;
                    grabbedItem.transform.rotation = snap.rotation;
                    grabbedItemRigidbody = grabbedItem.GetComponent<Rigidbody>();
                    grabbedItemRigidbody.useGravity = false;
                    grabbedItemRigidbody.isKinematic = true;
                    // LineRenderer is turned off for a hand holding something, but the other hand is free to grab a second object  
                    lineRenderer.enabled = false;
                }
                else
                {
                    Debug.Log("Teleport is off!");
                    grabbedItem.transform.rotation = snap.rotation;
                    grabbedItemRigidbody = grabbedItem.GetComponent<Rigidbody>();
                    grabbedItemRigidbody.useGravity = false;
                    grabbedItemRigidbody.isKinematic = true;                    
                    // LineRenderer is turned off for a hand holding something, but the other hand is free to grab a second object  
                    lineRenderer.enabled = false;
                    isFlying = true;
                }
            }
            else
            {
                Debug.Log("snap: null");
            }
        }
    }

    private void moveObj()
    {
        Debug.Log("Flying to hand!");
        grabbedItem.transform.position = Vector3.MoveTowards(grabbedItem.transform.position, snap.position, grabSpeed * Time.deltaTime);
    }

    private void RenderLine()
    {
        if (grabbedItem == null)
        {
            // Designates layer 9 as the grabbable layer
            int layerMask = 1 << 9;

            RaycastHit hit;

            // Does the ray intersect any object excluding the player layer
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, grabMaxDistance, layerMask))
            {
                Debug.Log("Ray is hitting an object!");
                lineRenderer.enabled = true;
                lineRenderer.SetPositions(initLaserPositions);
                lineRenderer.startWidth = lineWidth;
                lineRenderer.endWidth = lineWidth;
                RenderLine(rayCastPosition.transform.position, transform.TransformDirection(Vector3.forward), grabMaxDistance);

                // Object that triggers the ray is set as itemInFocus
                if (itemInFocus == null)
                {
                    Debug.Log("itemInFocus shouldn't be null!");
                    itemInFocus = hit.collider.gameObject;
                }
            }
            else
            {
                lineRenderer.enabled = false;
                itemInFocus = null;
            }
        }
    }

    void RenderLine(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit raycastHit;
        Vector3 endPosition = targetPosition + (length * direction);

        if (Physics.Raycast(ray, out raycastHit, length))
        {
            endPosition = raycastHit.point;
        }

        lineRenderer.SetPosition(0, targetPosition);
        lineRenderer.SetPosition(1, endPosition);
    }
}
