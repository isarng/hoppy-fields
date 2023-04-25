using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShop : MonoBehaviour
{
    Rosie rosie;
    NPCScript npc;
    public GameObject shopPanel;

    void Start(){
        rosie = Rosie.singletonR;
        npc = NPCScript.singletonNPC;
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
            npc.transform.position);
        if(distance <= 2){
            shopPanel.SetActive(true);
        }else{
            shopPanel.SetActive(false); 
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
