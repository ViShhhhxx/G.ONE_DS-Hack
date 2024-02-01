using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SceneChange : MonoBehaviour
{

// C:\Users\Infer\OneDrive\Documents\Unity projects\MotionCapture\MotionCapture\Assets\StreamingAssets\PythonScripts\MoCap.py

// C:\Users\Infer\OneDrive\Documents\Unity projects\MotionCapture\MotionCapture\Assets\StreamingAssets\Python-3.7.9\python.exe

    public void ChangeScene(string name)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(name);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
