using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Post_Menu_Behaviors : MonoBehaviour
{
    string RootScenename = "Scene Test Level Generation";
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
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
