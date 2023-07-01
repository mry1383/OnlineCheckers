using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MohreFuntions;
using UnityEngine.UI;

public class Nut : MonoBehaviour
{
   Nutsmovemanager.NutsTurn nm;
  private AudioSource soundplayer;
  public AudioClip die,moved;
   public Animator anim;
  public GameObject die_effect;
    public string uitag ;
     uiplayer healthdamaged;
      Mohre HeadCode;
      earthposition Grid_mode = new earthposition();
    public GameObject leftmove,rightmove,leftattack , rightattack;
    private Grids _Side;
    public bool startmove = false;
    public Vector3 target = new Vector3(0f,0f,0f);
    public int mousenumber = 0 , index = 0,targetnumber;
    public float movespped = 5f;
    //choises
   Button []btn = new Button [4];
   Image []img = new Image [4];
   Move nutmove = new Move();
   RectTransform  trans,rightpos,leftpos;
   Nutmove [] btncode = new Nutmove [4];
    void Start()
    {
      
      soundplayer = GetComponent<AudioSource>();
      die_effect.SetActive(false);
      healthdamaged = GameObject.FindGameObjectWithTag(uitag).GetComponent<uiplayer>();
      print((gameObject.name+"(Clone)UI"));
      HeadCode = GameObject.Find("CheckersManagerUI").GetComponent<Mohre>();
      trans = GetComponent<RectTransform>();
      rightpos = rightmove.GetComponent<RectTransform>();
      leftpos = leftmove.GetComponent<RectTransform>();
        startchoise();
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
      Nutsmovemanager.Turn();
      soundplayer.PlayOneShot(die);
      anim.SetBool("die",true);
      die_effect.SetActive(true);
      healthdamaged.Damage();
      GameObject map_panel = GameObject.Find("MapPanel");
      Animator shake = map_panel.GetComponent<Animator>();
      shake.SetTrigger("shake");
      other.gameObject.tag="Player";
        Destroy(gameObject,0.25f);
        
    }

  }
    void OnTriggerStay2D(Collider2D other)
  {
    if(other.tag=="Grid")
    {
      _Side = other.gameObject.GetComponent<Grids>();
      index = _Side.index;
      _Side.mode = gameObject.layer;
      other.gameObject.layer = gameObject.layer;
      print(_Side.mode);
      Grid_mode.MapGridEnabled(index,true);

    }
  }

  void OnTriggerExit2D(Collider2D other)
  {
    if(other.tag=="Grid")
    {
      soundplayer.PlayOneShot(moved);
      other.gameObject.layer = 5;
      _Side = other.gameObject.GetComponent<Grids>();
      _Side.mode = 5;
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
      Playermove();
    RectTransform TargetRT = HeadCode.Nutposition[targetnumber].GetComponent<RectTransform>();
    nutmove.normalmove(trans,TargetRT,movespped);
     btn[0].enabled = btn[1].enabled =false;
     img[0].enabled = img[1].enabled =false;
    if((trans.position.y<=TargetRT.position.y+2)&&(trans.position.y>=TargetRT.position.y-2))
   {startmove = false;}
    }
    else
    {return;}
    }
    public void deactivemove()
    {
     btn[0].enabled = btn[1].enabled = btn[2].enabled = btn[3].enabled = false;
     img[0].enabled = img[1].enabled = img[2].enabled = img[3].enabled = false;
    }
    public void startchoise()
    {
     btn[0]= leftmove.GetComponent<Button>();
     btn[1]= rightmove.GetComponent<Button>();
     btn[2]= leftattack.GetComponent<Button>();
     btn[3]= rightattack.GetComponent<Button>();
     img[0]= leftmove.GetComponent<Image>();
     img[1]= rightmove.GetComponent<Image>();
     img[2]= leftattack.GetComponent<Image>();
     img[3]= rightattack.GetComponent<Image>();
     btncode[0]= leftmove.GetComponent<Nutmove>();
     btncode[1]= rightmove.GetComponent<Nutmove>();
     btncode[2]= leftattack.GetComponent<Nutmove>();
     btncode[3]= rightattack.GetComponent<Nutmove>();
    }
    public void Playermove()
    {
      btn[0].enabled = btn[1].enabled = btn[2].enabled = btn[3].enabled = false;
      img[0].enabled = img[1].enabled = img[2].enabled = img[3].enabled = false;
    }


}
