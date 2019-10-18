using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGenerator : MonoBehaviour
{
    public uint numberOfIsles = 2;
    public float lengthOfIsles = 50;
    public float widthOfIsles = 10; // the width of the isles from center of shelves
    public Vector3 startLocation = Vector3.zero;
    public GameObject isleGeneratorPrefab = null;
    public GameObject shelfGeneratorPrefab = null;
    public GameObject[] shelfPrefabs = null;
    public GameObject[] productPrefabs = null;
    public ProductRequirement[] requiredProducts = null; // START HERE
    private static StoreGenerator storeGeneratorSingleton = null;

    void Start()
    {
        if (storeGeneratorSingleton == null)
            storeGeneratorSingleton = this;
        for (int isl = 0; isl < numberOfIsles; isl++)
        {
            GameObject newIsle = Instantiate(isleGeneratorPrefab, new Vector3(startLocation.x + (widthOfIsles * isl), startLocation.y, startLocation.z), Quaternion.identity);
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

    //some have a middle wall with asymetrical occupation.
    //end caps.

}
