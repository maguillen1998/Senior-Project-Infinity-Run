using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class main_manu : MonoBehaviour
{
   public void PlayGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
    }
}
