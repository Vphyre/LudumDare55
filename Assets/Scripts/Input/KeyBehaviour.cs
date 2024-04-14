using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private float _actionTime = 0.25f;
    public UnityEvent OnKeyPressed;
    public UnityEvent OnKeyPressedEnds;
    public bool damage = false;
    public void KeyAction()
    {
        OnKeyPressed.Invoke();
        Invoke("EndsAction", _actionTime);
    }
    public void EndsAction()
    {
        if(damage)
        {
           
        }
        else
        {

        }
        
        OnKeyPressedEnds.Invoke();
    }
    public void Correct()
    {
        damage = true;
    }
}
