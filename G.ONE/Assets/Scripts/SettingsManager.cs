using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsManager : MonoBehaviour
{
    public Slider speedSlider;
    public TextMeshProUGUI speedText;

    private void Update()
    {
        speedText.text = speedSlider.value.ToString();
    }
    public void setSpeed()
    {
        PlayerPrefs.SetInt("Speed", Mathf.RoundToInt(speedSlider.value));
        UnityEngine.SceneManagement.SceneManager.LoadScene("StartScene");
    }
}
