using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void GameHandler();

public class UIManager : MonoBehaviour
{
    //public event GameHandler GameIsFinished;
    //public event GameHandler GameIsPaused;
    //public event GameHandler GameIsResumed;

    public GameObject FinishMenuPanel, PauseMenuPanel;
    public Text timerText, scoreText, levelText;
    public Button pauseMenuButton;
    private TimeScoreCalc scoreCalculator;
    private bool isPauseMenuActive = false, isBestScore = false;

    #region Singleton

    public static UIManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    void Start()
    {
        scoreCalculator = TimeScoreCalc.Instance;
        LevelGenerator.Instance.LevelIsUpUI += PrintLevelInGame;
    }

    private void PrintLevelInGame(int level)
    {
        levelText.text = "Level\n" + level.ToString();
    }

    public void PrintTimer(string text)
    {
        timerText.text = text;
    }

    public void PrintScore(int score)
    {
        scoreText.text = "Your Score\n\n" + score;
    }

    public void PrintScoreBest(int score)
    {
        scoreText.text = "NEW BEST!\nYour Score\n" + score;
    }

    public void RestartButton()
    {
        //ResumeGame();
        SceneManagement.RestartLevel();
    }

    public void ContinueButton()
    {
        ResumeGame();
    }

    public void ExitButton()
    {
        SceneManagement.LoadLevel("Start");
    }

    public void PauseButton()
    {
        isPauseMenuActive = !isPauseMenuActive;
        if(isPauseMenuActive) PauseGame();
        else ResumeGame();
    }

    public void PauseGame()
    {
        PauseMenuPanel.gameObject.SetActive(true);
        //GameIsPaused?.Invoke();
        Time.timeScale = 0.0f;
    }

    private void ResumeGame()
    {
        PauseMenuPanel.gameObject.SetActive(false);
        isPauseMenuActive = false;
        //GameIsResumed?.Invoke();
        Time.timeScale = 1.0f;
    }

    public void FinishGame()
    {
        DisablePauseButton();
        Time.timeScale = 0.0f;
        FinishMenuPanel.gameObject.SetActive(true);
        IsBestScore();
        if (isBestScore) PrintScoreBest(scoreCalculator.GetScore());
        else PrintScore(scoreCalculator.GetScore());
    }

    public void ExitGameButton()
    {
        SceneManagement.QuitApplication();
    }

    private void IsBestScore()
    {
        if (SaveSystem.LoadScore() < scoreCalculator.GetScore())
        {
            SaveSystem.SaveScore(scoreCalculator.GetScore());
            isBestScore = true;
        }
    }

    private void DisablePauseButton()
    {
        pauseMenuButton.interactable = false;
    }
}