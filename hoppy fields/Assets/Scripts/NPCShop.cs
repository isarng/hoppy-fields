using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShop : MonoBehaviour
{
    public GameObject shopPanel;

    public void ToggleShop(){
        if(!shopPanel.activeSelf){
            shopPanel.SetActive(true);
        }else{
            shopPanel.SetActive(false);
        }
    }

    private void OnMouseDown(){
        ToggleShop();
    }
	
}
