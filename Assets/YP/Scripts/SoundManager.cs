using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<SoundManager>();

                if (obj != null)
                {
                    instance = obj;
                }
                else
                {
                    GameObject newObj = new GameObject();
                    newObj.AddComponent<SoundManager>();

                    instance = newObj.GetComponent<SoundManager>();
                }
            }
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private AudioSource audioSource;
    public AudioClip[] clips;
    private AudioClip clipToPlay;

    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }
    public void OnPlayOneShot(string fileName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == fileName)
            {
                clipToPlay = clip;
                break;
            }
        }

        if (clipToPlay != null)
        {
            audioSource.PlayOneShot(clipToPlay);
        }
    }

    // overloading
    public void OnPlaySound(int index)
    {
        OnPlaySound(index, true);
    }
    public void OnPlaySound(int index, bool isLoop)
    {
        audioSource.loop = isLoop;
        OnPlaySound(index, isLoop, true);
    }
    public void OnPlaySound(int index, bool isLoop, bool isAwake)
    {
        audioSource.clip = clips[index];
        audioSource.loop = isLoop;
        audioSource.playOnAwake = isAwake;
        audioSource.Play();
    }

    public void OnPauseSound(bool isPause)
    {
        if (isPause)
            audioSource.Pause();
        else
            audioSource.Play();
    }

    public void OnStopSound()
    {
        audioSource.Stop();
    }
}
