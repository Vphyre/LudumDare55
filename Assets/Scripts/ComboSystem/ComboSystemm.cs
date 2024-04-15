using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ComboSystemm : MonoBehaviour
{
    [SerializeField] private int _comboNegativeAmount;
    [SerializeField] private int _comboPositiveAmount;
    [SerializeField] private TMP_Text _comboText;
    private int _comboCount;
    private bool _negativeCondition;
    public UnityEvent OnPositiveCombo;
    public UnityEvent OnNegativeCombo;
    public UnityEvent OnComboBreak;
    private void Start()
    {
        UpdateCombo();
    }
    private void UpdateCombo()
    {
        _comboText.text = _comboCount.ToString();
    }
    public void NegativeCombo(int value)
    {
        if (_negativeCondition == false)
        {
            _comboCount = 0;
            _negativeCondition = true;
            OnComboBreak.Invoke();
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
            _negativeCondition = false;
            OnComboBreak.Invoke();
        }
        VerifyCombo();
    }

    private void VerifyCombo()
    {
        UpdateCombo();
        if (_comboCount >= _comboPositiveAmount)
        {
            OnPositiveCombo.Invoke();
            Debug.Log("Começou a ganhar HP");
        }
        else if (_comboCount <= _comboNegativeAmount)
        {
            OnNegativeCombo.Invoke();
            Debug.Log("Começou a Perder HP");
        }
    }
}
