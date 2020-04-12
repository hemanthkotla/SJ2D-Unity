using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collision : MonoBehaviour
{
    public AudioSource coinsound;
    public AudioSource hitsound;
    public Transform enemy;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        
        switch (other.gameObject.tag)
        {
            case "enemy":
                Debug.Log("Enemy collison");
                Destroy(other.gameObject);
                hitsound.Play();
                break;
            case "Spike":
                Debug.Log("Spike Collision");
                hitsound.Play();

                break;
            case "Reward":
                Debug.Log("Coin Collision");
                Destroy(other.gameObject);
                coinsound.Play();
                break;
        }
    }

}
