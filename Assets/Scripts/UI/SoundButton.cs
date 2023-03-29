using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Image _soundIcon;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;

    private float _volume;

    public static bool IsSound { get; private set; } = true;

    private void Start()
    {
        _volume = AudioListener.volume;
        IsSound = true;
    }

    public void SoundChange()
    {
        IsSound = !IsSound;

        if ( IsSound )
        {
            _soundIcon.sprite = _soundOn;
            AudioListener.volume = _volume;
        }
        else
        {
            _soundIcon.sprite = _soundOff;
            AudioListener.volume = 0;
        }
    }
}
