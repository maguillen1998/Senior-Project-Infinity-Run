using UnityEngine;
using System.Collections;

namespace UnityStandardAssets._2D
{
    public class GameControlScript : MonoBehaviour
    {

        // Place holders to allow connecting to other objects
        public Transform spawnPoint;
        public GameObject player;

        // Flags that control the state of the game
        private float elapsedTime = 0;
        private bool isRunning = false;
        private bool isFinished = false;

        // So that we can access the controller from this whole script
        private Platformer2DUserControl fpsController;


        // Use this for initialization
        void Start()
        {
            // Finds the First Person Controller script on the Player
            fpsController = player.GetComponent<Platformer2DUserControl>();

            // Disables controls at the start.
            fpsController.enabled = false;
        }


        //This resets to game back to the way it started
        private void StartGame()
        {
            elapsedTime = 0;
            isRunning = true;
            isFinished = false;

            // Move the player to the spawn point, and allow it to move.
            player.transform.position = spawnPoint.position;
            fpsController.enabled = true;
        }


        // Update is called once per frame
        void Update()
        {
            // Add time to the clock if the game is running
            if (isRunning)
            {
                elapsedTime += Time.deltaTime;
            }
        }


        // Runs when the player enters the finish zone
        public void FinishedGame()
        {
            isRunning = false;
            isFinished = true;
            fpsController.enabled = false;
        }


        //This section creates the Graphical User Interface (GUI)
        void OnGUI()
        {

            if (!isRunning)
            {
                string message;

                if (isFinished)
                {
                    message = "Click to Play Again";
                }
                else
                {
                    message = "Click to Play";
                }

                Rect startButton = new Rect(Screen.width / 2 - 70, Screen.height / 2, 140, 30);
                if (GUI.Button(startButton, message))
                {
                    //start the game if the user clicks to play
                    StartGame();
                }
            }

            // If the player finished the game, show the final time
            if (isFinished)
            {
                GUI.Box(new Rect(Screen.width / 2 - 65, 185, 130, 40), "Your Time Was");
                GUI.Label(new Rect(Screen.width / 2 - 10, 200, 20, 30), ((int)elapsedTime).ToString());
            }
            else if (isRunning)
            { // If the game is running, show the current time
                GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Your Time Is");
                GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), ((int)elapsedTime).ToString());
            }

        }
    }
}