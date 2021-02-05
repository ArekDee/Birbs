using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    static string MUSIC_VOLUME = "musicVolume";
    static string EFFECTS_VOLUME = "effectsVolume";

    public AudioClip menuMusic;
    public static MusicController instance = null;
    AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey(MUSIC_VOLUME))
        {
            instance.source.volume = PlayerPrefs.GetFloat(MUSIC_VOLUME);
        }
        else
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME, 0.25f);
            instance.source.volume = 0.25f;
        }
        if (!PlayerPrefs.HasKey(EFFECTS_VOLUME))
        {
            PlayerPrefs.SetFloat(EFFECTS_VOLUME, 0.5f);
        }
        PlayMenuMusic();
    }
    static public void PlayMenuMusic()
    {
        if (instance != null)
        {
            if (instance.source != null && instance.source.clip != instance.menuMusic)
            {
                instance.source.Stop();
                instance.source.clip = instance.menuMusic;
                instance.source.Play();
            }
        }
    }
    static public void ChangeMusicVolume(float value)
    {
        instance.source.volume = value;
    }
    static public void SaveMusicAndEffectVolume(float musicVolume,float effectVolume)
    {
        PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolume);
        PlayerPrefs.SetFloat(EFFECTS_VOLUME, effectVolume);
    }
    static public float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME);
    }
    static public float GetEffectsVolume()
    {
        return PlayerPrefs.GetFloat(EFFECTS_VOLUME);
    }
}
