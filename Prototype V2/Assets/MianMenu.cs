using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MianMenu : MonoBehaviour {

    public Text[] ScoreDisplay;
    public string[] level;
    public bool reset;

    void Start()
    {

        Time.timeScale = 1f;
        //Starts the level with a time scale of one so that it runs at normal time

        if (reset)
        {
            PlayerPrefs.DeleteAll();
            // If reset is selected, all of the saved times are deleted
        }
        Time.timeScale = 1f;
        int position = 0;
        foreach(string levelName in level)
        {
            if (PlayerPrefs.HasKey(levelName))
            {
                ScoreDisplay[position].text = convertTime(PlayerPrefs.GetFloat(levelName));
            }
            else
            {
                ScoreDisplay[position].text = "--:--";
            }
            position++;
            //This stores the times for each level to be displayed on the scoreboard
        }  

        

        

        
    }
    string convertTime(float intial)
    {
        

        string minutes = ((int)intial / 60).ToString();
        string seconds = (intial % 60).ToString();
        if ((intial % 60) < 10)
        {
            seconds = "0" + seconds;
        }
        string newTime = minutes + ":" + seconds.Substring(0, 2);
        Debug.Log(newTime);
        return newTime;
    }


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Loads the next scene in the build settings. Adds one to the index which changes which scene to be loaded. 

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    
}
