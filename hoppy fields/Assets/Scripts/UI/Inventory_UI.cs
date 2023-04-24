using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    
    public GameObject inventoryPanel;

    public Rosie rosie;

    public List<Slots_UI> slots = new List<Slots_UI>();

    // Update is called once per frame
    void Update()
    {
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
            }
        }
    }

    public void Remove(int slotID){
        rosie.inventory.Remove(slotID);
        Refresh();
        // CropManager itemToDrop = GameManager.instance.itemManager.GetItemByType(rosie.inventory.slots[slotID].type);
        // if(itemToDrop != null){
        //     // rosie.DropItem(itemToDrop);
        //     rosie.inventory.Remove(slotID);
        //     Refresh();
        // }
    }
}
