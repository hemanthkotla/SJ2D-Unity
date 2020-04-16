using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour

{
    Rigidbody2D rb;
    public GameObject  target;
    float moveSpeed;
    Vector3 directionToTarget;
    public GameObject explosion;
    public JoyStick gamecontroller;
    private int life;
    public AudioSource hit;
    public GameObject smallexplosion;



    void Start()
    {
        target = GameObject.Find("Player");

        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 0.5f;
        life = 4;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBoss();

        if (life < 1)
        {
            Destroy (gameObject);
            Instantiate(smallexplosion, transform.position, transform.rotation);

        }
    }

    



void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {

            //case "Player":
            //    hit.Play();
            //    Debug.Log("********************Player****************");
            //    gamecontroller.lives -= 1;
            //    break;

            case "Bullet":
                life -= 1;
                
                Destroy(col.gameObject);

                break;
        }
    }

   



void MoveBoss()
    {
        if (target != null)
        {
            directionToTarget = (target.transform.position - transform.position).normalized;
            rb.velocity = new Vector2(directionToTarget.x * moveSpeed,
                                        directionToTarget.y * moveSpeed);
        }
        else
            rb.velocity = Vector3.zero;
    }



}
