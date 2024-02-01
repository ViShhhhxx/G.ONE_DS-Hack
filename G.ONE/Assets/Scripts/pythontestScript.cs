using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Python.Runtime;
using System;

public class pythontestScript : MonoBehaviour
{
    dynamic np;

    // Start is called before the first frame update
    void Start()
    {

        Runtime.PythonDLL = Application.dataPath + "/StreamingAssets/Python-3.7.9/python37.dll";
        PythonEngine.Initialize();

        try
        {
            np = PyModule.Import("numpy");
            print("pi: " + np.pi);
        }catch (Exception e)
        {
            print(e);
            print(e.StackTrace);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnApplicationQuit()
    {
        if(PythonEngine.IsInitialized)
        {
            PythonEngine.Shutdown(ShutdownMode.Reload);
        }
    }
}
