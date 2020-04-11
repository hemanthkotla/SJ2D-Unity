using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 screenbound;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenbound = Camera.main.ScreenToWorldPoint(new Vector3(1.1f, 0.5f, 10f));

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < screenbound.x)
        {
            Destroy(this.gameObject);
        }
    }
}
