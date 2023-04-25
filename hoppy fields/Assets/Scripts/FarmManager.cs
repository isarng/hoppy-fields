using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmManager : MonoBehaviour
{

    public PlantObject selectPlant;
    public bool isPlanting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
