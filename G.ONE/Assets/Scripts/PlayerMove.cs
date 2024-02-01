using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float laneWidth = 3f;

    // Set the initial lane to the center lane
    private int currentLane = 1;
    private bool isShifting = false;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);

        if (!isShifting)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                StartCoroutine(ShiftLaneCoroutine(-1));

            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                StartCoroutine(ShiftLaneCoroutine(1));
        }
    }

    IEnumerator ShiftLaneCoroutine(int direction)
    {
        isShifting = true;

        int newLane = Mathf.Clamp(currentLane + direction, 0, 2);
        float targetX = newLane * laneWidth;

        while (Mathf.Abs(transform.position.x - targetX) > 0.01f)
        {
            float step = Mathf.MoveTowards(transform.position.x, targetX, Time.deltaTime * moveSpeed * 5f);
            transform.position = new Vector3(step, transform.position.y, transform.position.z);
            yield return null;
        }

        currentLane = newLane;
        isShifting = false;
    }

    public void Move(int direction)
    {
        StartCoroutine(ShiftLaneCoroutine(direction));
    }

}
