using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public List<GameObject> pieces;

    public void PrepareSimple(int nonactiveAmount)
    {
        int index = Random.Range(0, pieces.Count);

        for (int i = 0; i < nonactiveAmount; i++)
        {
            var item = pieces[index];
            item.SetActive(false);
            index++;
            if (index >= pieces.Count)
                index = 0;
        }
    }
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
}