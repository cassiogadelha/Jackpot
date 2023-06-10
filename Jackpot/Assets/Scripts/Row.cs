using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row : MonoBehaviour
{
    private int randomValue;
    private float timeInterval;

    public bool rowStopped;
    public string stoppedSlot;
    
    void Start()
    {
        rowStopped = true;
        GameManager.HandlePulled += StartRotating;
    }

    private void StartRotating()
    {
        stoppedSlot = "";
        StartCoroutine("Rotate");
    }

    private IEnumerator Rotate()
    {
        rowStopped = false;
        timeInterval = 0.025f;
        randomValue = Random.Range(60, 100);

        for (int i = 0; i < randomValue; i++)
        {
            if(transform.position.y <= -3.5f)
            {
                transform.position = new Vector2(transform.position.x, 1.75f);
            }
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.25f);

            if (i > Mathf.RoundToInt(randomValue * 0.25f)) timeInterval = 0.05f;
            if (i > Mathf.RoundToInt(randomValue * 0.5f)) timeInterval = 0.1f;
            if (i > Mathf.RoundToInt(randomValue * 0.75f)) timeInterval = 0.15f;
            if (i > Mathf.RoundToInt(randomValue * 0.95f)) timeInterval = 0.2f;

            yield return new WaitForSeconds(timeInterval);
        }

        if (transform.position.y == -3.5f) stoppedSlot = "Diamond";
        if (transform.position.y == -3.5f) stoppedSlot = "Crow";
        if (transform.position.y == -3.5f) stoppedSlot = "Melon";
        if (transform.position.y == -3.5f) stoppedSlot = "Bar";
        if (transform.position.y == -3.5f) stoppedSlot = "Seven";
        if (transform.position.y == -3.5f) stoppedSlot = "Cherry";
        if (transform.position.y == -3.5f) stoppedSlot = "Dfilitto";
        if (transform.position.y == -3.5f) stoppedSlot = "Diamond";

        rowStopped = true;
    }

    private void OnDestroy()
    {
        GameManager.HandlePulled -= StartRotating;
    }
}
