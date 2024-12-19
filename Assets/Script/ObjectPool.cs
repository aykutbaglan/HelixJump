using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private ObjectPoolTest objectPoolTest;
    [SerializeField] private float moveSpeed = 5f;
    private Queue<GameObject> pooledObjects;

    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab,objectPoolTest.parentObject);
            obj.SetActive(false);


            pooledObjects.Enqueue(obj);
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    public GameObject GetPooledObject()

    {
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);

        pooledObjects.Enqueue(obj);

        return obj;
    }
}
