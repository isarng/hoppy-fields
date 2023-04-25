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
        // selectedPlant = PlantObject.planty;
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

    // void OnTriggerEnter2D(Collider2D other){

    //     rosie = other.GetComponent<Rosie>();
    //     if(rosie){
    //        if(other.gameObject.tag == "beetseed"){
    //            PickOrReceive(); 
    //     }  
    //     }

        
    //}

    // private void OnTriggerEnter2D(Collider2D collision){
    //     if(this.tag == "beetseed"){
    //         PickOrReceive();
    //     }
    // }


    private void OnMouseDown(){

        if(isPlanted){
            if(plantStage == selectedPlant.plantStages.Length - 1){
                Harvest();
                rosie.inventory.Add(this);
            }
        }else if(tag == "beetseed"){
            Debug.Log("seed");
            // rosie.inventory.Add(this);
            PickOrReceive();
        }else{
            Plant();
        }
    } 

    void Harvest(){
        Debug.Log("Harvested");
        isPlanted = false;
        plant.gameObject.SetActive(false);
    }

    void PickOrReceive(){
        rosie.inventory.Add(this);
        Debug.Log("Picked up");
        Destroy(this.gameObject);

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
    NONE, WHEAT, BEET, WHEAT_SEED, BEET_SEED
}
