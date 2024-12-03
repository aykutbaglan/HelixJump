using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Vector2 velocityLimitMinMax;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    public Text scoreText;
    private int score;
  
    

    private void Start()
    {
        score = 0;
        scoreText.text = "Score : " + score;
        // Score : 0
       
        
    }



    private void FixedUpdate()
    {
        var vertical = myRigidbody.velocity;
        vertical.y = Math.Clamp(vertical.y, velocityLimitMinMax.x, velocityLimitMinMax.y);
        myRigidbody.velocity = vertical;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "die")
        {
            Time.timeScale = 0;
            
            losePanel.SetActive(true);
        }
        if (collision.gameObject.tag == "win")
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
            
        }

    }

     void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("points"))
        {
            score++;
            scoreText.text = "Score : " + score;
            
         
        }
    }



    public void RestartGame()
    {
        Time.timeScale = 1;
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



}
 

