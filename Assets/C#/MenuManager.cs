using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



namespace Menu.code
{
public class MenuManager : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void OpenScene(int SceneNumber)
    {
       SceneManager.LoadScene(SceneNumber); 
    }

}
}

