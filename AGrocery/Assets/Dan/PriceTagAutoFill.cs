using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceTagAutoFill : MonoBehaviour
{
    public TextMeshProUGUI text = null;
    private ProductData myNearestProduct = null;
    private int waitToPopulate = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitToPopulate>0)
        {
            waitToPopulate--;
            return;
        }
        if (!myNearestProduct)
        {
            ProductData[] allProducts = (ProductData[])FindObjectsOfType(typeof(ProductData));
            float nearestDist = 1000000.0f;
            GameObject nearestObject = null;
            for(int i = 0; i < allProducts.Length; i++)
            {
                GameObject newObj = allProducts[i].gameObject;
                float dist = Vector3.Distance(newObj.transform.position,this.transform.position);
                if(dist < nearestDist)
                {
                    nearestDist = dist;
                    nearestObject = newObj;
                }
            }
            if(nearestDist<1000000.0f)
            {
                myNearestProduct = nearestObject.GetComponent<ProductData>();
                text.text = myNearestProduct.price.ToString("c");
            }
        }
    }
}
