using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;
public class Nut : MonoBehaviour
{
    public GameObject leftmove,rightmove;
    public Transform x;
    int mousenumber = 0;
    float movespped = 5f;
   Move nutmove = new Move();
   MohreFuntion targetFinder = new MohreFuntion();
    void Start()
    {
     leftmove.SetActive(false);
     rightmove.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
          // mouseClick();
        }
    }

     public void nutclick()
    {
     
     leftmove.SetActive(true);
     rightmove.SetActive(true);
    }
    public void mouseClick()
  {
             mousenumber++;
             if(mousenumber ==1)
             {
                     leftmove.SetActive(false);
                     rightmove.SetActive(false);
                     mousenumber=0;
             }
  }
  //click for move
   public void movetoside(string side)
   {
    if(side =="right")
    {
        
       nutmove.normalmove(transform,x,movespped);
    }
      
   }

}
