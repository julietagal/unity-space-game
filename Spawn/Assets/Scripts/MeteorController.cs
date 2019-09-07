using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MeteorController : MonoBehaviour
{
    PlayerController player;
   

    void Start()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        player = go.GetComponent<PlayerController>();

    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        

        if (other.gameObject.CompareTag("Player"))
        {
            player.Life.value -= 5;
        }
        else
        {
            player.Score += 5;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }


    }

   
}
