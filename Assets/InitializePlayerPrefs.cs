using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePlayerPrefs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("bulletSize", 0);
        PlayerPrefs.SetFloat("damage", 1f);
        PlayerPrefs.SetFloat("powerUp", 10f);
        PlayerPrefs.SetFloat("speed", 27f);
        PlayerPrefs.SetFloat("aiSpeed", 30f);
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetInt("level", 1);
        
    }
}
