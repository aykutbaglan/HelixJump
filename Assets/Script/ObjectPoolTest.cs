using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTest : MonoBehaviour
{
    public Transform parentObject;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private ObjectPool objectPool = null;
    [SerializeField] protected Vector3 spawnStartPosition = Vector3.zero;
    //private float currentYOffset;
    private bool isspawning = false;
    private void Start()
    {
        //currentYOffset = 0f;
    }
    public void StartSpawned()
    {
        if (!isspawning)
        {
            isspawning = true;
        }
    }
    public void StopSpawned()
    {
        isspawning= false;
    }
}