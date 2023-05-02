using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{

    // public Text nameTxt;
    // public Text priceTxt;
    // public Sprite icon;

    public PlantObject plant;
    public Image icon;
    FarmManager fm;

    void Start()
    {
        fm = FindObjectOfType<FarmManager>();

        // InitializeUI();
    }

    // public void ChoosePlant(){
    //     Debug.Log("Chose " + plant.plantName);
    //     fm.SelectPlant(this);
    // }
    


    // probably don't need 

    // void InitializeUI(){
    //     // nameTxt.text = plant.plantName;
    //     // priceTxt.text = "$" + plant.price;
    //     // plant = plantType.selectedPlant;
    //     // icon.sprite = plant.icon;
    // }

}
