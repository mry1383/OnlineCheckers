using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;
public class Nut : MonoBehaviour
{
    public GameObject leftmove,rightmove;
    public Vector3 target = new Vector3(0f,0f,0f);
    int mousenumber = 0 , index = 0;
    float movespped = 5f;
   Move nutmove = new Move();
   MohreFuntion targetFinder = new MohreFuntion();
   public RectTransform  trans,rightpos,leftpos;
    void Start()
    {
      trans = GetComponent<RectTransform>();
      rightpos = rightmove.GetComponent<RectTransform>();
      leftpos = leftmove.GetComponent<RectTransform>();
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
      int flux  = targetFinder.NutsMoveposition(index,"up",false);
      
       nutmove.normalmove(trans,rightpos,movespped);
    }
    else
    {
      nutmove.normalmove(trans,leftpos,movespped);
    }
      
   }

}
