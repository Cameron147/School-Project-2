using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    public CharacterController2D1 controller;

    public float runSpeed = 40f;

    public float height;

    public float horizontalMove = 0f;



    bool RaycastDown()
    {
        Vector2 pos = gameObject.transform.position;
        pos.y = pos.y - (height / 2) - 0.05f;


        bool result = Physics2D.Raycast(pos, Vector2.down, 0.1f).collider != null;
        return result;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("w") && RaycastDown())
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, horizontalMove), ForceMode2D.Impulse);
        }


        if (Input.GetKey("a") && !Input.GetKey("d"))
        {
            controller.Move(-runSpeed, false, false);

        }
        if (Input.GetKey("d") && !Input.GetKey("a"))
        {
            controller.Move(runSpeed, false, false);
        }


    }

    void FixedUpdate()
    {


        // Move our Character

        //controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        //jump = false;
    }
}
