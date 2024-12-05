using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Text scoreText;
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Vector2 velocityLimitMinMax;
    //[SerializeField] private GameObject losePanel;
    //[SerializeField] private GameObject winPanel;
    [SerializeField] private StateMachine stateMachine;
    private int score;

    private void Start()
    {
        score = 0;
        scoreText.text = "Score : " + score;
    }
    private void FixedUpdate()
    {
        var vertical = myRigidbody.velocity;
        vertical.y = Mathf.Clamp(vertical.y, velocityLimitMinMax.x, velocityLimitMinMax.y);
        myRigidbody.velocity = vertical;
    }
    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "CircleController")
        //{
        //    stateMachine.TransitionToNextState();
        //}
        if (collision.gameObject.tag == "die")
        {
            stateMachine.TransitionToSpecificState(3);
        }
        else if (collision.gameObject.tag == "win")
        {
            stateMachine.TransitionToSpecificState(2);
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
    public void RBActiveControl(bool IsGravity)
    {
        myRigidbody.useGravity = IsGravity;
        myRigidbody.isKinematic = !IsGravity;
    }
}