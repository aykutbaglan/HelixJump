using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private ObjectPoolTest objectPoolTest;
    [SerializeField] private StartState startState;
    [SerializeField] private Transform cylinderStartTransform;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private float verticalDistance = 25;
    [SerializeField] private Transform cylinderSpawnTransform;
    private Queue<GameObject> pooledObjects;

    private bool isMoving = false;

    private void Awake()
    {
        pooledObjects = new Queue<GameObject>();

        //for(int i = 0; i < poolSize; i++)
        //{
           
        //    GameObject obj = Instantiate(objectPrefab,objectPoolTest.parentObject);
        //    obj.SetActive(true);


        //    pooledObjects.Enqueue(obj);

            
        //}
        Create(poolSize);
    }

    private void Create(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            var createObject = Instantiate(objectPrefab,cylinderSpawnTransform);
            createObject.transform.localPosition = new Vector3(0, i * verticalDistance, 0);
            //var random = Random.Range(2, 5);
            CircleController circleController = createObject.GetComponent<CircleController>();
            circleController.PrepareSimple();
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
    }
    public void ResetPosCylinder()
    {
        if (scoreManager.score >= 3)
        {
            transform.position = cylinderStartTransform.position;
        }
    }

    public GameObject GetPooledObject()
    {
        GameObject obj = pooledObjects.Dequeue();
        obj.SetActive(true);

        pooledObjects.Enqueue(obj);

        return obj;
    }
    
    public void StartMoving()
    {
        isMoving = true;
    }
    public void StopMoving()
    {
        isMoving = false;
    }
}
