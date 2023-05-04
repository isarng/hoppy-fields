using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShop : MonoBehaviour
{
    Rosie rosie;
    // NPCScript npc;

    public GameObject npcShop;
    public GameObject npcSell;
    public GameObject shopPanel;
    public GameObject sellPanel;

    void Start(){
        rosie = Rosie.singletonR;
        // npc = NPCScript.singletonNPC;
    }

    void Update(){
        DisplayShop();
        // float distance = Vector3.Distance (rosie.transform.position, 
        //     npc.transform.position);
        // if(distance <= 2){
        //     shopPanel.SetActive(true);
        // }else{
        //     shopPanel.SetActive(false); 
        // }
    }

    public void DisplayShop(){
        float distance = Vector3.Distance (rosie.transform.position, 
            npcShop.transform.position);
        float distance2 = Vector3.Distance (rosie.transform.position, 
            npcSell.transform.position);
        if(distance <= 2){
            shopPanel.SetActive(true);
        }else{
            shopPanel.SetActive(false); 
        }

        if(distance2 <= 2){
            sellPanel.SetActive(true);
        }else{
            sellPanel.SetActive(false);
        }
    }

// public void ToggleShop(){
    //     if(!shopPanel.activeSelf){
    //         shopPanel.SetActive(true);
    //     }else{
    //         shopPanel.SetActive(false);
    //     }
// }

// private void OnMouseDown(){
    //     float distance = Vector3.Distance (rosie.transform.position, 
    //         npc.transform.position);
    //     if(distance <= 2){
    //         ToggleShop();    
    //     }
// }
	
}
