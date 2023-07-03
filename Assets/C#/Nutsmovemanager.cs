using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Nutsmovemanager : MonoBehaviour
{
    //Turn icons
    static Image blue,red;
        void Start()
    {
        blue = GameObject.Find("BlueTurn").GetComponent<Image>();
        red = GameObject.Find("RedTurn").GetComponent<Image>();
        blue.enabled = true;
        red.enabled = false;
    }
    public enum NutsTurn
    {
        up,down
    }
    public static NutsTurn nutTurn = NutsTurn.up;

    public static void Turn()
    {
        if(nutTurn == NutsTurn.up)
        {
            nutTurn = NutsTurn.down;
        blue.enabled = false;
        red.enabled = true;
        }
        else
        {
            nutTurn = NutsTurn.up;
        blue.enabled = true;
        red.enabled = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
