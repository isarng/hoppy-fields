using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmManager : MonoBehaviour
{

    public PlantObject selectPlant;
    public bool isPlanting = false;
    public Text moneyText;
    public int money = 20;
    

    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "$" + money;
    }


    public void SelectPlant(PlantObject newPlant){
        if(selectPlant == newPlant){
            Debug.Log("Deselected " + selectPlant.plantName);
            selectPlant = null;
            isPlanting = false;
        }else{
        // else if(newPlant.seedy != SeedType.WHEAT || newPlant.seedy != SeedType.BEET){
        // }else if(selectPlant.seedy != SeedType.WHEAT || selectPlant.seedy != SeedType.BEET){
                selectPlant = newPlant;
                Debug.Log("Selected " + selectPlant.plantName);
                isPlanting = true;
        }
            
    }

    public void Transaction(int value){
        money += value;
        moneyText.text = "$" + money;
    }

}
