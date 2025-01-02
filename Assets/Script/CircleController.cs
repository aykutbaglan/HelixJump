using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public List<GameObject> pieces;
    public float moveSpeed = 25f;
    public ObjectPool objectPool;
    [SerializeField] private Material[] materials;
    [SerializeField] private Renderer[] cylinderRenderer;
    [SerializeField] private float speedIncreaseMultiply = 0.5f;
    [SerializeField] private float maxSpeed = 25;
    private int currentMaterialIndex = 0;

    private void Start()
    {
        if (materials.Length > 0)
        {
            ApplyMaterial(currentMaterialIndex);
        }
    }
    private void Update()
    {
        Movement();
    }
    private void Movement()
    {
        if (moveSpeed < maxSpeed)
        {
            moveSpeed += speedIncreaseMultiply * Time.deltaTime;
        }
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TopCollider")
        {
            transform.position = objectPool.cylinderSpawnTransform.position;

            float randomYRotation = UnityEngine.Random.Range(0f, 330f);
            transform.rotation = Quaternion.Euler(0, randomYRotation, 0);

            currentMaterialIndex++;
            if (currentMaterialIndex >= materials.Length)
            {
                currentMaterialIndex = 0;
            }
            ApplyMaterial(currentMaterialIndex);            
        }        
    }
    private void ApplyMaterial(int index)
    {
        Material[] newMaterials = new Material[1];
        newMaterials[0] = materials[index];
        foreach (var item in cylinderRenderer)
        {
            item.materials = newMaterials;
        }
    }
    public void PrepareSimple()
    {
        float rotY = UnityEngine.Random.Range(0f, 330f);
        transform.Rotate(0f, rotY, 0f);
    }
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
}