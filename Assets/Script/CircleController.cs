using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleController : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public List<GameObject> pieces;
    public float moveSpeed = 25f;

    [SerializeField] private ObjectPool objectPool;


    private void Update()
    {
        Debug.Log($"Time Scale = {Time.timeScale}");
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }

    public void PrepareSimple()
    {
        float rotY = Random.Range(0f, 270f);
        transform.Rotate(0f, rotY, 0f);

        //int index = Random.Range(0, pieces.Count);

        //for (int i = 0; i < nonactiveAmount; i++)
        //{
        //    var item = pieces[index];
        //    item.SetActive(false);
        //    index++;
        //    if (index >= pieces.Count)
        //    {
        //        index = 0;
        //    }
        //}


    }
    public void UpdateScore()
    {
        score += 10;
        scoreText.text = "Score: " + score;
    }
}