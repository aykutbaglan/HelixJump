using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
 
    public static void GameResume()

    {
        Time.timeScale = 1f;
    }
    public static void GamePause()
    {
        Time.timeScale = 0f;
    }
}