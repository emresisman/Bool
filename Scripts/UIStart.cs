using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIStart : MonoBehaviour
{
    public Text bestScoreText;

    private void Start()
    {
        bestScoreText.text = "HIGH SCORE\n" + SaveSystem.LoadScore().ToString();
    }

    public void StartGame()
    {
        SceneManagement.LoadLevel(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
