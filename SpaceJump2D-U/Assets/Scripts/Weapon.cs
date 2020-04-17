//  Created by Hemanth Kotla(301084656), Pratiksha Kathiriya (301093309), Kevin Nobel (301093673) on 2020-01-17.
// last modified on 2020-04-17
// File Description : Weapon Controller
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

public class Weapon : MonoBehaviour
{
    public Transform fire;
    public Transform bullet;
    public AudioSource Bulletsound;

    // Update is called once per frame
    void FixedUpdate()
    {
        


    }



    public void FireButton_Click()
    {
        shoot();
        Bulletsound.Play();
    }


    void shoot()
    {
        Instantiate(bullet, fire.position, fire.rotation);
        return;

    }
}
