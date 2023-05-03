using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    
    public GameObject inventoryPanel;

    public Rosie rosie;

    public CropManager plantedOk;

    public List<Slots_UI> slots = new List<Slots_UI>();

    void Update()
    {
        Refresh();
        if (Input.GetKeyDown(KeyCode.Tab)) {
            ToggleInventory();    
        }
    }

    public void ToggleInventory(){
        if(!inventoryPanel.activeSelf){
            inventoryPanel.SetActive(true);
            Refresh();
        }else{
            inventoryPanel.SetActive(false);
        }
    }

    void Refresh(){
        if(slots.Count == rosie.inventory.slots.Count){
            for(int i = 0; i < slots.Count; i++){
                if(rosie.inventory.slots[i].type != SeedType.NONE){
                    slots[i].SetItem(rosie.inventory.slots[i]);
                }else{
                    slots[i].SetEmpty();
                }
                slots[i].Selling(rosie.inventory.slots[i]);
                slots[i].DecItem(rosie.inventory.slots[i]);
                
            }
        }
    }


    public void Remove(int slotID){
        rosie.inventory.Remove(slotID);
        Refresh();
    }
}
