using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LevelUpHandler();
public delegate void LevelUpUIHandler(int level);

public class LevelGenerator : MonoBehaviour
{
    public event LevelUpHandler LevelIsUp;
    public event LevelUpUIHandler LevelIsUpUI;

    public GameObject leftBar, rightBar;
    public LevelReader levelReader;
    private int level, minValue, maxValue;
    private LevelPass lp;

    public int Level { get => level; }

    #region Singleton

    public static LevelGenerator Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    void Start()
    {
        level = 1;
        GenerateNewBars(level);
        lp = GameObject.FindGameObjectWithTag("Finish").GetComponent<LevelPass>();
        lp.BallReachTheUp += LevelUp;
        LevelIsUpUI?.Invoke(Level);
    }

    private void LevelUp()
    {
        level++;
        LevelIsUp?.Invoke();
        LevelIsUpUI?.Invoke(Level);
        GenerateNewBars(level);
    }

    public void GenerateNewBars(int level)
    {
        int barLength = Random.Range(GetMinValue(level), GetMaxValue(level) + 1);
        float randomBars = Random.Range(0f, barLength);
        leftBar.transform.localScale = new Vector3(randomBars, 1, 1);
        rightBar.transform.localScale = new Vector3(barLength - randomBars, 1, 1);
    }

    public int GetMinValue(int level)
    {
        return levelReader.GetMinValue(levelReader.LevelAdapter(level));
    }

    public int GetMaxValue(int level)
    {
        return levelReader.GetMaxValue(levelReader.LevelAdapter(level));
    }
}