using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Textnameplayers : MonoBehaviour
{ 
     static TMP_Text player1 , player2;
    void Start()
    {
        player1 = GameObject.Find("Text_1").GetComponent<TMP_Text>();
        player2 = GameObject.Find("Text_2").GetComponent<TMP_Text>();
        player1.text = Menumanager.player1.text;
        player2.text = Menumanager.player2.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
