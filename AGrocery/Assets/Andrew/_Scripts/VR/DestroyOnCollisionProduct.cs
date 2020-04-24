using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionProduct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collidedProduct)
    {
        if (collidedProduct.gameObject.tag == "Product")
        {
            if (collidedProduct.GetComponent<ProductData>().hasBeenScanned == true)
            {
                Destroy(collidedProduct.gameObject);
            }

        }
    }
}
