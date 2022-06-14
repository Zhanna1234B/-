using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    public GameObject image;
    public int price;

    private Shop shop;
    private Text moneyText;
    private Animator comment;
    private AudioSource moneyAudioSource;

    private void Awake()
    {
        shop = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Shop>();
        moneyText = shop.moneyText;
        comment = shop.comment;
        moneyAudioSource = shop.moneyAudioSource;
    }
    public void PressButton()
    {
        if (int.Parse(moneyText.text) - price < 0)
        {
            comment.SetTrigger("comment");
        }
        else
        {
            shop.countPressed += 1;
            print(shop.countPressed);
            moneyText.text = (int.Parse(moneyText.text) - price).ToString();
            moneyAudioSource.Play();
            image.SetActive(false);
            gameObject.SetActive(false);
        }
     
    }
}
