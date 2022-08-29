using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmAudioSource;
    [SerializeField] private AudioClip _bgmAudioClip;
    public bool isAudioEnabled = true;
     private static AudioManager _instance;

    public static AudioManager Instance { get { return _instance; } }
    private void Awake() 
    {   
       if (_instance != null && _instance != this )
        {
            Destroy(this.gameObject);
        } else if (isAudioEnabled == true) 
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        LoadClip();
    }

    private void OnEnable()
    {
        GameLauncher.OnStartGame += UnloadAudio;
    }

    private void OnDisable()
    {
        GameLauncher.OnStartGame -= UnloadAudio;
    }

    private void UnloadAudio()
    {
        _bgmAudioClip = null;
        _bgmAudioSource.clip = null;
    }

    private void LoadClip()
    {
        int random = Random.Range(1, 4);
        _bgmAudioClip = Resources.Load<AudioClip>($"BGM/bgm_0{random}");
    }

    public void PlayBgm()
    {
        _bgmAudioSource.clip = _bgmAudioClip;
        _bgmAudioSource.Play();
    }
}
