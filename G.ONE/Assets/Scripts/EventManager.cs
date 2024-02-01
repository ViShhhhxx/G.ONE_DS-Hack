using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void RightBend();
    public static event RightBend OnRightBend;

    public delegate void LeftBend();
    public static event LeftBend OnLeftBend;

    public delegate void CenterBend();
    public static event CenterBend OnCenterBend;

    public delegate void GameOver();
    public static event GameOver OnGameOver;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public static void RightBendEvent()
    {
        if (OnRightBend != null)
        {
            OnRightBend();
        }
    }


    public static void LeftBendEvent()
    {
        if (OnLeftBend != null)
        {
            OnLeftBend();
        }
    }

    public static void CenterBendEvent()
    {
        if (OnCenterBend != null)
        {
            OnCenterBend();
        }
    }

    public static void GameOverEvent()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

}
