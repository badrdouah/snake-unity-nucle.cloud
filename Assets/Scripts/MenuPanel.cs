using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    /// <summary>
    /// Text displayed before score value. 
    /// </summary>
    private String textHighScorePrefix;

    /// <summary>
    /// Text displayed before score value. 
    /// </summary>
    private String textDisplayNamePrefix;

    /// <summary>
    /// Text showing high score.
    /// </summary>
    private Text textHighScore;

    /// <summary>
    /// Text showing high score.
    /// </summary>
    private Text textDisplayName;

    private int _highScore;

    /// <summary>
    /// Gets or sets currently displayed high score.
    /// </summary>
    public int HighScore
    {
        get
        {
            return _highScore;
        }
        set
        {
            _highScore = value;
            textHighScore.text = textHighScorePrefix + value.ToString();
        }
    }


    private string _displayName;

    /// <summary>
    /// Gets or sets currently displayed high score.
    /// </summary>
    public string DisplayName
    {
        get
        {
            return _displayName;
        }
        set
        {
            _displayName = value;
            textDisplayName.text = textDisplayNamePrefix + value.ToString();
        }
    }

    // Use this for initialization
    void Awake()
    {
        textHighScore = transform.Find("High Score").GetComponent<Text>();
        textHighScorePrefix = textHighScore.text;

        textDisplayName = transform.Find("Display Name").GetComponent<Text>();
        textDisplayNamePrefix = textDisplayName.text;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
