using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public Rigidbody rb;

    public float velocity = 0;

    public int Score = 0;

    public Text Score_Txt;

    void Start()
    {
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector2.up * velocity;
            thisAnimation.Play();
        }

        if(Score >= 150)
        {
            SceneManager.LoadScene("WinScene");
        }
            
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            SceneManager.LoadScene("LoseScene");
        }
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ScoreZone")
        {
            Score += 10;
            Score_Txt.text = "Score: " + Score;
        }
    }
}
