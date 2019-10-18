using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsleGenerator : MonoBehaviour
{
    void Start()
    {
        float isleLength = StoreGenerator.getSingleton().lengthOfIsles;
        float currentIsleLength = 0;
        GameObject shelfGeneratorPrefab = StoreGenerator.getSingleton().shelfGeneratorPrefab;

        //TODO: make our decision on what isles are populated with here
        GameObject[] availableShelves = StoreGenerator.getSingleton().shelfPrefabs;
        //TODO: determine shelf lengths 
        float shelfLength = 2.0f;// TODO: just pull this out of the prefabs collider and return it here.

        while(currentIsleLength<isleLength)
        {
            GameObject shelf = Instantiate(shelfGeneratorPrefab, this.gameObject.transform, false);
            shelf.transform.localPosition = new Vector3(0, 0, (shelfLength / 2.0f) + currentIsleLength);
            currentIsleLength += shelfLength * 1.01f;
        }
    }
}
