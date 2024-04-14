using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyBehaviour : MonoBehaviour
{
    [SerializeField] private float _actionTime = 0.25f;
    public UnityEvent OnKeyPressed;
    public UnityEvent OnKeyPressedEnds;
    public UnityEvent OnCorrectKeyPressed;
    public UnityEvent OnWrongKeyPressed;
    private bool _hitCorrectKey = false;
    public void KeyAction()
    {
        OnKeyPressed.Invoke();
        Invoke("EndsAction", _actionTime);
    }
    public void EndsAction()
    {
        if (_hitCorrectKey == false)
        { 
            OnWrongKeyPressed.Invoke();
            
        }
        else
        {
            OnCorrectKeyPressed.Invoke();
        }
        _hitCorrectKey = false;
        OnKeyPressedEnds.Invoke();
    }
    public void CorrectKey()
    {
        _hitCorrectKey = true;
    }
}
