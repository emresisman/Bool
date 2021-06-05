using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public int level;
    public int minValue;
    public int maxValue;
}

[System.Serializable]
public class LevelRoot
{
    public Level[] levels;
}