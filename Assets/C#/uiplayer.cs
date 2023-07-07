using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class uiplayer : MonoBehaviour
{
       private AudioSource _soundplayer;
       public AudioClip winsound;
       public  GameObject winmenu,TitrText;
       public TMP_Text wintext;
       public Image health;
       public TMP_Text haelthvalue;
       int  fullhealth =100;

     void Start()
    {
         _soundplayer = GetComponent<AudioSource>();
        winmenu = GameObject.Find("win");
        TitrText = GameObject.Find("TitrText");
        wintext = TitrText.GetComponent<TMP_Text>();
        if(gameObject.layer==6)
        {
         winmenu.SetActive(false);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  Damage()
    {
         
       health.fillAmount -= 0.14f;
       fullhealth-=14;
        haelthvalue.text = fullhealth.ToString()+"%";
        if(fullhealth<=0)
        {
           winmenu.SetActive(true);
           wintext.text = LayerMask.LayerToName(gameObject.layer)+"win";
           _soundplayer.PlayOneShot(winsound);
        }
         
    }
}
