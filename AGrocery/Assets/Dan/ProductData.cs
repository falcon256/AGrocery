using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductData : MonoBehaviour
{
    public enum CATAGORY {SNACKS, DAIRY, FRUITS, VEGETABLES, DRYGOODS, MEAT, FROZENGOODS, HYGIENE, BAKERY, COFFEE, OTHER} //TODO
    public Vector3 dimensions = Vector3.zero;
    public Vector3 positioningOffset = new Vector3(0, 0.5f, 0);
    public CATAGORY catagory = CATAGORY.OTHER;
    public float price = 0;
    public float density = 1.0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        //if we don't have an RB then instantiate one for this object and then handle the collision normally.
        //only do that IF it is the player or cart colliding with it.
        
    }


}
