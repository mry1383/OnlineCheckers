using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 namespace MohreFuntions 
 {
  
  public class MohreFuntion : MonoBehaviour 
  {
     int leftmove ,rightmove;
    public  int NutsMoveposition (int index,string NutMode,bool attack)
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
          return leftmove;
          return rightmove;


    }  

  }
  public class earthposition : MonoBehaviour {
    bool [] gridenabled = new bool [65];
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
    public void normalmove(Transform side,Transform target,float speed)
    {
       side.position = Vector3.MoveTowards(side.position,target.position,speed*Time.deltaTime);
    }
    
    public void attackmove()
    {
      
    }
  
  }

 }
