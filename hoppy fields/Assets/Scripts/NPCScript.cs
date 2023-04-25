using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public static NPCScript singletonNPC;
    Rigidbody2D rbd2;
    SpriteRenderer spriteRenderer;

    private void Awake(){
        singletonNPC = this;
    }
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbd2 = GetComponent<Rigidbody2D>();
    }

}
