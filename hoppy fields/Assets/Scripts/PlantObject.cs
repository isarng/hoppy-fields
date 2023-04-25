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
    public int price;
    public Sprite icon;
    // public int harvestedPlant;
    public SeedType seedy;

    // private void Awake(){
    //     planty = this;
    // }

}
