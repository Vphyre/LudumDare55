using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("difficulty", difficulty);
    }
}
