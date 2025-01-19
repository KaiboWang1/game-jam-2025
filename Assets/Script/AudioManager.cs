using UnityEngine;
using System;
using Random = UnityEngine.Random;

/* 单例音频管理器，有播放BGM、音效、随机音效播放的功能。自定义音频名称，根据名称引用
 * 1. 需要两个AudioSource组件分别播放音效和BGM
 */
[Serializable]
public class AudioDict
{
    public string name;
    public AudioClip audio;
}

public class AudioManager : MonoBehaviour
{
    private AudioSource sfxSource;
    private AudioSource bgmSource;

    // public AudioDict[] audioDicts;
    public AudioClip[] audios;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            sfxSource = this.gameObject.AddComponent<AudioSource>();
            bgmSource = this.gameObject.AddComponent<AudioSource>();

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public AudioClip GetAudioClip(string name)
    {

        foreach (var item in audios)
        {
            if (item.name == name)
            {
                return item;
            }
        }

        throw new Exception("Cannot find the audio clip named: " + name);
    }

    // 播放一次音效
    public void PlaySound(string name)
    {
        sfxSource.PlayOneShot(GetAudioClip(name));
    }

    // 播放随机音效
    public void PlaySoundRandom(params string[] names)
    {
        if (names.Length == 0)
        {
            throw new Exception("Parameter cannot be empty.");
        }

        int random = Random.Range(0, names.Length);

        sfxSource.PlayOneShot(GetAudioClip(names[random]));
        Debug.Log("Playing: " + names[random]);
    }

    /// <summary>
    /// Multiple clip name split by "/"
    /// </summary>
    public void PlaySoundRandom(string nameMix)
    {
        if (nameMix.Length == 0)
        {
            throw new Exception("Parameter cannot be empty.");
        }

        string[] names = nameMix.Split("/");

        int random = Random.Range(0, names.Length);

        sfxSource.PlayOneShot(GetAudioClip(names[random]));
        Debug.Log("Playing: " + names[random]);
    }

    // 开始播放BGM
    public void PlayMusic(string name)
    {
        bgmSource.clip = GetAudioClip(name);
        bgmSource.Play();
    }

    // 暂停BGM
    public void PauseSound()
    {
        bgmSource.Pause();
    }

}