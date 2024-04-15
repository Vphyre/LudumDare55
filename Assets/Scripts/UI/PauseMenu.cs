using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;

    // Update is called once per frame
    void Update()
    {

    }
    private void OnEnable()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        SetTimeScale(0);
        menu.SetActive(true);
    }

    public void ResumeGame()
    {
        SetTimeScale(1);
        menu.SetActive(false);
    }
    public void SetTimeScale(float value)
    {
        Time.timeScale = value;
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo");
    }
}
