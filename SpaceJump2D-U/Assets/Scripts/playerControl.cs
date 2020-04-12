using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "enemy":
                Debug.Log("Enemy collison");
                break;
            case "Spike":
                Debug.Log("Spike Collision");
                break;
            case "Reward":
                Debug.Log("Coin Collision");
                break;
        }
       
    }


    
}
