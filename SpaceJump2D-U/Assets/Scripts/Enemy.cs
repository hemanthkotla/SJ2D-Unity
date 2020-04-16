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
