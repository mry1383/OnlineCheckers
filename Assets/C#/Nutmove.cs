using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;
public class Nutmove : MonoBehaviour
{
    //https://www.linkedin.com/in/mohammadreza-yavari/
    Nutmove attackmove;
    Nut Enemykiller;
    public  Mohre Usercode;
    public GameObject attackpoint ;
    public string targetgobj = "";
    public GameObject boss;
    public Nutsmovemanager.NutsTurn nm;
    public int position_index , enumnumber = 0 ;
    public int targetcolor=0 ;
   public string Mode,Sidepos;
   public bool Attack = false , go=false;
   public Nut head;
   public Grids _Side = null;
    Button btn;
    earthposition erp = new earthposition();
    MohreFuntion funtion = new MohreFuntion();
   Button click;
   Image colorb;
   
    void Start()
    {
         
        Usercode = GameObject.Find("CheckersManagerUI").GetComponent<Mohre>();
        btn = GetComponent<Button>();
        click = GetComponent<Button>();
        colorb = GetComponent<Image>();

    }

    // Update is called once per frame
    void FixedUpdate()
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
        else
        {
            Enemykiller = other.GetComponent<Nut>();
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
         
        //sideposition();
    }
    
    public void Side()
    {
        head.startmove = true;
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
             attackmove = attackpoint.GetComponent<Nutmove>();
             attackmove.Enemykiller = this.Enemykiller;
           
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
    public void Attacked()
    {
            Enemykiller.Die();
           boss.tag = "Player";
    }
    public void attackmode()
    {
          attackmove = attackpoint.GetComponent<Nutmove>();
        print("attack");

         
          colorb.enabled = false;
          btn.enabled = false;
      
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
