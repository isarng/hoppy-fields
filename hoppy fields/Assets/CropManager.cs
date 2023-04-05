using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropManager : MonoBehaviour
{

    bool isPlanted = false;
    public SpriteRenderer plant;

    public Sprite[] plantStages;
    int plantStage = 0;

    float timerMax =  2f;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isPlanted){
            timer -= Time.deltaTime;
            
            if(timer < 0 && plantStage < plantStages.Length-1){
                timer = timerMax;
                plantStage++;
                UpdatePlant();
            }
        }
        

    }

    private void OnMouseDown(){
        if(isPlanted){
            if(plantStage == plantStages.Length - 1){
                Harvest();
                //run some function to display harvested plant icon?
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
        timer = timerMax;
        plant.gameObject.SetActive(true);
    }

    void UpdatePlant(){
        plant.sprite = plantStages[plantStage];
    }
}
