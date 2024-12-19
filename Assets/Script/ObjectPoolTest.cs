using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolTest : MonoBehaviour
{
    public Transform parentObject;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] private ObjectPool objectPool = null;
    [SerializeField] protected Vector3 spawnStartPosition = Vector3.zero;
    private float yOffset = 16f;
    private float currentYOffset;

    private void Start()
    {
        currentYOffset = 0f;
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        var obj = objectPool.GetPooledObject();
        obj.transform.position = spawnStartPosition + new Vector3(0f, currentYOffset, 0);
        if (parentObject != null)
        {
            obj.transform.SetParent(parentObject);
        }
        currentYOffset += yOffset;
        yield return new WaitForSeconds(spawnInterval);
        StartCoroutine(SpawnRoutine());
    }
}
