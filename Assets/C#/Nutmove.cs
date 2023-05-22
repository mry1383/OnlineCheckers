using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
public class Nutmove : MonoBehaviour
{
    MohreFuntion funtion = new MohreFuntion();
   public int position_index;
   public string Mode,Sidepos;
   public bool Attack;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Side()
    {
       int position = funtion.NutsMoveposition(position_index,Mode,Attack,Sidepos);
       print(position);
    }
}
