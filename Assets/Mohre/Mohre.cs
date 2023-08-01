using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MohreFuntions;
public class Mohre : MonoBehaviour
{
      public Grids gg = new Grids();
     public GameObject [] Nutposition = new GameObject[65];
     public GameObject BlueNut,RedNut;
     public int nutnumber =0;
     public float posx , posy;
     earthposition Earth =  new earthposition();
     private static Mohre instance;

     
    public static Mohre Instance
    {
        get
        {
            
            if (instance == null)
            {
                instance = FindObjectOfType<Mohre>();

                 
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("SingletonExample");
                    instance = singletonObject.AddComponent<Mohre>();
                }

                
                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }

    
    public void TestMethod()
    {
        Debug.Log("TestMethod called!");
    }
     void Start()
    {
       ArrangementPositions();
 
    }

     
    void Update()
    {
       
    }
    public void getnamegrid(int index ,GameObject trageted,Grids _side)
    {
      Grids g;
      for(int i=1;i<=8;i++)
      {
         for(int j=1;j<=8;j++)
         {
            string F;
             F = i+","+j;
           // F = i.ToString();
           g= GameObject.Find(F).GetComponent<Grids>();
           if(g.index==index)
           {
            GameObject geted =GameObject.Find(F);
             trageted.transform.position = geted.transform.position;
             gg = g;
             
             print("Grid :"+ g.index);
           }
           else{
            //print("G:"+F+"index:"+g.index);
            
            }
            nutnumber++; 
         }
         
      }
    }
    private void ArrangementPositions()
    {
      for(int i=1;i<=8;i++)
      {
         for(int j=1;j<=8;j++)
         {
            string F;
             F = i+","+j;
           // F = i.ToString();
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
        enabledd(i);
      }
      //Red Nut
      for(int i=41;i<64;i+=2)
      {
         //Set Nut Line 2
         if(i==49)
         {
            i--;
         }
         //Set Nut Line 3
         else if(i==56)
        {
            i++;
         }
      GameObject rNut= Instantiate(RedNut,Nutposition[i].transform.position,transform.rotation);
       rNut.transform.SetParent(transform.Find("Nuts"));
       enabledd(i);
      }

    }
    //look grid
    public void enabledd(int num)
    {
            Earth.MapGridEnabled(num, true);
            bool mode = Earth.gridmode(num);
        
    }
     
}
