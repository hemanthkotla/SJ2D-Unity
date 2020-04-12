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
    public float speed = 2.0f;
    public float direc = 5.0f;
    public bool touchstart = false;
    private Vector2 pointA;
    private Vector2 pointb;
    private Vector2 pointc;
    private bool left, right;
    public float jump = 1.0f;
    public Text Lives;
    public Text Score;
    public Transform Innerc;
    public Transform Outerc;


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
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        right = true;
        lives = 3;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

       


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

            if(Input.GetAxis("Jump")> 0.1f)
            {
                animator.SetFloat("Jump", 1);
            }


            direc = offset.x;

            if(direc < 0)
            {
                turnleft();
            }
            if (direc > 0)
            {
                turnright();
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

   

    


}
