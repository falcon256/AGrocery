using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductSpawnScript : MonoBehaviour
{
    public GameObject player;

    public GameObject product1;
    public GameObject product2;
    public GameObject product3;

   /* public GameObject textBox;
    public Text text;
    */

    //public int count = 0;

    public bool closeToPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        //textBox = GameObject.FindWithTag("NotificationText");

        spawnRooms();     
    }

    // Update is called once per frame
    void Update()
        {
            }    

    public void spawnRooms()
    {
        var productToSpawn = Random.Range(0, 3);

        if (productToSpawn == 0)
        {
            var product1Spawned = (GameObject)Instantiate(product1, transform.position, transform.rotation);
        }
        if (productToSpawn == 1)
        {
            var product2Spawned = (GameObject)Instantiate(product2, transform.position, transform.rotation);
        }
        if (productToSpawn == 2)
        {
            var product3Spawned = (GameObject)Instantiate(product3, transform.position, transform.rotation);
        }
    }

    }
