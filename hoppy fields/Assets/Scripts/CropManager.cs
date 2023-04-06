using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{

    bool isPlanted = false;
    SpriteRenderer plant;
    int plantStage = 0;
    float timer;

    public PlantObject selectedPlant;

    public SeedType type;

    void Start()
    {
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

    // private void OnTriggerEnter2D(Collider2D collision){
    //     Rosie rosie = collision.gameObject.GetComponent<Rosie>();
        
    //     if(isPlanted){
    //         if(plantStage == selectedPlant.plantStages.Length-1){
                
    //                 Harvest();
    //                 rosie.inventory.Add(type);
                
    //         }else{
    //             Plant();
    //         }
    //     }
    // }


    private void OnMouseDown(){
        if(isPlanted){
            if(plantStage == selectedPlant.plantStages.Length - 1){
                Harvest();
                // Collider mycollider = GetComponent<Collider>();
                // Rosie rosie = mycollider.GetComponent<Rosie>();
                // rosie.inventory.Add(type);
            }
                // selectedPlant.harvestedPlant++;
                //run some function to display harvested plant icons
        }else{
            Plant();
        }
    } 


    // void Clicking(){
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //      // Cast a ray from the camera to where you clicked
    //      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
    //      // If the raycast hit something..
    //      if (Physics.Raycast(ray, out RaycastHit hit))
    //      {
    //         GameObject hitObject = hit.collider.gameObject;
    //         selectedPlant.gameObject = hitObject;
    //         if(isPlanted){
    //             if(plantStage == selectedPlant.plantStages.Length - 1){
    //                 Harvest();
    //                 // rosie.inventory.Add(type);
    //             }
    //                 // selectedPlant.harvestedPlant++;
    //                 //run some function to display harvested plant icons
    //         }else{
    //             Plant();
    //         }
    //       }
    //     }
    // }

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
