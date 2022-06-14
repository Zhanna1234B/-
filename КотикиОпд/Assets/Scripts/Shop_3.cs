using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop_3 : MonoBehaviour
{
    public GameObject interfaceObj;
    public int count;
    public GameObject panel;


    private void Update()
    {
        if(count == 7)
        {
            interfaceObj.SetActive(false);
            panel.SetActive(true);
            PlayerPrefs.DeleteAll();
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
