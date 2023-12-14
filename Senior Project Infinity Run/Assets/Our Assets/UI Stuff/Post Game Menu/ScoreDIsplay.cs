using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDIsplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UpdateDiplay();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void UpdateDiplay()
    {
        
        int timeElapsed = Mathf.FloorToInt(Time.timeSinceLevelLoad);
        int coinsCollected = GameObject.FindGameObjectWithTag("Player").GetComponent<Medieval_Warrior_Stats>().CoinsCollected;
        int score = timeElapsed * coinsCollected;

        GameObject scoreDisplay = transform.Find("Score/Canvas/Text (TMP)").gameObject;
        GameObject timeDisplay = transform.Find("Time Elapsed/Canvas/Text (TMP)").gameObject;
        GameObject coinsDisplay = transform.Find("Coins Collected/Canvas/Text (TMP)").gameObject;

        scoreDisplay.GetComponent<TMP_Text>().text = (timeElapsed * coinsCollected).ToString();
        timeDisplay.GetComponent<TMP_Text>().text = Time.timeSinceLevelLoad.ToString("F2") + "s";
        coinsDisplay.GetComponent<TMP_Text>().text = (coinsCollected).ToString();

    }
}
