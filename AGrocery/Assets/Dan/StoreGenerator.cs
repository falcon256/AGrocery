using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGenerator : MonoBehaviour
{
    //public uint numberOfIsles = 2;//depricated
    public GameObject[] isleAnchors = null;
    public float lengthOfIsles = 50;
    public float widthOfIsles = 10; // the width of the isles from center of shelves
    public Vector3 startLocation = Vector3.zero;
    public GameObject isleGeneratorPrefab = null;
    public GameObject shelfGeneratorPrefab = null;
    public GameObject[] shelfPrefabs = null;
    public GameObject[] productPrefabs = null;
    private static StoreGenerator storeGeneratorSingleton = null;

    void Start()
    {
        if (storeGeneratorSingleton == null)
            storeGeneratorSingleton = this;

        for(int i = 0; i < isleAnchors.Length; i++)
        {
            GameObject newIsle = Instantiate(isleGeneratorPrefab, isleAnchors[i].transform.position, isleAnchors[i].transform.rotation);
            
            IsleGenerator generator = newIsle.GetComponent<IsleGenerator>();
            generator.myAnchor = isleAnchors[i].GetComponent<IsleAnchor>();
        }
    }

    public static StoreGenerator getSingleton()
    {
        return storeGeneratorSingleton;
    }

    public static void clearSingleton()
    {
        Destroy(storeGeneratorSingleton);
        storeGeneratorSingleton = null;     
    }

    public GameObject[] getListOfProductPrefabsByCatagory(ProductData.CATEGORY category)
    {
        List<GameObject> list = new List<GameObject>();
        for(int i = 0; i < productPrefabs.Length; i++)
        {
            ProductData pd = productPrefabs[i].GetComponent<ProductData>();
            if(pd==null)
            {
                Debug.LogError("A product prefab is missing a product data component.");
                return null;
            }
            if (pd.category == category)
                list.Add(productPrefabs[i]);
        }
        return list.ToArray();
    }
    //some have a middle wall with asymetrical occupation.
    //end caps.

}
