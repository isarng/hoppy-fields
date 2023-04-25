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

    public void SetItem(Inventory.Slot slot){
        if(slot != null){
            itemIcon.sprite = slot.icon;
            itemIcon.color = new Color(1,1,1,1);
            quantityText.text = slot.count.ToString();
            plantyType = slot.plantType;
        }
    }

    public void ChoosePlant(){
        Debug.Log("Chose " + plantyType.plantName);
    }

    public void SetEmpty(){
        itemIcon.sprite = null;
        itemIcon.color = new Color(1,1,1,0);
        quantityText.text = "";
        plantyType = null;
    }


}