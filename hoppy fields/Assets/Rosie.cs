using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rosie : MonoBehaviour
{

    Rigidbody2D rbd2;
    public float speed = 2.5f;

    public AnimationStateChanger asc;

    // Start is called before the first frame update
    void Start()
    {
        rbd2 = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector3 offset){
        if(offset != Vector3.zero){
            rbd2.MovePosition(transform.position + ((offset) * speed));
            asc.ChangeAnimationState("Walking");
        }else{
            asc.ChangeAnimationState("Idle");
        }
    }
}

