using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization;

public class LocalizeChange : MonoBehaviour
{
    private int _ruNumber = 1;
    private int _enNumber = 0;
    private int _trNumber = 2;

    public void RuLanguage()
    {
        ChangeLocal(_ruNumber);
    }

    public void EnLanguage()
    {
        ChangeLocal(_enNumber);
    }

    public void TrLanguage()
    {
        ChangeLocal(_trNumber);
    }

    private void ChangeLocal(int number)
    {
        SetLocale(LocalizationSettings.AvailableLocales.Locales[number]);
    }

    private void SetLocale(Locale locale)
    {
        LocalizationSettings.SelectedLocale = locale;
    }
}
