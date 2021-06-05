using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveScore(int score)
    {
        PlayerPrefs.SetInt("BestScore", score);
    }

    public static int LoadScore()
    {
        if (PlayerPrefs.HasKey("BestScore")) return PlayerPrefs.GetInt("BestScore");
        else return 0;
    }
}