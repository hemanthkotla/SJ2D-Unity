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
