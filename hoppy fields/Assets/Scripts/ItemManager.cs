using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public CropManager[] cropItems;

    private Dictionary<SeedType, CropManager> cropItemsDict = new Dictionary<SeedType, CropManager>();

    private void Awake(){
        foreach(CropManager item in cropItems){
            AddItem(item);
        }
    }

    private void AddItem(CropManager item){
        if(!cropItemsDict.ContainsKey(item.type)){
            cropItemsDict.Add(item.type, item);
        }
    }

    public CropManager GetItemByType(SeedType type){
        if(cropItemsDict.ContainsKey(type)){
            return cropItemsDict[type];
        }

        return null;
    }
}
