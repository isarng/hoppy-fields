using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Plant", menuName = "Plant")]

public class PlantObject : ScriptableObject
{
    // public static PlantObject planty;
    public string plantName;
    public Sprite[] plantStages;
    public float timerMax;
    public int buyPrice;
    public int sellPrice;
    public Sprite icon;
    // public int harvestedPlant;
    public SeedType seedy;

    // FarmManager fm;
    // public Rigidbody2D rbd2;

    // private void Awake(){
    //     planty = this;
    // }

    // void Start(){
    //     fm = FindObjectOfType<FarmManager>();

    // }

}
