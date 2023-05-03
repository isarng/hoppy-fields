using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Slots_UI : MonoBehaviour
{
    public Image itemIcon;
    public TextMeshProUGUI quantityText;
    public PlantObject plantyType;
    FarmManager fm;

    public SeedType seedPlant;

    public CropManager plantedOk;

    void Start(){
        fm = FindObjectOfType<FarmManager>();
    }

    public void SetItem(Inventory.Slot slot){
        if(slot != null){
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1,1,1,1);
            quantityText.text = slot.count.ToString();
            plantyType = slot.plantType;
            seedPlant = slot.type;
        }
    }

    public void DecItem(Inventory.Slot slot){
        if(CropManager.newBool == true && slot.plantType == fm.selectPlant){
            slot.RemoveItem();
            quantityText.text = slot.count.ToString();
            if(slot.count==0){
                fm.selectPlant = null;
                fm.isPlanting = false; 
            }
            
            CropManager.newBool = false;
        }

    }

    public void Selling(Inventory.Slot slot){
        if(slot.type != SeedType.NONE){
            if(slot.type == SeedType.WHEAT){
                CropManager.stopSellWheat = false;
                if(CropManager.wheatBool == true){
                    slot.RemoveItem();
                    quantityText.text = slot.count.ToString();
                    CropManager.stopSellWheat = true;
                    CropManager.wheatBool = false;
                }
            }else if(slot.type == SeedType.BEET){
                CropManager.stopSellBeet = false;
                if(CropManager.beetBool == true){
                    slot.RemoveItem();
                    quantityText.text = slot.count.ToString();
                    CropManager.stopSellBeet = true;
                    CropManager.beetBool = false;  
                }   
            } 
        }
    }


    public void ChoosePlant(){
        if(seedPlant != SeedType.WHEAT && seedPlant != SeedType.BEET){
            Debug.Log("Chose " + plantyType.plantName);
            fm.SelectPlant(plantyType);    
        }
        
    }

    public void SetEmpty(){
        itemIcon.sprite = null;
        itemIcon.color = new Color(1,1,1,0);
        quantityText.text = "";
        plantyType = null;
        seedPlant = SeedType.NONE;
    }


}
