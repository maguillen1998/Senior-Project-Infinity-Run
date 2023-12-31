using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_Behaviors : MonoBehaviour
{
    //NOTE: Marco here, I moved this scrip from the Canvas gameobject into it's own gameobject called Menu Functions
   public void PlayGame()
    {   
        //hardcoded, will break if scene name changes
        SceneManager.LoadScene("(New main game)Scene Test Level Generation 1");
    }
   public void GoToOptions()
    {
        GameObject mainMenu = this.gameObject.transform.parent.Find("Canvas/Main Menu").gameObject;
        GameObject optionsMenu = this.gameObject.transform.parent.Find("Canvas/options menu").gameObject;

        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void GoToMainMenu()
    {
        GameObject mainMenu = this.gameObject.transform.parent.Find("Canvas/Main Menu").gameObject;
        GameObject optionsMenu = this.gameObject.transform.parent.Find("Canvas/options menu").gameObject;

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
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
