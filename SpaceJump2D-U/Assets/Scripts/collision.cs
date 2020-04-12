using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collision : MonoBehaviour
{
    public AudioSource coinsound;
    public AudioSource hitsound;
    public Transform enemy;
    public JoyStick gamecontroller;
    private void OnTriggerEnter2D(Collider2D other)
    {
       
        
        switch (other.gameObject.tag)
        {
            case "enemy":
                Debug.Log("Enemy collison");
                Destroy(other.gameObject);
                gamecontroller.lives -= 1;
                hitsound.Play();
                break;
            case "Spike":
                Debug.Log("Spike Collision");
                hitsound.Play();
                gamecontroller.lives -= 1;

                break;
            case "Reward":
                Debug.Log("Coin Collision");
                gamecontroller.score += 10;
                Destroy(other.gameObject);
                coinsound.Play();
                break;
        }
    }

}
