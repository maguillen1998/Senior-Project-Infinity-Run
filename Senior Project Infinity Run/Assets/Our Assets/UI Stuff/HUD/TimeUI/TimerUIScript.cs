using System.Collections;
using System.Collections.Generic;
using TMPro; //not sure why it isnt being picked up by visual studio. the code runs fine in unity
using UnityEngine;


//tip: if the Canvas is showing in game, its prolly because gizmos are on in the game view.

public class TimerUIScript : MonoBehaviour
{
    private void Update()
    {
        UpdateDisplayedTime();
    }
    public void UpdateDisplayedTime()
    {
        //set coin count to players coin collected value.
        //not sure why it isnt being picked up by visual studio. the code runs fine in unity
        this.gameObject.GetComponent<TMP_Text>().text = Time.timeSinceLevelLoad.ToString("F2")+"s";
    }
}
