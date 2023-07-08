using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Menumanager : MonoBehaviour
{
    Animator anim;
    public static TMP_Text player1 , player2;
    void Start()
    {
        anim    = GetComponent<Animator>();
        player1 = GameObject.Find("Textname1").GetComponent<TMP_Text>();
        player2 = GameObject.Find("Textname2").GetComponent<TMP_Text>();
    }
    public void menumove(int index)
    {
        anim.SetInteger("index",index);
    }
    public static void Offlinetexts()
    {
      PlayerPrefs.SetString("name1",player1.text);
      PlayerPrefs.SetString("name2",player2.text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
