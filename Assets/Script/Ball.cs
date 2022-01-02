using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rigi;
    float speed1 = 10f, speed2= 3f;

    public TextMeshProUGUI Player1Text, Player2Text, WinText;
    int Player1Score, Player2Score;
    public GameObject RestartPanel;

    public AudioSource winAudio, ScoreAudio, BPContact;
                                             // ball and player contact audio
    void Start()
    {
        
    }

    void Update()
    {
        Score();
    }

    private void OnCollisionEnter2D(Collision2D contact)
    {
        //Player Contact
        if (contact.gameObject.tag == "Player1")
        {
            BPContact.Play();
            rigi.velocity = new Vector2(speed1, Random.Range(-2f,2f));
            
        }
        else if (contact.gameObject.tag == "Player2")
        {
            BPContact.Play();
            rigi.velocity = new Vector2(-speed1, Random.Range(-2f, 2f));
       
        }
        // Wall Contact
        if(contact.gameObject.tag == "UpWall")
        {
            rigi.velocity = new Vector2(rigi.velocity.x, -speed2);
           
        }
        else if(contact.gameObject.tag == "DownWall")
        {
            rigi.velocity = new Vector2(rigi.velocity.x,speed2);
          
        }
        // Life reducing wall contact
        if (contact.gameObject.tag == "RightWall")
        {
            ScoreAudio.Play();
            Player1Score++;
            transform.position = new Vector2(-7.42f, 0f);
          
        }else if(contact.gameObject.tag == "LeftWall")
        {
            ScoreAudio.Play();
            Player2Score++;
            transform.position = new Vector2(7.42f, 0f);
        }
    }
    
    void Score()
    {
        // Current score
        Player1Text.text = Player1Score.ToString();
        Player2Text.text = Player2Score.ToString();

        // Who is won?
        if (Player1Score == 3)
        {
            winAudio.Play();
            WinText.text = "Player 1 Won";
            Time.timeScale = 0;
            RestartPanel.SetActive(true);
        }
        else if (Player2Score==3)
        {
            winAudio.Play();
            WinText.text = "Player 2 Won";
            Time.timeScale = 0;
            RestartPanel.SetActive(true);
        }
        // Press Enter to restart
        if (Time.timeScale==0 && Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale=1;
        }
    }

}
