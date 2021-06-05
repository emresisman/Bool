using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagement
{
    public static void LoadLevel(string levelname)
    {
        SceneManager.LoadScene(levelname);
    }

    public static void LoadLevel(int levelindex)
    {
        
        SceneManager.LoadScene(levelindex);

    }

    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void QuitApplication()
    {

    }
}
