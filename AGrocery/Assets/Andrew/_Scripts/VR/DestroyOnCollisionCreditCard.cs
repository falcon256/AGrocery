using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionCreditCard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collidedCard)
    {
        if (collidedCard.gameObject.tag == "Card")
        {
            collidedCard.gameObject.SetActive(false);
        }
    }
}
