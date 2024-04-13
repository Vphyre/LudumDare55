using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private float musicVolume = 0.5f;
    [SerializeField] private float sfxVolume = 1f;
    public float MusicVolume { get => musicVolume; set { musicVolume = value; musicSource.volume = musicVolume; } }
    public float SFXVolume { get => sfxVolume; set { sfxVolume = value; sfxSource.volume = sfxVolume; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        VolumeLevel();
    }
    public void VolumeLevel()
    {
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;
    }
    public void PlayMusic(AudioClip clip, bool loop = true, float fadeInTime = 0f)
    {
        StopAllCoroutines();
        StartCoroutine(PlayMusicCoroutine(clip, loop, fadeInTime));
    }
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
    private IEnumerator PlayMusicCoroutine(AudioClip clip, bool loop, float fadeInTime)
    {
        if (musicSource.isPlaying)
        {
            yield return StartCoroutine(FadeOutMusic(fadeInTime));
        }

        musicSource.clip = clip;
        musicSource.loop = loop;
        musicSource.Play();

        if (fadeInTime > 0f)
        {
            yield return StartCoroutine(FadeInMusic(fadeInTime));
        }
    }
    public IEnumerator FadeInMusic(float time)
    {
        float startVolume = 0f;

        musicSource.volume = startVolume;

        while (musicSource.volume < musicVolume)
        {
            musicSource.volume += musicVolume * Time.deltaTime / time;

            yield return null;
        }

        musicSource.volume = musicVolume;
    }
    public IEnumerator FadeOutMusic(float time)
    {
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / time;

            yield return null;
        }

        musicSource.Stop();
        musicSource.volume = startVolume;
    }
}
