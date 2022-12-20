using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    Rigidbody2D rb;
    int life=100;
    int jp = 2;
    private bool isGrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    
    private void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //anim.SetBool("Ground", false);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 600));
        }
        if (jp > 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
                jp = jp - 1;
            }
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * 12f, rb.velocity.y);
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool("Ground", isGrounded);
        //anim.SetFloat("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
        if (!isGrounded) {
            return;
        }

        

    }
    void jump()
    {
        rb.AddForce (transform.up * 14f, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D lol)
    {
        if (lol.gameObject.CompareTag("Finish"))
        {
            Debug.Log("level");
            SceneManager.LoadScene("Level2");
        }
        if (lol.gameObject.CompareTag("Finish2"))
        {
            Debug.Log("level");
            SceneManager.LoadScene("Level3");
        }
        if (lol.gameObject.CompareTag("End"))
        {
            Debug.Log("level");
            SceneManager.LoadScene("end_screen");
        }
        if (lol.gameObject.CompareTag("Eneme"))
        {
            if (lol.gameObject.CompareTag("Eneme"))
            {
                life = life - 1;
            }
        }
        if (lol.gameObject.CompareTag("MainCamera"))
        {

            life = life - 25;

            jp = 2;
        }
        if (lol.gameObject.CompareTag("Death"))
        {
            life = life - 1000;
        }
        if (lol.gameObject.CompareTag("Floor"))
        {
            jp = 2;
        }
        if (life < 1)
        {
            Invoke("ReoladLevel", 0);
        }
    }
    void OnGUI()
    {
        GUI.Box (new Rect(0,0,100,30), "life = "+life);
        GUI.Box(new Rect(0, 100, 100, 30), "jumps = " + jp);
    }
    void ReoladLevel()
    {
        Application.LoadLevel (Application.loadedLevel);
    }
}
