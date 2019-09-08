using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BttnScript : MonoBehaviour
{
   public GameObject panel;   
       
    public void BttnReset()
    {
        Application.LoadLevel(1);
        Time.timeScale = 1;
    }   


    private void Update()
    {       

        if (Input.GetKey("escape"))
        {          
            Debug.Log("menu");
            Time.timeScale = 0;
            panel.SetActive(true);       
        }      
        
    }

    public void BttnCon()
    {   
        Debug.Log("menu is close");
        Time.timeScale = 1;
        panel.SetActive(false);
    }

    public void StartBttn()
    {
        Application.LoadLevel(1);
    }

    public void BttnPause()
    {
        Time.timeScale = 0;
    }

    public void QuitBttn()
    {
        Application.Quit();
    }

}


