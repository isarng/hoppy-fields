using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    public Rosie rosie;
    // Update is called once per frame
    void FixedUpdate()
    {
        rosie.Move(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Time.fixedDeltaTime);
    }
}
