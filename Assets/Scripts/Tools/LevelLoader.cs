using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public UnityEvent OnFinishLoad;
    public UnityEvent OnLoad;

    [SerializeField] private GameObject _loadingScreen;
    [SerializeField] private GameObject _fadeScreen;
    [SerializeField] private float _fadeTime;
    [SerializeField] private string _sceneName;

    private float _minLoadTime = 1.5f;

    public static LevelLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        OnFinishLoad.Invoke();
    }
    public void LoadLevel()
    {
        Time.timeScale = 1f;
        if(_sceneName == "")
        {
            _sceneName = SceneManager.GetActiveScene().name;
        }
        StartCoroutine(LoadAsync());
    }
    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadAsync(levelName));
    }
    public void SetSceneToLoad(string sceneName)
    {
        _sceneName = sceneName;
    }
    private IEnumerator LoadAsync()
    {
        OnLoad.Invoke();
        _fadeScreen.SetActive(true);
        yield return new WaitForSeconds(_fadeTime);
        _loadingScreen.SetActive(true);
        yield return new WaitForSeconds(_minLoadTime);
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneName);
        yield return null;
    }

    private IEnumerator LoadAsync(string levelName)
    {
        OnLoad.Invoke();
        _fadeScreen.SetActive(true);
        yield return new WaitForSeconds(_fadeTime);
        _loadingScreen.SetActive(true);
        yield return new WaitForSeconds(_minLoadTime);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelName);
        yield return null;
    }
}
