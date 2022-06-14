using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] private string createTag;

    private void Awake()
    {
        GameObject obj = GameObject.FindGameObjectWithTag(this.createTag);
        if(obj != null)
        {
            Destroy(this.gameObject);

        }
        else
        {
            this.gameObject.tag = this.createTag;
            DontDestroyOnLoad(this.gameObject);
        }

    }


}
