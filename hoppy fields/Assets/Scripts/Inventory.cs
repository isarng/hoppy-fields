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

        public Sprite icon;

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

        public void AddItem(CropManager item){
            this.type = item.type;
            this.icon = item.icon;
            count++;
        }

        public void RemoveItem(){
            if(count > 0){
                count--;

                if(count == 0){
                    icon = null;
                    type = SeedType.NONE;
                }
            }
        }

    }    

    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots){
        for(int i =0; i < numSlots; i++){
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(CropManager item){
        foreach (Slot slot in slots)
        {
            if(slot.type == item.type && slot.CanAddItem()){
                slot.AddItem(item);
                return;
            }
        }
        foreach(Slot slot in slots){
            if(slot.type == SeedType.NONE){
                slot.AddItem(item);
                return;
            }
        }
    }

    public void Remove(int index){
        slots[index].RemoveItem();
    }
}

