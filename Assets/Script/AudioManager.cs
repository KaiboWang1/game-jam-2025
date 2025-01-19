using UnityEngine;
using System;
using Random = UnityEngine.Random;

/* ������Ƶ���������в���BGM����Ч�������Ч���ŵĹ��ܡ��Զ�����Ƶ���ƣ�������������
 * 1. ��Ҫ����AudioSource����ֱ𲥷���Ч��BGM
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

    // ����һ����Ч
    public void PlaySound(string name)
    {
        sfxSource.PlayOneShot(GetAudioClip(name));
    }

    // ���������Ч
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

    // ��ʼ����BGM
    public void PlayMusic(string name)
    {
        bgmSource.clip = GetAudioClip(name);
        bgmSource.Play();
    }

    // ��ͣBGM
    public void PauseSound()
    {
        bgmSource.Pause();
    }

}