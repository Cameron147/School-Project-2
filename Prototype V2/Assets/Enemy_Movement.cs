using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public bool FacingRight = true;
    private SpriteRenderer mySpriteRenderer;
    [SerializeField]
    Transform[] waypoints;

    [SerializeField]
    public float moveSpeed = 2f;
    
    int waypointIndex = 0;

    private void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();//This gets the sprite object from Unity
    }


    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;//This sets the starting position of the enemy sprite
    }

    void Update()
    {
        Move();//This calls the function to make the enemy move
        
    }
    
    
        
    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);//This starts the enemy moving

        

        if (transform.position == waypoints[waypointIndex].transform.position) //If the enemy has gone to all of it's waypoints, it starts to move back to the first one
        {
            waypointIndex += 1;
            if (mySpriteRenderer.flipX == true)
            {
                mySpriteRenderer.flipX = false;
                FacingRight = true;
            }
            else
            {
                mySpriteRenderer.flipX = true;
                FacingRight = false;
            }//This part of the code flips the sprite to face the right way when moving
                    
        }

        if (waypointIndex == waypoints.Length)
            waypointIndex = 0;//This resets the waypoint list
            
    }

}