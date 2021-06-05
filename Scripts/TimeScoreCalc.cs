using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScoreCalc : MonoBehaviour
{
    private LevelGenerator lg;
    private float gameTime = 0;
    private int min = 0, sec = 0, score;

    #region Singleton

    public static TimeScoreCalc Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    private void Start()
    {
        lg = LevelGenerator.Instance;
    }

    void Update()
    {
        gameTime += Time.deltaTime;
        UIManager.Instance.PrintTimer(PrintTimer());
    }

    public string PrintTimer()
    {
        min = (int)gameTime / 60;
        sec = (int)gameTime - (min * 60);
        return "TIME\n" + min + " : " + sec;
    }

    public int GetScore()
    {
        score = (((lg.Level * (lg.Level + 1)) / 2) * 100) / (int)gameTime;
        if (lg.Level != 1) return score;
        else return 0;
    }
}
