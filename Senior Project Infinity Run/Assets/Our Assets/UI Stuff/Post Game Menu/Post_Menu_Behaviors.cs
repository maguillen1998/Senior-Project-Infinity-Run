using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Post_Menu_Behaviors : MonoBehaviour
{
    //hardcoded, will break if scene name changes
    string RootScenename = "(New main game)Scene Test Level Generation 1";
    //NOTE: Marco here, I moved this scrip from the Canvas gameobject into it's own gameobject called Menu Functions
    public void RetryGame()
    {
        SceneManager.LoadScene(RootScenename);
    }

    public void QuitGame()
    {
        //Exits the game only in the build. will not exit form unity editor
        Application.Quit();

        //exits the game on the editor
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void LaunchSurvey()
    {
        Application.OpenURL("https://docs.google.com/forms/d/17H-KB6No1pkcpq6llogqmhUgqhn07S7n0Bylq8YYiUc/edit#settings");        
    }
}
