using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    private AudioSource sfxPlayer;
    private AudioSource bgmPlayer;

    [SerializeField]
    private AudioClip runningAudioClip;

    [SerializeField]
    private AudioClip[] sfxAudioClips;

    private Dictionary<string, AudioClip> audioClipsDic = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        Instance = this;

        sfxPlayer = GetComponent<AudioSource>();
        bgmPlayer = GetComponent<AudioSource>();

        foreach (AudioClip audioclip in sfxAudioClips)
        {
            audioClipsDic.Add(audioclip.name, audioclip);
        }
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void PlaySFXSound(string name, float volume = 1f)
    {
        if (audioClipsDic.ContainsKey(name) == false)
        {
            Debug.Log(name + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[name], volume);
    }

    public void PlayBGMSound(float volume = 1f)
    {
        bgmPlayer.loop = true;
        bgmPlayer.volume = volume;

        bgmPlayer.clip = runningAudioClip;
        bgmPlayer.Play();
    }

    public void StopBGMSound()
    {
        bgmPlayer.Stop();
    }
}
