using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfGenerator : MonoBehaviour
{
    public int numberOfShelves = 2;
    public float heightBetweenShelves = 0;
    public Vector3 shelfDimensions = Vector3.zero;
    public float shelfBaseHeightOffset = 0.1f;// this depends on the geometery of the individual shelf prefab.
    public float shelf1Width = 1;
    public float shelf1Length = 1;

    public ProductData.CATAGORY[] shelfCatagories = null;

    // Start is called before the first frame update
    void Start()
    {

        //TODO figure out what items go on the shelves here.
        //TODO make it so we can grab all the needed data from the product prefab.
        //TODO get their widths, heights, prefab, all that fun stuff.
        //TODO products may be different between each side of the shelf, or uniform in the case of things like a bin of potatos.
        //TODO figure out if the shelf has inclination like in the case of fruit/veggie trays.

        //temp code
        GameObject product = StoreGenerator.getSingleton().productPrefabs[0];
        ProductData productData = product.GetComponent<ProductData>();
        Vector3 itemDimensions = productData.dimensions;
       
        
        float shelf1CurWidth = 0;
        float shelf1CurLength = 0;
        for(int i = 0; i < numberOfShelves; i++)
        {
            shelf1CurWidth = productData.dimensions.x;
            while(shelf1CurWidth<shelf1Width - productData.dimensions.x)
            {
                shelf1CurLength = productData.dimensions.y;
                while(shelf1CurLength<shelf1Length-productData.dimensions.y)
                {
                    GameObject iProduct = Instantiate(product, this.gameObject.transform);
                    iProduct.transform.localPosition = productData.positioningOffset + new Vector3(shelf1CurWidth, shelfBaseHeightOffset + (heightBetweenShelves * ((float)i)), shelf1CurLength);
                    shelf1CurLength += productData.dimensions.z;
                    //test code iProduct.name = "" + i;
                }
                shelf1CurWidth += productData.dimensions.x;
            }
            
        }


    }

}
