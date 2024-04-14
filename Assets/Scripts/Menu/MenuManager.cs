using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject difficultyMenu;
    public void Play()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
    public void OpenDifficulty()
    {
        startMenu.SetActive(false);
        difficultyMenu.SetActive(true);
    }
    public void CloseDifficulty()
    {
        difficultyMenu.SetActive(false);
        startMenu.SetActive(true);
    }
    public void OpenOptions()
    {
        startMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void CloseOptions()
    {
        optionsMenu.SetActive(false);
        startMenu.SetActive(true);
    }
    public void ExitGame()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}
