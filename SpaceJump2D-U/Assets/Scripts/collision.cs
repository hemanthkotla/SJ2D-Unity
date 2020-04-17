//  Created by Hemanth Kotla(301084656), Pratiksha Kathiriya (301093309), Kevin Nobel (301093673) on 2020-01-17.
// last modified on 2020-04-17
// File Description : Collison Controller
// Revision history :
// v1 : Added assets and the scenes for the world 1
// v2: Added Player Movement and Joystick Movement
// v3 : Added the player state (moving/idle/jump) using the GKStatemachine
// v4 : Added Camera. parallax animation for mountains and stars
//v5 : Added collision and the app icon
//v6 : Added scoring system
//v7 : Added sound and Level 2
//v8 : added intro scene





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
