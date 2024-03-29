using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;
    public Text loseText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        count = 0;
        lives = 3;
        winText.text = "";
        loseText.text = "";
        SetCountText ();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetCountText();
            livesText.text = "Lives Left: " + lives.ToString();
            if (lives <= 0)
            {
                winText.text = "You Lose!";
            }
            if (lives <= 0) Destroy(this);
        }    
        if (count == 12)
    {
    transform.position = new Vector2(50.0f, 50.0f); 
}
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 20)
        {
            winText.text = "You Win! Game created by Jovian Rios!";
                }
           }
    }
