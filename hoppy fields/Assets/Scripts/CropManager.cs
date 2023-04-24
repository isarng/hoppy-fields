using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{
    Rosie rosie;
    bool isPlanted = false;
    SpriteRenderer plant;
    int plantStage = 0;
    float timer;

    public PlantObject selectedPlant;
    public SeedType type;
    
    public Sprite icon;

    // public Rigidbody2D rb2d;

    // private void Awake(){
    //     rb2d = GetComponent<Rigidbody2D>();
    // }

    void Start()
    {
        rosie = Rosie.singletonR;
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {   
        if(isPlanted){
            timer -= Time.deltaTime;
            if(timer < 0 && plantStage < selectedPlant.plantStages.Length-1){
                timer = selectedPlant.timerMax;
                plantStage++;
                UpdatePlant();
            }
        } 
    }

    private void OnMouseDown(){
        if(isPlanted){
            if(plantStage == selectedPlant.plantStages.Length - 1){
                Harvest();
                rosie.inventory.Add(this);
            }
        }else{
            Plant();
        }
    } 

    void Harvest(){
        Debug.Log("Harvested");
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void Plant(){
        Debug.Log("Planted");
        isPlanted = true;
        plantStage = 0;
        UpdatePlant();
        timer = selectedPlant.timerMax;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant(){
        plant.sprite = selectedPlant.plantStages[plantStage];
    }
}

public enum SeedType{
    NONE, WHEAT_SEED, BEET_SEED
}
