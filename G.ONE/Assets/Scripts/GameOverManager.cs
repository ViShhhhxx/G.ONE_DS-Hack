using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{

    int score;
    float TimeTaken;

    public GameObject ScoreTxt, TimeTxt;
    public TMP_InputField Name, id, age, weight, height;

    // Start is called before the first frame update
    void Start()
    {
        ScoreTxt.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetInt("Score").ToString();
        TimeTxt.GetComponent<TMPro.TextMeshProUGUI>().text = PlayerPrefs.GetString("Time").ToString();
    }

    public void SaveDataInCSV()
    {
        if(Name.text == "" || id.text == "" || age.text == "" || weight.text == "" || height.text == "")
        {
            Debug.Log("Please fill all the fields");
            return;
        }
        string filePath = $"{Application.streamingAssetsPath}/UserData/User.csv";
        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.Write("Paitient Name,ID,Age,Weight,Height,Score,Time Taken,Game Speed");
                string data = $"{Name.text},{id.text},{age.text},{weight.text},{height.text},{PlayerPrefs.GetInt("Score")},{PlayerPrefs.GetString("Time")},{PlayerPrefs.GetInt("Speed")}";
                sw.Write(data);
                sw.Flush();
                sw.Close();
            }
        }
        else
        {
            StreamReader sr = new StreamReader(filePath);
            string prevData = sr.ReadToEnd();
            sr.Close();
            string data = prevData + $"\n{Name.text},{id.text},{age.text},{weight.text},{height.text},{PlayerPrefs.GetInt("Score")},{PlayerPrefs.GetString("Time")},{PlayerPrefs.GetInt("Speed")}";
            Debug.Log(data);
            Debug.Log($"\n{Name.text},{id.text},{age.text},{weight.text},{height.text},{PlayerPrefs.GetInt("Score")},{PlayerPrefs.GetString("Time")},{PlayerPrefs.GetInt("Speed")}");
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(data);
                sw.Flush();
                sw.Close();
            }

        }

        SceneManager.LoadScene("StartScene");

    }
}
