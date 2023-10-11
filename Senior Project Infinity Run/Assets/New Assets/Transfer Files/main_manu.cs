using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.SceneManagement;


public class main_manu : MonoBehaviour
{
   public void PlayGame()
    {

        //SceneManager.loadScene(SceneManager.GetActiveSene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
