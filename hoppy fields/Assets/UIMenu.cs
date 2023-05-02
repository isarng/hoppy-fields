using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMenu : MonoBehaviour
{
    // public GameObject menuPanel;

    void Start(){
        Close();
    }

    // void Update(){
    //     ToggleMenu();
    // }

    // public void ToggleMenu(){
    //     if(!menuPanel.activeSelf){
    //         menuPanel.SetActive(true);
    //     }else{
    //         menuPanel.SetActive(false);
    //     }
    // }

    public void OpenMenu(){
        GetComponent<Canvas>().enabled = true;
    }

    public void Close(){
        GetComponent<Canvas>().enabled = false;
    }
}
