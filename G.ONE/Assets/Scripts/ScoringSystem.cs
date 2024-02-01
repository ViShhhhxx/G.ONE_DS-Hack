using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public int score = 0;
    public float timer = 0;
    [SerializeField]
    public TextMeshProUGUI text;
    [SerializeField]
    public TextMeshProUGUI timerText;

    public static string finalTime;
    public SFX_handler sfx;

    private void Start()
    {
        sfx = GetComponent<SFX_handler>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "veg")
        {
            sfx.PlayAudio("Point");
            score++;
            text.text = $"Score: {score}";
        }
    }
    private void Update() 
    {
        timer += Time.deltaTime;
       
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);

        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        timerText.text = $"Timer: {niceTime}";
        finalTime = niceTime;
    }

}
