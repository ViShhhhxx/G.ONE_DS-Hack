using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{

    int score;
    float TimeTaken;

    public GameObject ScoreTxt, TimeTxt;
    // Start is called before the first frame update
    void Start()
    {
        ScoreTxt.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score").ToString();
        TimeTxt.GetComponent<TMPro.TextMeshProUGUI>().text =  PlayerPrefs.GetString("Time").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
