using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 namespace MohreFuntions 
 {
using UnityEngine;
using UnityEngine.UI;
  
  public class MohreFuntion : MonoBehaviour 
  {
    public int leftmove ,rightmove ;
    public  int NutsMoveposition (int index,string NutMode,bool attack,string side)
    {
        if(NutMode=="up")
        {
        leftmove = index  +7;
        rightmove = index +9;
        }
        else if(NutMode=="down")
        {
        leftmove = index  -9;
        rightmove = index -7;
        }
        if(attack==true)
        {
         if(NutMode=="up")
         {
            leftmove = index  +(7*2);
            rightmove = index +(9*2);
            }
            else if(NutMode=="down")
            {
            leftmove =  index  -(9*2);
            rightmove = index  -(7*2);
            }
        }
        if(side =="left")
        {
          return leftmove;
        }
       else if(side =="right")
        {
          return rightmove;
        }
        else
          return 0;
          
          


    }  

  }
  public class earthposition : MonoBehaviour {
   public bool [] gridenabled = new bool [65];
    public bool gridmode(int index) 
      {
       return gridenabled[index];

      }
    
    public void MapGridEnabled(int index,bool isgrid)
    {
      
      gridenabled[index] = isgrid;
          
    }
  }
   
  public class Move :  MonoBehaviour {
    public void normalmove(RectTransform side,RectTransform vec,float speed)
    {
       side.position = Vector3.MoveTowards(side.anchoredPosition ,vec.anchoredPosition,speed*Time.deltaTime);
    }
    
    public void attackmove()
    {
      
    }
  
  }

 }
