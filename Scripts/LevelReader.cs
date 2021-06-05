using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReader : MonoBehaviour
{
    public TextAsset JSONFile;
    private LevelRoot mylevel;

    public int LevelAdapter(float level)
    {
        if (level < 100)
            return (int)Mathf.Floor(level / 10);
        else
            return 10;
    }

    public int GetMinValue(int level)
    {
        mylevel = JsonUtility.FromJson<LevelRoot>(JSONFile.text);
        return mylevel.levels[level].minValue;
    }

    public int GetMaxValue(int level)
    {
        mylevel = JsonUtility.FromJson<LevelRoot>(JSONFile.text);
        return mylevel.levels[level].maxValue;
    }
}