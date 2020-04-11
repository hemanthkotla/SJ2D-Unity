using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawn : MonoBehaviour
{

    public GameObject enemeyprefab;
    public float spawntime = 1.0f;
    private Vector2 screenbound;
    // Start is called before the first frame update
    void Start()
    {
        screenbound = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.aspect, 0.5f, 10f));
        StartCoroutine(enemywave());
    }

    private void spawn()
    {
        GameObject a = Instantiate(enemeyprefab) as GameObject;
        a.transform.position = new Vector2(screenbound.x * -2, 0);


   }

    IEnumerator enemywave()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawntime);
            spawn();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
