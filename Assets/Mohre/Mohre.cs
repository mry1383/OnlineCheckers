using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MohreFuntions;
public class Mohre : MonoBehaviour
{

     public GameObject [] Nutposition = new GameObject[65];
     public GameObject BlueNut,RedNut;
     public int nutnumber =0;
     public float posx , posy;
     earthposition Earth =  new earthposition();
     void Start()
    {
       ArrangementPositions();
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ArrangementPositions()
    {
      for(int i=1;i<=8;i++)
      {
         for(int j=1;j<=8;j++)
         {
            string F = i+","+j;
            Nutposition[nutnumber] = GameObject.Find(F);
            nutnumber++; 
         }
         
      }
        SetNutPlayers();
    }
    private void SetNutPlayers()
    {
      //Blue Nut
            for(int i=0;i<24;i+=2)
      {
         //Set NutLine2
         if(i==8)
         {
            i++;
         }
         //Se tNutLine3
         else if(i==17)
         {
            i--;
         }
        GameObject bNut = Instantiate(BlueNut,Nutposition[i].transform.position,transform.rotation);
        bNut.transform.SetParent(transform.Find("Nuts"));
        enabled(i);
      }
      //Red Nut
      for(int i=40;i<64;i+=2)
      {
         //Set Nut Line 2
         if(i==48)
         {
            i++;
         }
         //Set Nut Line 3
         else if(i==57)
        {
            i--;
         }
      GameObject rNut= Instantiate(RedNut,Nutposition[i].transform.position,transform.rotation);
       rNut.transform.SetParent(transform.Find("Nuts"));
       enabled(i);
      }

    }
    //look grid
    public void enabled(int num)
    {
            Earth.MapGridEnabled(num,true);
            bool mode = Earth.gridmode(num);
           Debug.Log(mode);
    }
}
