using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;
public class Nutmove : MonoBehaviour
{
   Button btn;
  public  Mohre Usercode;
    public GameObject attackpoint ;
    public string targetgobj = "";
    public GameObject boss;
    public Nutsmovemanager.NutsTurn nm;
    earthposition erp = new earthposition();
    MohreFuntion funtion = new MohreFuntion();
   public int position_index , enumnumber = 0 ;
   public string Mode,Sidepos;
   public bool Attack = false , go=false;
   public Nut head;
   public Grids _Side = null;
   Button click;
   Image colorb;
   public int targetcolor=0 ;
    void Start()
    {
         
        Usercode = GameObject.Find("CheckersManagerUI").GetComponent<Mohre>();
        btn = GetComponent<Button>();
        click = GetComponent<Button>();
        colorb = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Grid")
        {  
            _Side = other.gameObject.GetComponent<Grids>();
        if(_Side==null)
        {
             sideposition();   
        }
       
            showLayer();
            
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
         
        //sideposition();
    }
    
    public void Side()
    {
        if(Attack==true)
        {
           boss.tag = "attack";
           head.movespped =20;
        }
        else{   head.movespped =12;  }
        bool Gridmode = erp.gridmode(head.index);

        if(go == true)
        {
       int position = funtion.NutsMoveposition(head.index,Mode,Attack,Sidepos);
       print(position);
       head.targetnumber = position;
       head.index = position_index;
       head.startmove=true;
       head.move(true);
       Nutsmovemanager.Turn();
       print (Gridmode);
       head.deactivemove();
        
        }
        else{}
    }
    public void Headclick ()
    {
        sideposition();
         targetcolor =  _Side.gameObject.layer;
        if(go && Nutsmovemanager.nutTurn == nm && Attack == false)
        {
           btn.enabled = true;
           colorb.enabled = true;
           showLayer();
           
        }

    }
    // for Get Layer Value Grid map
    private void showLayer()
    {

          // print(_Side);
         // print(_Side.gameObject.layer);
           targetcolor =  _Side.gameObject.layer;
           //enemy on the grid
            if(head.gameObject.layer != targetcolor && targetcolor !=5)
            {
                
                attackmode();
                
           // _Side = null;
            }
            else if (head.gameObject.layer == targetcolor)
            {
                btn.enabled = false;
                colorb.enabled = false;
            }
            else
            {
                go = true;
            }

    }
    ////////////////////////////////
    public void sideposition()
    {
             position_index = funtion.NutsMoveposition(head.index,Mode,Attack,Sidepos);
             Usercode.getnamegrid(position_index,gameObject,_Side);
            _Side= Usercode.gg;
              print(_Side);     
    }
    public void attackmode()
    {
        
        print("attack");
         attackpoint.SetActive(true);
          colorb.enabled = false;
          btn.enabled = false;
       Nutmove attackmove = attackpoint.GetComponent<Nutmove>();
       attackmove.position_index  = funtion.NutsMoveposition(head.index,Mode,true,Sidepos);
       if(attackmove.targetcolor ==5)
       { 
       attackmove.btn.enabled = true;
       attackmove.colorb.enabled = true;

       }
       else
       {
        attackmove.btn.enabled = false;
       attackmove.colorb.enabled = false;
       }

    }
}
