using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioContainer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource source;
    [SerializeField] private float fadeInTime = 3f;
    public UnityEvent PlayAtStart;

    void Start()
    {
        PlayAtStart.Invoke();
    }

    public void PlayClip(int index)
    {
        if (index >= 0 && index < audioClips.Count)
        {
            AudioManager.Instance.PlaySFX(audioClips[index]);
        }
    }

    public void PlayMusic(int index)
    {
        if (index >= 0 && index < audioClips.Count)
        {
            AudioManager.Instance.PlayMusic(audioClips[index], true, fadeInTime);
        }
    }
}
