using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;
public class Nutmove : MonoBehaviour
{
   Button btn;
    public GameObject attackpoint;
    public GameObject boss;
    public Nutsmovemanager.NutsTurn nm;
    earthposition erp = new earthposition();
    MohreFuntion funtion = new MohreFuntion();
   public int position_index , enumnumber = 0;
   public string Mode,Sidepos;
   public bool Attack = false , go=false;
   public Nut head;
   public Grids _Side;
   Button click;
   Image colorb;
   public int targetcolor ;
    void Start()
    {
        
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
            showLayer();
            sideposition(true);
        }
        
    }
    void OnTriggerExit2D(Collider2D other)
    {
         
        
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
           print(_Side);
           print(_Side.gameObject.layer);
           targetcolor =  _Side.gameObject.layer;
            if(gameObject.layer != targetcolor && targetcolor !=5)
            {
            
            if(Attack == false)
            {
                print("attack");
                attackpoint.SetActive(true);
                colorb.enabled = false;
                btn.enabled = false;
            }
            _Side = null;
            }
            else if (gameObject.layer == targetcolor)
            {
                btn.enabled = false;
                colorb.enabled = false;
            }
            else
            {
                go = true;
            }

    }
    public void sideposition( bool Stay)
    {
           transform.position =_Side.transform.position;
    }
}
