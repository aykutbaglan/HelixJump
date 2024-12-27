using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Vector2 velocityLimitMinMax;
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private InputController inputController;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private ObjectPoolTest objectPoolTest;
    [SerializeField] private ObjectPool objectPool;

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
            stateMachine.TransitionToSpecificState(3);
            inputController.CanvasDisable();
            objectPoolTest.StopSpawned();
            //objectPool.StopMoving();
        }
        if (collision.gameObject.tag == "points")
        {
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