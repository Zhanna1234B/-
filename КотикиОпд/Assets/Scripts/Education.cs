using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Education : MonoBehaviour
{
    public string nameLoadingScene;
    public Text moneyText;
    public Text healthText;


    private void Awake()
    {
        moneyText.text = "840";
        healthText.text = "100 %";

        PlayerPrefs.SetString("Money", moneyText.text);
        PlayerPrefs.SetString("Health", healthText.text);
        

    }

    private void OnDisable()
    {
        PlayerPrefs.SetString("Day_0", "true");
    }
}
