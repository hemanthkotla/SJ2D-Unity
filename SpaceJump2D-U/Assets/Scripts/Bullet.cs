//  Created by Hemanth Kotla(301084656), Pratiksha Kathiriya (301093309), Kevin Nobel (301093673) on 2020-01-17.
// last modified on 2020-04-17
// File Description :Bullet Controller
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

public class Bullet : MonoBehaviour


{
    // Start is called before the first frame update

    public float speed = 15f;
    public Rigidbody2D rb;
    public JoyStick gamecontroller;
    
   
    public GameObject explosion;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "enemy":
                Debug.Log("Enemy collison");
                Destroy(other.gameObject);
                Destroy(gameObject);
                Instantiate(explosion, transform.position, transform.rotation);
                Destroy(explosion);
               
                break;
            
        }

    }
}
