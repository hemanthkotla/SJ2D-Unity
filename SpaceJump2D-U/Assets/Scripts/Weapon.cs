using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform fire;
    public Transform bullet;
    public AudioSource Bulletsound;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    shoot();
        //    return;
        //}
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
