using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{

    public PlantObject selectPlant;
    public bool isPlanting = false;

    public void SelectPlant(PlantObject newPlant){
        if(selectPlant == newPlant){
            Debug.Log("Deselected " + selectPlant.plantName);
            selectPlant = null;
            isPlanting = false;
        }else{
            selectPlant = newPlant;
            Debug.Log("Selected " + selectPlant.plantName);
            isPlanting = true;
        } 
    }

}
