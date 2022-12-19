using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] private int playGameIndex;
    [SerializeField] private int mainMenuIndex;
    [SerializeField] private int highScoreIndex;







    public void NewPlayGame()
    {
        SceneManager.LoadScene(playGameIndex);
    }

    public void OnBackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuIndex);
    }
    public void HighscoreGame()
    {
        SceneManager.LoadScene(highScoreIndex);
    }
}
