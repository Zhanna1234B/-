using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveAndLoadNewScene : MonoBehaviour
{
    public string nameLoadingScene;
    public Text moneyText;
    public Text healthText;
    public int timeCritical;
    public AudioSource moneyAudioSource;


    private int Health;
    private int Time;
    private int Money;
    
    private void Awake()
    {
        Money = int.Parse(PlayerPrefs.GetString("Money"));
        moneyText.text = Money.ToString();

        //для тестировки
        if (PlayerPrefs.HasKey("Health"))
        {
            string[] str = PlayerPrefs.GetString("Health").Split(' ');
            healthText.text = str[0] + " %";
            Health = int.Parse(str[0]);
            print(str[0] + " количество здоровья подгружено");

        }
        else
            Health = 100;
        

    }

    public void MorningControllerHealth(int health)
    {
        if (Health + health <= 0)
        {
            StartNewGame();
        }
        else
        {
            if (Health + health >= 100)
            {
                Health = 100;
            }
            else
            {
                Health += health;

            }
        }
        healthText.text = Health.ToString() + " %";
       
    }

    public void MorningControllerTime(int time)
    { 
        Time += time;
    }

    public void MorningControllerMoney(int money)
    {
        moneyAudioSource.Play();
        Money += money; 
        moneyText.text = Money.ToString();

    }

    public void TimeController()
    {
        if (Time <= timeCritical)
        {
            PlayerPrefs.SetString("Late", "False");
            print("успел");
        }
        else
        {
            PlayerPrefs.SetString("Late", "True");
            print("не успел");
        }

        LoadNewScene();
    }

    private void StartNewGame()
    {
        PlayerPrefs.DeleteAll();

        nameLoadingScene = "Menu";
        //StartCoroutine(LoadSceneFading()); надпись ты проиграл 
        SceneManager.LoadScene(nameLoadingScene);
    }

    public void LoadNewScene()
    {
        SaveData();
        StartCoroutine(LoadSceneFading());
    }

    private void SaveData()
    {
        PlayerPrefs.SetString("Money", moneyText.text);
        PlayerPrefs.SetString("Health", healthText.text);
        PlayerPrefs.SetString(SceneManager.GetActiveScene().name, "true");
    }

    IEnumerator LoadSceneFading()
    {
        float fadeTime = Camera.main.GetComponent<Fading>().Fade(0.5f);
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene(nameLoadingScene);
    }

}
