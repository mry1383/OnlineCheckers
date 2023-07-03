using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIButtonCode : MonoBehaviour
{
     public AudioSource soundplayer;
     public AudioClip Button_sound;
     TMP_InputField playername;
    void Start()
    {
        playername = GameObject.Find("Textname").GetComponent<TMP_InputField>();
    }

    
    void Update()
    {
        
    }
    public void button(int scene)
    {
        soundplayer.PlayOneShot(Button_sound);
        SceneManager.LoadScene(scene);
    }
    public void Lan()
    {
        soundplayer.PlayOneShot(Button_sound);

    }
    public void Online()
    {
        soundplayer.PlayOneShot(Button_sound);

    }
    static void SendPlayerName()
    {
        
    }
    public void Linkedin(string URL)
    {
        soundplayer.PlayOneShot(Button_sound);
          Application.OpenURL(URL);
    }

}
