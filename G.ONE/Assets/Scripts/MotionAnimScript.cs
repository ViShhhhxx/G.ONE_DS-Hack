using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Threading;

public class MotionAnimScript : MonoBehaviour
{

    public GameObject body;
    public GameObject[] bodyLM;

    List<string> lines;

    int counter = 0;

    private void Awake()
    {
        bodyLM = new GameObject[body.transform.childCount];
        for (int i = 0; i < body.transform.childCount; i++)
        {
            bodyLM[i] = body.transform.GetChild(i).gameObject;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        lines = System.IO.File.ReadLines("Assets/AnimationFile.txt").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        Animate();
    }


    public void Animate()
    {
        string[] points = lines[counter].Split(',');

        for (int i = 0; i <= 32; i++)
        {
            //Debug.Log(points[0 + i * 3]);
            float x = float.Parse(points[0 + i * 3]) / 100;
            float y = float.Parse(points[1 + i * 3]) / 100;
            float z = float.Parse(points[2 + i * 3]) / 300;

            bodyLM[i].transform.localPosition = new Vector3(x, y, z);
        }
        counter += 1;
        if(counter == lines.Count) { counter = 0; }
        Thread.Sleep(30);
    }


}
