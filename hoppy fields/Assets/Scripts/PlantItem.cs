using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantItem : MonoBehaviour
{
    public PlantObject plant;

    public CropManager plantType;

    // public Text nameTxt;
    // public Text priceTxt;
    public Image icon;
    // public Sprite icon;

    // Start is called before the first frame update
    void Start()
    {
        // nameTxt.text = plant.plantName;
        // priceTxt.text = "$" + plant.price;
        // plant = plantType.selectedPlant;
        // icon.sprite = plant.icon;
    }

    // public void ChoosePlant(){
    //     Debug.Log("Chose " + plant.plantName);
    // }

}
