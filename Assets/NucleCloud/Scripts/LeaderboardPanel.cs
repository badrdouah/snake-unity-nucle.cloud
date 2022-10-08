using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanel : MonoBehaviour
{


    /// <summary>
    /// Leaderboard entries UI list.
    /// </summary>
    private List<textEntry> textEntries;


    private List<dataEntry> _dataEntries;

    /// <summary>
    /// Leaderboard data list.
    /// </summary>
    public List<dataEntry> dataEntries
    {
        get
        {
            return _dataEntries;
        }
        set
        {
            _dataEntries = value;

            for (int i = 0; i < _dataEntries.Count; i++) {

                textEntries[i].displayName.text = "-"+(i+1)+ "\t\t" + _dataEntries[i].displayName;
                textEntries[i].highScore.text = _dataEntries[i].highScore.ToString();
                textEntries[i].date.text = _dataEntries[i].date;

                textEntries[i].Enable();

            }
         }
    }

    // assign leaderboard ui entries
    void Awake()
    {
        textEntries = new List<textEntry>();
        for (int i = 1; i <= 8; i++)
        {
            var textEntry = transform.Find(i.ToString());

           var name =  textEntry.Find("Name").GetComponent<Text>();
           var date =  textEntry.Find("Date").GetComponent<Text>();
           var score =textEntry.Find("Score").GetComponent<Text>();
            textEntries.Add(new textEntry(name, score, date ));
        }
    }

    //get leaderboard data from the server
    public async  void GetLeaderboard()
    {
        ClearLeaderboard();
        var result = await NucleCloudService.GetLeaderboard();

        var entries = new List<dataEntry>();
        for (int i = 0; i < result.list.Count; i++)
        {
            var user = await NucleCloudService.GetUserById(result.list[i].userId);
            var displayName = user.displayName;
            var value = result.list[i].value;
            var date = DateTime.Parse(result.list[i].lastUpdate).ToShortDateString();


            entries.Add (new dataEntry(
                displayName,
                value,
               date));
 
        }
        dataEntries =entries ;
    }


    // clear the leaderboard 
    void ClearLeaderboard()
    {
        for (int i = 0; i < textEntries.Count; i++)
        {
            textEntries[i].Disable();
        }
    }
}

[Serializable]
public class textEntry
{
    public Text displayName;
    public Text highScore;
    public Text date;

    public textEntry( Text _name, Text _score, Text _date)
    {
        displayName = _name;
        highScore = _score;
        date = _date;
    }

    //hide leaderboard entry
    public void Disable()
    {
        displayName.gameObject.SetActive(false);
        highScore.gameObject.SetActive(false);
        date.gameObject.SetActive(false);
    }

    //show leaderboard entry
    public void Enable()
    {
        displayName.gameObject.SetActive(true);
        highScore.gameObject.SetActive(true);
        date.gameObject.SetActive(true);
    }
}

[Serializable]
public class dataEntry
{
    public string displayName;
    public string highScore;
    public string date;


    public dataEntry( string _displayName, string _highScore, string _date)
    {
        displayName = _displayName;
        highScore = _highScore;
        date = _date;
    }
}