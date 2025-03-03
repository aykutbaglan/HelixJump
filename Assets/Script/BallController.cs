﻿using UnityEngine;
public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Vector2 velocityLimitMinMax;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private InputController inputController;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ObjectPoolTest objectPoolTest;
    [SerializeField] private AudioSource pointSfx;
    [SerializeField] private AudioSource dieSfx;

    private void FixedUpdate()
    {
        var vertical = myRigidbody.velocity;
        vertical.y = Mathf.Clamp(vertical.y, velocityLimitMinMax.x, velocityLimitMinMax.y);
        myRigidbody.velocity = vertical;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "die")
        {
            dieSfx.Play();
            stateMachine.TransitionToSpecificState(2);
            inputController.CanvasDisable();
            objectPoolTest.StopSpawned();
        }
        if (collision.gameObject.tag == "points")
        {
            pointSfx.Play();
            scoreManager.score++;
            scoreManager.UpdateScoreText();
            if (scoreManager.score > scoreManager.highScore)
            {
                scoreManager.highScore = scoreManager.score;
                PlayerPrefs.SetInt("HighScore", scoreManager.highScore);
                scoreManager.UpdateHighScoreText();
            }
        }
    }
    public void RBActiveControl(bool IsGravity)
    {
        myRigidbody.useGravity = IsGravity;
        myRigidbody.isKinematic = !IsGravity;
    }
}