using Agava.WebUtility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundBack : MonoBehaviour
{
    private float _volume = 1;

    private void OnEnable()
    {
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
    }

    private void OnDisable()
    {
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
    }

    private void OnInBackgroundChange(bool inBackground)
    {
        AudioListener.pause = inBackground;

        if (inBackground )
        {
            _volume = AudioListener.volume;
            AudioListener.volume = 0;
        }
        else
        {
            AudioListener.volume = _volume;
        }

    }
}
