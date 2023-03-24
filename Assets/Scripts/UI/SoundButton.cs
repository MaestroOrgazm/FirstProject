using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private Image _soundIcon;
    [SerializeField] private Sprite _soundOn;
    [SerializeField] private Sprite _soundOff;
    
    private bool _isSound = true;

    public void SoundChange()
    {
        _isSound = !_isSound;

        if ( _isSound )
        {
            _soundIcon.sprite = _soundOn;
            AudioListener.volume = 1;
        }
        else
        {
            _soundIcon.sprite = _soundOff;
            AudioListener.volume = 0;
        }
    }
}
