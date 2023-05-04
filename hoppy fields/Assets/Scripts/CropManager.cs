using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropManager : MonoBehaviour
{
    Rosie rosie;

    public bool isPlanted = false;
    public static bool newBool = false;
    public static bool stopSellBeet = true;

    public static bool stopSellWheat = true;

    public static bool wheatBool = false;

    public static bool beetBool = false;

    SpriteRenderer plant;
    int plantStage = 0;
    float timer;
    public PlantObject selectedPlant;
    public SeedType type;
    public Sprite icon;

    FarmManager fm;

    public int rosieCash;

    public Text cashText;

    void Start()
    {
        rosie = Rosie.singletonR;
        plant = transform.GetChild(0).GetComponent<SpriteRenderer>();
        fm = transform.parent.GetComponent<FarmManager>();
        rosieCash = rosie.playerCash;
        cashText.text = "$" + rosieCash;
    }

    void Update()
    {   
        rosieCash = rosie.playerCash;
        cashText.text = "$" + rosieCash;
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
        }
        else if(fm.isPlanting && fm.selectPlant.buyPrice <= fm.money){
            Plant(fm.selectPlant);
        }
    } 

    void Harvest(){
        Debug.Log("Harvested");
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    public void Buy(){
        
        if(this.type == SeedType.WHEAT_SEED){
            if(rosie.playerCash - this.selectedPlant.buyPrice >= 0){
                rosie.playerCash = rosie.playerCash - this.selectedPlant.buyPrice;
                rosie.inventory.Add(this);
                cashText.text = "$" + rosieCash;
                Debug.Log("Bought Wheat Seed");
                Debug.Log("Rosie cash is now " + rosie.playerCash);    
            }
                
        } else if(this.type == SeedType.BEET_SEED){
            if(rosie.playerCash - this.selectedPlant.buyPrice >= 0){
                rosie.playerCash = rosie.playerCash - this.selectedPlant.buyPrice;
                rosie.inventory.Add(this);
                cashText.text = "$" + rosieCash;
                Debug.Log("Bought Wheat Seed");  
                Debug.Log("Rosie cash is now " + rosie.playerCash);      
            }
             
        }
        
    }

    public void Sell(){
        if(this.type == SeedType.WHEAT && stopSellWheat == false){
            wheatBool = true;
            rosie.playerCash = rosie.playerCash + this.selectedPlant.sellPrice;
            cashText.text = "$" + rosieCash;
            Debug.Log("Sold Wheat Seed");
            Debug.Log("Rosie cash is now " + rosie.playerCash);
        } else if(this.type == SeedType.BEET && stopSellBeet == false){
            beetBool = true;
            rosie.playerCash = rosie.playerCash + this.selectedPlant.sellPrice;
            cashText.text = "$" + rosieCash;
            Debug.Log("Sold Wheat Seed");  
            Debug.Log("Rosie cash is now " + rosie.playerCash);    
        }          
            
    }

    void Plant(PlantObject newPlant){
        selectedPlant = newPlant;
        type = selectedPlant.seedy;
        icon = selectedPlant.icon;
        Debug.Log("Planted");
        isPlanted = true;
        // fm.Transaction(-selectedPlant.buyPrice);
        newBool = true;
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
    NONE, WHEAT, BEET, WHEAT_SEED, BEET_SEED, SUPER_BEET, SUPER_BEET_SEED
}
