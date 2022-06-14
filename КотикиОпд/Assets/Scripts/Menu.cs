using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private string nameLoadingScene;

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        nameLoadingScene = "Day_0";
        StartCoroutine(LoadSceneFading());
    }

    public void ContinueGame()
    {

        if (PlayerPrefs.GetString("Day_0") != "true")
            NewGame();
        else if (PlayerPrefs.GetString("Shop_1") != "true")
        {
            nameLoadingScene = "Shop_1";
            StartCoroutine(LoadSceneFading());
        }
        else if (PlayerPrefs.GetString("Shop_2") != "true")
        {
            nameLoadingScene = "Shop_2";
            StartCoroutine(LoadSceneFading());
        }
        else if (PlayerPrefs.GetString("Shop_3") != "true")
        {
            nameLoadingScene = "Shop_3";
            StartCoroutine(LoadSceneFading());
        }
        else
            for (var i = 1; i < 10; i++)
            {
                if (PlayerPrefs.GetString("Morning_" + i) != "true")
                {
                    nameLoadingScene = "Morning_" + i;
                    StartCoroutine(LoadSceneFading());
                    break;
                }

                if (PlayerPrefs.GetString("Day_" + i) != "true")
                {
                    nameLoadingScene = "Day_" + i;
                    StartCoroutine(LoadSceneFading());
                    break;
                }
            }

    }

    public void ExitGame()
    {
        Application.Quit();
    }

   
    IEnumerator LoadSceneFading()
    {
        float fadeTime = Camera.main.GetComponent<Fading>().Fade(0.5f);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(nameLoadingScene);
    } 
    
    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Money()
    {
        PlayerPrefs.SetString("Money", "4000");
    }
}
