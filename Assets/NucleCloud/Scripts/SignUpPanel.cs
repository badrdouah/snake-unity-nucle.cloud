using System;
using System.Collections;
using System.Collections.Generic;
using Nucle.Cloud;
using UnityEngine;
using UnityEngine.UI;

public class SignUpPanel : MonoBehaviour
{
    /// Text showing display name provided by the player to create an account.
    /// </summary>
    private Text textDisplayName;


    private void Awake()
    {
        textDisplayName = transform.Find("Display Name").GetComponent<Text>();
    }

    /// <summary>
    /// Sign up a new anonymous user
    /// </summary>
    public void SignUp()
    {
        var displayName = textDisplayName.text;
        NucleCloudService.SignUp(displayName);
    }

}
