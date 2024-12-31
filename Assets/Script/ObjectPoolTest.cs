using UnityEngine;

public class ObjectPoolTest : MonoBehaviour
{
    private bool isspawning = false;
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