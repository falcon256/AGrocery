using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollisionMoney : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay(Collider collidedMoney)
    {
        if (collidedMoney.gameObject.tag == "Money")
        {
            if (collidedMoney.GetComponent<MoneyData>().hasBeenUsed == true)
            {
                collidedMoney.gameObject.SetActive(false);
            }
        }
    }
}
