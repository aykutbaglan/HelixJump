using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSpawner : MonoBehaviour
{
    public GameObject lastGroundobject;
    [SerializeField] private GameObject cylinderPrefab;
    private GameObject newGroundObject;

    private void Start()
    {
        
    }

    public void GenerateRandomNewCylinder()
    {
        for (int i = 0; i < 37; i++)
        {
            CreateNewCylinder();
        }
    }

    private void CreateNewCylinder()
    {
        Vector3 spawnPos = lastGroundobject.transform.position;

        spawnPos += new Vector3(0, 1, 0);

        newGroundObject = Instantiate(cylinderPrefab, spawnPos, Quaternion.identity);
        lastGroundobject = newGroundObject;

    }
}
