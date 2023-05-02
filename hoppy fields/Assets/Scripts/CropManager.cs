using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CropManager : MonoBehaviour
{
    Rosie rosie;
    // NPCScript npc;

    public bool isPlanted = false;
    public static bool newBool = false;

    SpriteRenderer plant;
    int plantStage = 0;
    float timer;
    public PlantObject selectedPlant;
    public SeedType type;
    public Sprite icon;

    FarmManager fm;

    public int rosieCash;

    public Text cashText;

// public Rigidbody2D rb2d;

    // private void Awake(){
    //     rb2d = GetComponent<Rigidbody2D>();
// }

    void Start()
    {
        rosie = Rosie.singletonR;
        // npc = NPCScript.singletonNPC;
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

//     if(Input.GetKeyDown(KeyCode.Space)){
    //         Vector3Int position = new Vector3Int((int)rosie.transform.position.x,
    //         (int)rosie.transform.position.y, 0);

    //         if(GameManager.instance.tileManager.IsInteractable(position)){
    //             Debug.Log("woohoo");
    //             // GameManager.instance.tileManager.SetInteracted(position);
    //             if(isPlanted){
    //                 if(plantStage == selectedPlant.plantStages.Length - 1){
    //                     Harvest();
    //                     rosie.inventory.Add(this);
    //                 }
    //             }else{
    //                 Plant();
    //             }
    //         }
    //     }
//}

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
        // newBool = false;
        plant.gameObject.SetActive(false);
    }

    public void Buy(){
        
        // rosie.inventory.Add(this);
            
        
       

        // fm.Transaction(-selectedPlant.buyPrice);
        
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
    NONE, WHEAT, BEET, WHEAT_SEED, BEET_SEED
}
