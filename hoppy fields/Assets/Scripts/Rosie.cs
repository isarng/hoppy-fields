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
        inventory = new Inventory(20);
    }



    // public void DropItem(CropManager item){
    //     Vector3 spawnLocation = transform.position;

    //     // spawn buffer
    //     float randomX = Random.Range(-1f, 1f);
    //     float randomY = Random.Range(-1f, 1f);

    //     Vector3 spawnOffset = new Vector3(randomX, randomY, 0f).normalized;

    //     CropManager droppedItem = Instantiate(item, spawnLocation + spawnOffset, Quaternion.identity);

    //     droppedItem.rb2d.AddForce(spawnOffset * .2f, ForceMode2D.Impulse);
    // }

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

