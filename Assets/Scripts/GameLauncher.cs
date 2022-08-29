using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameLauncher : MonoBehaviour
{
    public static UnityAction OnStartGame;
    void Start()
    {
        if (AudioManager.Instance.isAudioEnabled)
        {
            AudioManager.Instance.PlayBgm();
        }
        else if(!AudioManager.Instance.isAudioEnabled)
        {
            OnStartGame();
        }
    }

    
}
