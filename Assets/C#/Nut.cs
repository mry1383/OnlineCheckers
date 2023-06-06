using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;
public class Nut : MonoBehaviour
{
      Mohre HeadCode;
      earthposition Grid_mode = new earthposition();
    public GameObject leftmove,rightmove,leftattack , rightattack;
    private Grids _Side;
    public bool startmove = false;
    public Vector3 target = new Vector3(0f,0f,0f);
    public int mousenumber = 0 , index = 0,targetnumber;
    public float movespped = 5f;
    public string nutcolor;
   Move nutmove = new Move();
   RectTransform  trans,rightpos,leftpos;
    void Start()
    {
      HeadCode = GameObject.Find("CheckersManagerUI").GetComponent<Mohre>();
      trans = GetComponent<RectTransform>();
      rightpos = rightmove.GetComponent<RectTransform>();
      leftpos = leftmove.GetComponent<RectTransform>();
        deactivemove();
    }

    // Update is called once per frame
    void Update()
    {
         move(startmove);
    }


    // Ged placeNumber as full
  void OnTriggerEnter2D(Collider2D other)
  {
    if(other.tag=="attack")
    {
      other.gameObject.tag="Player";
        Destroy(gameObject);
        
    }
  }
    void OnTriggerStay2D(Collider2D other)
  {
    if(other.tag=="Grid")
    {
      _Side = other.gameObject.GetComponent<Grids>();
      index = _Side.index;
      _Side.mode = nutcolor;
      Grid_mode.MapGridEnabled(index,true);
    }
  }
  void OnTriggerExit2D(Collider2D other)
  {
    if(other.tag=="Grid")
    {
      _Side = other.gameObject.GetComponent<Grids>();
      _Side.mode = "";
    index = _Side.index;
    Grid_mode.MapGridEnabled(index,false);
    print(index + _Side.mode);
    }

  }


  // for nuts move and hide choise nuts;
   public void move(bool start = false)
   {
    if(start==true)
    {
    RectTransform TargetRT = HeadCode.Nutposition[targetnumber].GetComponent<RectTransform>();
    nutmove.normalmove(trans,TargetRT,movespped);
      leftmove.SetActive(false);
      rightmove.SetActive(false);
    if((trans.position.y<=TargetRT.position.y+2)&&(trans.position.y>=TargetRT.position.y-2))
   {startmove = false;}
    }
    else
    {return;}
    }
    public void deactivemove()
    {
      leftmove.SetActive(false);
     rightmove.SetActive(false);
     leftattack.SetActive(false);
     rightattack.SetActive(false);
    }
    


}
