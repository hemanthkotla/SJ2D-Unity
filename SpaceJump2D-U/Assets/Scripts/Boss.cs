using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour

{
    Rigidbody2D rb;
    public GameObject  target;
    float moveSpeed;
    Vector3 directionToTarget;
    public GameObject explosion;
    public JoyStick gamecontroller;
    
    public AudioSource hit;
    public GameObject smallexplosion;
    public Text Blife;


    private int life;


    void Start()
    {
        target = GameObject.Find("Player");

        
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 2f;
        
        life = 100;
        
       
        //Debug.Log(BLIFE.text);
    }

    // Update is called once per frame
    void Update()
    {




        if (gamecontroller.score == 100)
        {
            MoveBoss();
            Blife.text = "Boss Life : " + life.ToString();
        }


            if (life < 1)
        {
            Destroy (gameObject);
            Instantiate(smallexplosion, transform.position, transform.rotation);
            SceneManager.LoadScene("WonScene");

        }
    }

    



void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {

           

            case "Bullet":
                life -= 10;
                
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
