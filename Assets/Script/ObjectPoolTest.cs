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
    private bool isspawning = false;

    private void Start()
    {
        currentYOffset = 0f;

    }

    //private IEnumerator SpawnRoutine()
    //{ IEnumerator olmayacak çünkü zamana göre birþey yapmayacaðýz.
    //    if (isspawning)
    //    {
    //        var obj = objectPool.GetPooledObject();
    //        obj.transform.position = spawnStartPosition + new Vector3(0f, currentYOffset, 0);
    //        if (parentObject != null)
    //        {
    //            obj.transform.SetParent(parentObject);
    //        }
    //        currentYOffset += yOffset;
    //        yield return new WaitForSeconds(spawnInterval);
    //        StartCoroutine(SpawnRoutine());
    //    }
    //}

    public void SpawnRoutine()
    {
        if (isspawning)
        {
            var obj = objectPool.GetPooledObject();
            obj.transform.position = spawnStartPosition + new Vector3(0, currentYOffset, 0);
            if (parentObject != null)
            {
                obj.transform.SetParent(parentObject);
            }
            currentYOffset += yOffset;
        }
    }
    public void StartSpawned()
    {
        if (!isspawning)
        {
            isspawning = true;
            //StartCoroutine(SpawnRoutine());
        }
    }
    public void StopSpawned()
    {
        isspawning= false;
    }
}
