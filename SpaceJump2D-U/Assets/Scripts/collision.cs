using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class collision : MonoBehaviour
{
    public AudioSource coinsound;
    public AudioSource hitsound;
    public Transform enemy;
    public JoyStick gamecontroller;
    public Boss bosslevel;
    public Transform Boss1;
    public Transform spawn;
    public GameObject explosion;
    public Transform playerpos;

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        
        switch (other.gameObject.tag)
        {
            case "enemy":
                Debug.Log("Enemy collison");
                Destroy(other.gameObject);
                gamecontroller.lives -= 1;
                Instantiate(explosion, playerpos.position, playerpos.rotation);


                hitsound.Play();
                break;
            case "Spike":
                Debug.Log("Spike Collision");
                hitsound.Play();
                Instantiate(explosion, playerpos.position, playerpos.rotation);
                gamecontroller.lives -= 1;

                break;
            case "Reward":
                Debug.Log("Coin Collision");
                gamecontroller.score += 10;
                Destroy(other.gameObject);
                coinsound.Play();
                break;
            case "Boss":
                hitsound.Play();
                Debug.Log("********************Player****************");

                Instantiate(explosion, playerpos.position, playerpos.rotation);
                gamecontroller.lives -= 1;
                break;


        }

       

    }

}
