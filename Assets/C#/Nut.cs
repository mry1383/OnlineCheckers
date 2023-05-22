using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;
public class Nut : MonoBehaviour
{
      Mohre HeadCode;
    public GameObject leftmove,rightmove;
    //take side index position;
    private Grids _Side;
    public bool startmove = false;
    public Vector3 target = new Vector3(0f,0f,0f);
    public int mousenumber = 0 , index = 0,targetnumber;
    float movespped = 5f;
   Move nutmove = new Move();
   MohreFuntion targetFinder = new MohreFuntion();
   public RectTransform  trans,rightpos,leftpos;
    void Start()
    {
      HeadCode = GameObject.Find("CheckersManagerUI").GetComponent<Mohre>();
      trans = GetComponent<RectTransform>();
      rightpos = rightmove.GetComponent<RectTransform>();
      leftpos = leftmove.GetComponent<RectTransform>();
     leftmove.SetActive(false);
     rightmove.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         move(startmove);
        if(Input.GetMouseButtonDown(0))
        {
           //mouseClick();
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
  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag=="Grid")
    {
      _Side = other.gameObject.GetComponent<Grids>();
      index = _Side.index;
    }
  }
    void OnTriggerStay2D(Collider2D other)
  {
    if(other.tag=="Grid")
    {
      _Side = other.gameObject.GetComponent<Grids>();
      index = _Side.index;
    }
  }
   public void move(bool start = false)
   {
    if(start)
    {
    RectTransform TargetRT = HeadCode.Nutposition[targetnumber].GetComponent<RectTransform>();
    nutmove.normalmove(trans,TargetRT,movespped);
                         leftmove.SetActive(false);
                     rightmove.SetActive(false);
    }

   }


}
