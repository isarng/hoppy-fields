using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Rosie : MonoBehaviour
{

    public static Rosie singletonR;

    Rigidbody2D rbd2;
    public float speed = 2.5f;
    public AnimationStateChanger asc;
    SpriteRenderer spriteRenderer;

    public Inventory inventory;

    private void Awake(){
        singletonR = this;
        inventory = new Inventory(21);
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rbd2 = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 offset){
        if(offset != Vector3.zero){
            rbd2.MovePosition(transform.position + ((offset) * speed));

            if(offset.x < 0){
                asc.ChangeAnimationState("WalkingLR");
                spriteRenderer.flipX = true;
            }else if(offset.x > 0){
                asc.ChangeAnimationState("WalkingLR");
                spriteRenderer.flipX = false;
            }else if(offset.y < 0){
                asc.ChangeAnimationState("WalkingD");
            }else if(offset.y > 0){
                asc.ChangeAnimationState("WalkingU");
            }

        }else{
            asc.ChangeAnimationState("Idle");
        }
    }
}

