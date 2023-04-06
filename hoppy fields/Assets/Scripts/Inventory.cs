using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Inventory
{
    [System.Serializable]
    public class Slot{
        public SeedType type;
        public int count;
        public int maxItems;

        public Slot(){
            type = SeedType.NONE;
            count = 0;
            maxItems = 99;
        }

        public bool CanAddItem(){
            if(count < maxItems){
                return true;
            }

            return false;
        }

        public void AddItem(SeedType type){
            this.type = type;
            count++;
        }

    }    

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots){
        for(int i =0; i < numSlots; i++){
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(SeedType typeToAdd){
        foreach (Slot slot in slots)
        {
            if(slot.type == typeToAdd && slot.CanAddItem()){
                slot.AddItem(typeToAdd);
                return;
            }
        }
        foreach(Slot slot in slots){
            if(slot.type == SeedType.NONE){
                slot.AddItem(typeToAdd);
                return;
            }
        }
    }
}

