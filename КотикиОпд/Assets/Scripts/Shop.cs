using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Text moneyText;
    public Text healthText;
    public AudioSource moneyAudioSource;
    public string nameLoadingScene;
    public Animator comment;

    [HideInInspector]
    public int countPressed;

    private void Awake()
    {
        moneyText.text = int.Parse(PlayerPrefs.GetString("Money")).ToString();
        string[] str = PlayerPrefs.GetString("Health").Split(' ');
        healthText.text = str[0] + " %";
        print(str[0] + " количество здоровья подгружено");
    }
    //public void PressButton(int price)
    //{
    //    if (int.Parse(moneyText.text) - price < 0)
    //    {
    //        comment.SetTrigger("comment");
    //    }
    //    else
    //    {
    //        countPressed += 1;
    //        moneyText.text = (int.Parse(moneyText.text) - price).ToString();
    //        moneyAudioSource.Play();
    //    }

    //}

    public void ContinueButton(int criticalCountPressed)
    {
        if (countPressed >= criticalCountPressed)
        {
            print("yes");
            PlayerPrefs.SetString("Money", moneyText.text);
            PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "true");
            StartCoroutine(LoadSceneFading());

        }

        else
        { 
            print("no");
            comment.SetTrigger("comment");

        }
    }

    IEnumerator LoadSceneFading()
    {
        float fadeTime = Camera.main.GetComponent<Fading>().Fade(0.5f);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(nameLoadingScene);
    }
}
