using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyData : MonoBehaviour
{
    public Vector3 startPos;

    public enum CATEGORY {ONEDOLLAR, FIVEDOLLAR, TENDOLLAR, TWENTYDOLLAR, PENNY, NICKEL, DIME, QUARTER, MONEY}
    public Vector3 dimensions = Vector3.zero;
    public Vector3 positioningOffset = new Vector3(0, 0.5f, 0);
    public CATEGORY category = CATEGORY.MONEY;
    public float value = 0;

    // Start is called before the first frame update
    void Start()
    {
       startPos = this.transform.position; 
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if we don't have an RB then instantiate one for this object and then handle the collision normally.
        //only do that IF it is the player or cart colliding with it.
        
    }


}
