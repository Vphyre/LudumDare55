using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseInput : MonoBehaviour
{
    public UnityEvent onEscPressedToPause; 
    public UnityEvent onEscPressedToExit; 
    private bool paused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
                onEscPressedToExit.Invoke();
                paused = !paused;
            }
            else
            {
                onEscPressedToPause.Invoke();
                paused = !paused;
            }
        }
    }
}
