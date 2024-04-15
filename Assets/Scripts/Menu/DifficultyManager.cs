using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DifficultyManager : MonoBehaviour
{
    public UnityEvent OnEasy;
    public UnityEvent OnMedium;
    public UnityEvent OnHard;
    public void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty); // Easy 1, Medium 2, Hard 3
    }
    private void Awake()
    {
        ReadDifficulty();
    }
    public void ReadDifficulty()
    {
        if (PlayerPrefs.GetInt("difficulty") == 1)
        {
            OnEasy.Invoke();
        }
        else if (PlayerPrefs.GetInt("difficulty") == 2)
        {
            OnMedium.Invoke();
        }
        else if (PlayerPrefs.GetInt("difficulty") == 3)
        {
            OnHard.Invoke();
        }
    }
}
