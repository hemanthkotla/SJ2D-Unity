//  Created by Hemanth Kotla(301084656), Pratiksha Kathiriya (301093309), Kevin Nobel (301093673) on 2020-01-17.
// last modified on 2020-04-17
// File Description : Enemy Controller
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

public class Enemy : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody2D rb;
    public GameObject target;
    private Vector2 screenbound;
    float moveSpeed;
    Vector3 directionToTarget;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = this.GetComponent<Rigidbody2D>();
        moveSpeed = 0.5f;

        screenbound = Camera.main.ScreenToWorldPoint(new Vector3(1.1f, 0.5f, 10f));

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (transform.position.x < screenbound.x)
        {
            Destroy(this.gameObject);
        }
    }

    void Move()
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
