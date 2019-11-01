using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsleGenerator : MonoBehaviour
{
    public IsleAnchor myAnchor = null;
    
    void Start()
    {
        if(myAnchor==null)
        {
            Debug.LogError("myAnchor was null on an isle generator. Is there a gameobect in our anchor list that isn't an anchor?");
            return;
        }

        float isleLength = myAnchor.isleLength;
        IsleAnchor.ISLEORIENTATION orientation = myAnchor.isleOrientation;

        float currentIsleLengthLeft = 0;
        float currentIsleLengthRight = 0;


        GameObject shelfGeneratorPrefab = StoreGenerator.getSingleton().shelfGeneratorPrefab;

        //TODO: make our decision on what isles are populated with here
        GameObject[] availableShelves = StoreGenerator.getSingleton().shelfPrefabs;
        //TODO: determine shelf lengths 
        float shelfLength = 2.0f;// TODO: just pull this out of the prefabs collider and return it here.

        while(currentIsleLengthLeft<isleLength)
        {
            float currentLocationRatio = (currentIsleLengthLeft / isleLength)*myAnchor.leftIsleProducts.Length;
            GameObject shelf = Instantiate(shelfGeneratorPrefab, this.gameObject.transform, false);
            if(myAnchor.isleOrientation==IsleAnchor.ISLEORIENTATION.Y)
                shelf.transform.localPosition = new Vector3(0, 0, (shelfLength / 2.0f) + currentIsleLengthLeft);
            else
                shelf.transform.localPosition = new Vector3((shelfLength / 2.0f) + currentIsleLengthLeft,0,0);
            currentIsleLengthLeft += shelfLength * 1.01f;
            ShelfGenerator shelfGen = shelf.GetComponent<ShelfGenerator>();
            //shelfGen.//TODO Assign what product this shelf will be generating here based on product catagories.
            //GameObject[] 
        }

        while (currentIsleLengthRight < isleLength)
        {
            float currentLocationRatio = (currentIsleLengthRight / isleLength)*myAnchor.rightIsleProducts.Length;

            GameObject shelf = Instantiate(shelfGeneratorPrefab, this.gameObject.transform, false);
            if (myAnchor.isleOrientation == IsleAnchor.ISLEORIENTATION.Y)
                shelf.transform.localPosition = new Vector3(0, 0, (shelfLength / 2.0f) + currentIsleLengthRight);
            else
                shelf.transform.localPosition = new Vector3((shelfLength / 2.0f) + currentIsleLengthRight, 0, 0);
            currentIsleLengthRight += shelfLength * 1.01f;
        }
    }
}
