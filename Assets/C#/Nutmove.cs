using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;
public class Nutmove : MonoBehaviour
{
    public GameObject boss;
    public Nutsmovemanager.NutsTurn nm;
    earthposition erp = new earthposition();
    MohreFuntion funtion = new MohreFuntion();
   public int position_index , enumnumber = 0;
   public string Mode,Sidepos;
   public bool Attack = false , go=false;
   public Nut head;
   private Grids _Side;
   Button click;
   Image colorb;
    void Start()
    {
       
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
            if(_Side.mode != "")
            {
            gameObject.SetActive(false);
            }
            else
            {
                go = true;
           
                }
        }
    }
    public void Side()
    {
        if(Attack==true)
        {
           boss.tag = "attack";
        }
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
        else
        
         {}
       

    }
    public void Headclick ()
    {
        if(go && Nutsmovemanager.nutTurn == nm)
        {
           gameObject.SetActive(true);
           
        }
    }
}
