﻿//  Created by Hemanth Kotla(301084656), Pratiksha Kathiriya (301093309), Kevin Nobel (301093673) on 2020-01-17.
// last modified on 2020-04-17
// File Description : Game Controller
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
using UnityEngine.SceneManagement;


[System.Serializable]

public class JoyStick : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public Transform firepoint;
    public float speed = 2.0f;
    public float direc = 5.0f;
    public bool touchstart = false;
    private Vector2 pointA;
    private Vector2 pointb;
    private Vector2 pointc;
    private bool left, right;
    private bool btleft, btright;
    public float jump = 1.0f;
    public Text Lives;
    public Text Score;
    public Transform Innerc;
    public Transform Outerc;
    private bool m_FacingRight = true;
    public AudioSource Levelupsound;
    private Vector2 screenbound;



    private int _lives;
    private int _score;


    public int lives
    {
        get { return _lives; }
        set { _lives = value;
            Lives.text = "Lives:" + _lives.ToString();

            if (_lives < 1)
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }


    public int score
    {
        get { return _score; }
        set { _score = value;
            Score.text = "score:" + _score.ToString();

            if (_score == 110)
            {
                Levelupsound.Play();
                SceneManager.LoadScene("Level2");
            }

        }
    }

    public void mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }




    // Start is called before the first frame update
    void Start()
    {
        screenbound = Camera.main.ScreenToWorldPoint(new Vector3(1.1f, 0.5f, 10f));
        right = true;
        lives = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < screenbound.y)
        {
            Destroy(player.gameObject);
            SceneManager.LoadScene("EndScene");

        }



        if (Input.GetMouseButtonDown(0))
        {
            
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            pointc = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            Innerc.transform.position = pointc ;
            Outerc.transform.position = pointc ;
            Innerc.GetComponent<SpriteRenderer>().enabled = true;
            Outerc.GetComponent<SpriteRenderer>().enabled = true;
            float x = 2.0f;
            animator.SetFloat("speed", x);

           
        }
        if (Input.GetMouseButton(0))
        {
            touchstart = true;
            pointb = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
            
        }

        else
        {
            touchstart = false;
            Innerc.GetComponent<SpriteRenderer>().enabled = false;
            Outerc.GetComponent<SpriteRenderer>().enabled = false;
            
            animator.SetFloat("speed", 0);
        }
    }
    private void FixedUpdate()
    {
        if(touchstart)
        {
            
            Vector2 offset = pointb - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);

            if(player.position.y > -0.713)
            {
                animator.SetFloat("Jump", 1);
                
            }

            else if (player.position.y < -0.713)
            {
                animator.SetFloat("Jump", -1);
            }
            direc = offset.x;

            if (direc < 0)
            {

                turnleft();
                // turnbtleft();


            }
            if (direc > 0)
            {
                turnright();
                // turnbtright();

            }


            if (direc > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (direc < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }




            moveplayer(direction );

            Innerc.transform.position = new Vector2(pointc.x + direction.x, pointc.y + direction.y) ;
        }
    }
    void moveplayer(Vector2 direction)
    {
        
        player.Translate(direction * speed * Time.deltaTime);
       




    }

    public void turnleft()
    {
        if (left)
            return;


        player.localScale = new Vector3(-player.localScale.x, player.localScale.y, player.localScale.z);
        

        


        left = true;
        right = false;


    }

    public void turnright()
    {

        if (right)
            return;

        player.localScale = new Vector3(Mathf.Abs(player.localScale.x), player.localScale.y, player.localScale.z);
        
        

        left = false;
        right = true;
    }

    public void Flip()
    {
        
        firepoint.Rotate(0f, 180f, 0f);

        m_FacingRight = !m_FacingRight;
    }

   




}
