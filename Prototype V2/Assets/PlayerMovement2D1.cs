using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement2D1 : MonoBehaviour
{
    public float Width; //

    public CharacterController2D1 controller;

    public float runSpeed = 40f;

    public float height;

    public Animator animator;

    public float horizontalMove = 0f;

    public Text Win;

    public Text TimerText;

    private float StartTime;

    public string NextLevel;

    public string currentLevelFastest;
    //These are all the variables used in my program

    void Start()
    {
        StartTime = Time.time;
        Time.timeScale = 1f;
        //This part starts off the time recorder in the program  
    }



    private void OnTriggerEnter2D(Collider2D collider)
    
    {
        
        if (collider.gameObject.CompareTag("Finish"))
        {
            Debug.Log("Win");
            Win.gameObject.SetActive(true);
            float timeTaken = Time.time - StartTime; //This part of the code finds the total time taken to complete the level
            if (PlayerPrefs.HasKey(currentLevelFastest))//This checks whether the program already has a fastest time attached to it.
            {
                if (PlayerPrefs.GetFloat(currentLevelFastest) > timeTaken)// If the recorded level time is more than the current fastest time for that level, then the current time is not changed
                {
                    PlayerPrefs.SetFloat(currentLevelFastest, timeTaken);//This is where the current time is set to remain the same
                }
            }
            else
            {
                PlayerPrefs.SetFloat(currentLevelFastest, timeTaken);
            }
            PlayerPrefs.Save();// This is where the new fastest time is set in the level.

            StartCoroutine(Load());// Once the level has been won, this co routine is run and the next level is loaded
            
        }

    }

    IEnumerator Load() // Wait function
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(NextLevel);// This is the co routine that loads the next scene in the game
    }


    bool RaycastDown()
    {

        Vector2 wid = new Vector2(Width/2f, 0f);//This calculates the width of the player


        Vector2 pos = gameObject.transform.position;
        pos.y = pos.y - (height / 2) - 0.05f;


        bool result = Physics2D.Raycast(pos + wid, Vector2.down, 0.1f).collider != null;
        bool result2 = Physics2D.Raycast(pos - wid, Vector2.down, 0.1f).collider != null;//These calculates whether the player in in contact with the ground or the ceiling
        Debug.DrawLine(pos + wid, pos + wid + Vector2.down);
        Debug.DrawLine(pos - wid, pos - wid + Vector2.down);//These draw a line when in scene mode

        return result || result2;//This returns the two calculated values
    }


    // Update is called once per frame
    void Update()
    {
        Vector2 wid = new Vector2(Width / 2f, 0f);//This again calculates the width of the player


        Vector2 pos = gameObject.transform.position;//This finds the position of the player
        pos.y = pos.y - (height / 2) - 0.05f;//This calcultes the y position of the player
        Debug.DrawLine(pos + wid, pos + wid + Vector2.down);

        float t = Time.time - StartTime;//This finds the total time taken for the level so that it can be displayed in the corner of the screen.
        string minutes = ((int)t / 60).ToString();//This calculates the minutes of the timer
        string seconds = (t % 60).ToString();//This calculates the seconds of the timer
        if ((t % 60) < 10)
        {
            seconds = "0" + seconds;//If the amount of time is less than 1 minute, then it is set as seconds
        }
        TimerText.text = minutes + ":" + seconds.Substring(0, 2);//This displays the time in the corner of thescreen
        



        Debug.Log(RaycastDown());

        if (Input.GetKeyDown("w") && RaycastDown())//This is the jumping function, it checks whether the 'W' has been pressed and the uses the result of Raycastdown
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, horizontalMove), ForceMode2D.Impulse);//This makes the player jump
            Debug.Log("Jump");
        }

        


        if (Input.GetKey("a") && !Input.GetKey("d"))//This checks whether the 'A' key and not the 'D' key has been pressed 
        {
            controller.Move(-runSpeed, false, false);//This makes the player move left
            animator.SetFloat("Speed",runSpeed);//This starts the running animation
            
        }else if (!Input.GetKey("a") && !Input.GetKey("d"))
            animator.SetFloat("Speed", 0);//This stops the player moving and stops the running animation

        if (Input.GetKey("d") && !Input.GetKey("a"))//This checks whether the 'D' key and not the 'A' key has been pressed 
        {
            controller.Move(runSpeed, false, false);//This makes the player move right
            animator.SetFloat("Speed",runSpeed);//This starts the running animation
            
        }else if (!Input.GetKey("a") && !Input.GetKey("d"))
            animator.SetFloat("Speed", 0);//This stops the layer moving and stops the running animation




    }

   


    void FixedUpdate()
    {


        // Move our Character

        //controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        //jump = false;
    }
}
