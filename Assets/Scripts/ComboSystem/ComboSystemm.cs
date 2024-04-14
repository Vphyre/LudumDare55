using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ComboSystemm : MonoBehaviour
{
    [SerializeField] private int _comboNegativeAmount;
    [SerializeField] private int _comboPositiveAmount;
    private int _comboCount;
    private bool _negativeCondition;
    public UnityEvent OnPositiveCombo;
    public UnityEvent OnNegativeCombo;
    public void NegativeCombo(int value)
    {
        if (_negativeCondition == false)
        {
            _comboCount = 0;
            _negativeCondition = true;
        }
        else
        {
            _comboCount -= value;
        }
        VerifyCombo();
    }
    public void PositiveCombo(int value)
    {
        if (_negativeCondition == false)
        {
            _comboCount += value;
        }
        else
        {
            _comboCount = 0;
            _negativeCondition = true;
        }
        VerifyCombo();
    }

    private void VerifyCombo()
    {
        Debug.Log(_comboCount);
        if (_comboCount >= _comboPositiveAmount)
        {
            OnPositiveCombo.Invoke();
            Debug.Log("Começou a ganhar HP");
        }
        else if(_comboCount <= _comboNegativeAmount)
        {
            OnNegativeCombo.Invoke();
            Debug.Log("Começou a Perder HP");
        }
    }
}
