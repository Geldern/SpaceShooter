using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    //public int SceneToLoad;
    public Button[] lvlButtons;

    private void Start()
    {
        SetProgress();
    }
    void SetProgress()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                lvlButtons[i].interactable = false;
                lvlButtons[i].transform.GetChild(2).gameObject.SetActive(true);
            }
            if (i + 2 < levelAt)
            {
                lvlButtons[i].transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
