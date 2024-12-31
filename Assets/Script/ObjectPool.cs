using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    public Transform cylinderSpawnTransform;
    [SerializeField] private int poolSize;
    [SerializeField] private float verticalDistance = 25;
    private Queue<GameObject> pooledObjects;

    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();
        Create(poolSize);
    }

    private void Create(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var createObject = Instantiate(objectPrefab,cylinderSpawnTransform);
            createObject.transform.localPosition = new Vector3(0, i * verticalDistance, 0);
            CircleController circleController = createObject.GetComponent<CircleController>();
            circleController.PrepareSimple();
            circleController.objectPool = this;
        }
    }
    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);

        pooledObjects.Enqueue(obj);

        return obj;
    }

}