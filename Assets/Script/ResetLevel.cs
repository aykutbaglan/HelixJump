using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetLevel : MonoBehaviour
{
    [SerializeField] private Transform resetLevelTransform;
    [SerializeField] private Transform ballTransform;
    private Rigidbody ballRb;

    private void Start()
    {
        ballRb = GetComponent<Rigidbody>();
    }
    public void ResetBallPosition()
    {
        ballRb.velocity = Vector3.zero;
        ballRb.angularVelocity = Vector3.zero;
        ballTransform.position = resetLevelTransform.position;
        
    }
}