using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    public class FinishScript : MonoBehaviour
    {

        public GameControlScript finish;

        // When an object enters the finish zone, let the
        // game control know that the current game has ended
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag.Equals("player"))
            {
                //SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
                finish.FinishedGame();
            }
        }

    }
}