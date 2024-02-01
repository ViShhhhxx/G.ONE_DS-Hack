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

    public delegate void BothHandsUp();
    public static event BothHandsUp OnBothHandsUp;

    public delegate void GameOver();
    public static event GameOver OnGameOver;


    public static void BothHandsUpEvent()
    {
        if (OnBothHandsUp != null)
        {
            OnBothHandsUp();
        }
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
