using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderControllerPosition : MonoBehaviour
{
    [SerializeField] private CylinderSpawner cylinderSpawner;
    [SerializeField] private Rigidbody rb;

    private int endYValue;
    private void Update()
    {
        
    }
    private void CheckGroundVerticalPosition()
    {
        if (transform.position.y <= endYValue)
        {

        }
    }
    private void SetCylinderNewPosition()
    {

    }
}
