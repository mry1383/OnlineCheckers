using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class uiplayer : MonoBehaviour
{
       public Image health;
       public TMP_Text haelthvalue;
       int currenthealth = 8 , fullhealth =100;

     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void  Damage()
    {
         
       health.fillAmount -= 0.1f;
       fullhealth-=10;
        haelthvalue.text = fullhealth.ToString()+"%";
         
    }
}
