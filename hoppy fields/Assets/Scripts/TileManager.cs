using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{

    [SerializeField] private Tilemap InteractableLand;
    [SerializeField] private Tile interactedTile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool IsInteractable(Vector3Int position){
        TileBase tile = InteractableLand.GetTile(position);

        if(tile != null){
            if(tile.name == "Tilled Dirt_8"){
                return true;
            }
        }
        return false;
    }

    public void SetInteracted(Vector3Int position){
        InteractableLand.SetTile(position, interactedTile);
    }

}
