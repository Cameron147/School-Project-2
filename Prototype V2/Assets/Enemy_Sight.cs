using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Sight : MonoBehaviour
{
    public int sight_distance;
    public AudioSource Hello;
    public AudioSource Music;
    public GameObject DeadMenuUI;
    public static bool GameIsPaused = false;
    public LineRenderer LineofSight;
    public float distance;
    // All of the variables are declared here.

    // Use this for initialization
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
        // This starts off the enemy by declaring that the sight is not interacting with anything.
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Flip = Vector3.right;
        // The sight is started off as facing right.
        if (GetComponent<Enemy_Movement>().FacingRight)
        {
            Flip = Vector3.left;
            //If the enemy model is facing right, the sight will also be changed to face the same direction
        }
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Flip, distance);
        if (hitinfo.collider != null){
            
            Debug.DrawLine(transform.position, hitinfo.point, Color.red);
            // Checks whether the sight is in contact with an object, if not, the line which is the sight is displayed as red.

            if (hitinfo.collider.CompareTag("Player"))
            {
                Debug.Log("Dead");
                Camera.main.transform.parent = null;
                Destroy(hitinfo.collider.gameObject);
                // If the player moves into the enemys line of sight, the camera attached to the player as a child is removed so that it is not destroyed along with the player.
               
                
                StartCoroutine(Load());
                // Once the player has been seen, the Load() routine is loaded
                
                
            }
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            // If there is something in the line of sight, the line is set to green 
            


        }
        Vector3 Eyes = new Vector3(0, 0.5f, 0);
        LineofSight.SetPosition(0, transform.position + Eyes);
        Vector3 Change = new Vector3(-3, 0, 0);
        if (!GetComponent<Enemy_Movement>().FacingRight)
        {
            Change = Change * -1;

        }
        LineofSight.SetPosition(1, (transform.position + Change + Eyes));
        //This part flips the line of sight when the player model changes direction, it also determines how long the sight of sight is.
    
        

    }

    IEnumerator Load()
    {
        GetComponent<Enemy_Movement>().moveSpeed = 0f;
        Music.Pause();
        Hello.Play();
        yield return new WaitForSeconds(1.3f);
        //This Load function stops the player moving and pauses the music of the level. It then plays the dead audio, the code then waits for one second before loading the Dead() function.
        Dead();

    }

    void Dead()
    {
        DeadMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Music.Pause();
        //This function then displays the Dead menu and pauses the level entirely by setting the time scale to zero.

    }
}
