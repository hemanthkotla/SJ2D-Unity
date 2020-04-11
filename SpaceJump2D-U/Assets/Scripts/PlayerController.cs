using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    
    // Update is called once per frame
    private void Update()
    {
       if(Input.GetKey(KeyCode.Backspace))
        {
            rb.velocity = new Vector2(-15, 0);

        }

    }
}
