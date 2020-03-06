using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class IsleAnchor : MonoBehaviour
{
    public float isleLength = 0;
    public enum ISLEORIENTATION { X, Y };
    public ISLEORIENTATION isleOrientation = ISLEORIENTATION.X;

    public ProductData.CATAGORY[] leftIsleProducts = null;
    public ProductData.CATAGORY[] rightIsleProducts = null;

    void Start()
    {

    }

    private void OnDrawGizmos()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        if (isleOrientation == ISLEORIENTATION.Y)
        {
            Gizmos.DrawCube(transform.position + (Vector3.forward * isleLength / 2.0f), new Vector3(1, 1, isleLength));
        }
        else
        {
            Gizmos.DrawCube(transform.position + (Vector3.right * isleLength / 2.0f), new Vector3(isleLength, 1, 1));
        }

        
    }

    
}
