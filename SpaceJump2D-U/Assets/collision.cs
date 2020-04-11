using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class collision : MonoBehaviour
{
    public Transform enemy;
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        Debug.Log("hit detected");
        Destroy(enemy.gameObject);
    }

}
