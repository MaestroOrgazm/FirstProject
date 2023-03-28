using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Leaderbord : MonoBehaviour
{
    [SerializeField] private TMP_Text _myRank;
    [SerializeField] private TMP_Text _AllTable;

    private int _maxCount = 9;
    private int _currentcount;

    public void SetScore()
    {
        _AllTable.text = "";
        _currentcount = 1;
        Agava.YandexGames.Leaderboard.SetScore("IoM", Level.CountLevel, null, null, Wallet.Name);
        Agava.YandexGames.Leaderboard.GetEntries("IoM", (result) =>
        {
            _myRank.text = result.userRank.ToString();

            if (_maxCount > _currentcount)
            {
                foreach (var entry in result.entries)
                {
                    string name = entry.extraData;
                    _AllTable.text += (_currentcount + ". " + name + " - " + entry.score + "\n");
                    _currentcount++;
                }
            }

        });
    }
}
