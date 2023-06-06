using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nutsmovemanager : MonoBehaviour
{
    public enum NutsTurn
    {
        up,down
    }
    public static NutsTurn nutTurn = NutsTurn.up;
    void Start()
    {
        
    }
    public static void Turn()
    {
        if(nutTurn == NutsTurn.up)
        {
            nutTurn = NutsTurn.down;
        }
        else
        {
            nutTurn = NutsTurn.up;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
