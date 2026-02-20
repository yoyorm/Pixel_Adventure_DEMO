
using System;
using UnityEngine;
using UnityEngine.Serialization;

public  class AudioManager :MonoBehaviour
{
    public static  AudioManager Instance;
    public float bgmVolume=1;
    public float seVolume=1;
    public AudioSource bgmSource;
    public AudioSource seSource;
    private void OnChangedMusicVolume(MusicData data)
    {
        bgmVolume = data.bgmVolume;
        seVolume = data.seVolume;
        DataManager.MusicData = data;
        bgmSource.volume = bgmVolume;
        seSource.volume = seVolume;
    }
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            EventBus<MusicData>.Subscribe(OnChangedMusicVolume);
            bgmVolume = DataManager.MusicData.bgmVolume;
            seVolume = DataManager.MusicData.seVolume;
            
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
    

    public void PlayWalkingSound()
    {
        if (!seSource.isPlaying)
        {
            seSource.clip = Resources.Load<AudioClip>("Music/walk");
            seSource.Play();
        }
    }
    private void OnDestroy()
    {
        EventBus<MusicData>.Unsubscribe(OnChangedMusicVolume);
    }
}
[Serializable]
public class MusicData
{
    public float bgmVolume;
    public float seVolume;

    public MusicData()
    {
        bgmVolume = 1.0f;
        seVolume = 1.0f;
    }

    public MusicData(float bgmVolume, float seVolume)
    {
        this.bgmVolume = bgmVolume;
        this.seVolume = seVolume;
    }
}


