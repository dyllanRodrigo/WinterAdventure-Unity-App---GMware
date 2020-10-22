using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public static int score;

    Text text;

    void Start()
    {

        text = GetComponent<Text>();
        score = PlayerPrefs.GetInt("CurrentScore");

    }

    void Update()
    {
        if (score < 0)
            score = 0;
        text.text = "" + score;

    }

    public static void AddPoints(int PointsToAdd)
    {
        score += PointsToAdd;
        PlayerPrefs.SetInt("CurrentScore", score);
    }

    public static void Reset(){
        score = 0;
        PlayerPrefs.SetInt("CurrentScore", score);
    }

}