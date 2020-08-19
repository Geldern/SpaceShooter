using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManaging : MonoBehaviour
{

    public int nextSceneLoad;
    public int levelCount;
    public float TimeToWin;
    public PlayerController Player;
    public Button NextLevelButton;
    public Button MainMenuButton;
    public Button TryAgainButton;
    public Text Timer;
    [HideInInspector]
    public int time;
    [HideInInspector]
    public float remainingTime;
    public GameObject WinSound;
    public GameObject LooseSound;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        remainingTime = TimeToWin;
        Time.timeScale = 1;

    }

    void Update()
    {
        remainingTime -= Time.deltaTime;
        Timer.text = "Remains " + Mathf.RoundToInt(remainingTime);
        if (remainingTime <= 0)
        {
            WinLevel();
        }

        if (Player.Health <= 0)
        { 
            LooseLevel();
        }
    }

    
    void LooseLevel()
    {
        Time.timeScale = 0;
        MainMenuButton.gameObject.SetActive(true);
        TryAgainButton.gameObject.SetActive(true);
        LooseSound.SetActive(true);
    }
    

    void WinLevel()
    {
        Time.timeScale = 0;
        MainMenuButton.gameObject.SetActive(true);
        NextLevelButton.gameObject.SetActive(true);
        TryAgainButton.gameObject.SetActive(true);
        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        WinSound.SetActive(true);
    }
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == levelCount) 
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(nextSceneLoad);

            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
        }
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
