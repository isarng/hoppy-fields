using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShop : MonoBehaviour
{
    Rosie rosie;

    public GameObject npcShop;
    public GameObject npcSell;
    public GameObject shopPanel;
    public GameObject sellPanel;

    void Start(){
        rosie = Rosie.singletonR;
    }

    void Update(){
        DisplayShop();
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
	
}
