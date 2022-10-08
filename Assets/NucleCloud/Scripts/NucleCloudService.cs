using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Nucle.Cloud;
using UnityEngine;
 
public static class NucleCloudService 
{
    public static string projectId= "884939ef-46a1-11ed-8b23-f23c93dca3fd";

    public static string scorePresetId= "64633679-46b7-11ed-8b23-f23c93dca3fd";

 
    public static async void SignUp(string displayName)
    {
        try
        {
            // Create new anonymous user
            if (string.IsNullOrWhiteSpace(displayName)) displayName = "Guest";
            await Anonymous.Create( projectId, SystemInfo.deviceUniqueIdentifier, displayName);

            // login anonymous user
            var loginResult = await Anonymous.Login(projectId, SystemInfo.deviceUniqueIdentifier);
            if (loginResult != null)
            {
                Game.Instance.UserToken = loginResult.userToken;
                Game.Instance.DisplayName = loginResult.user.displayName;

                Game.Instance.ShowMenu();
            }
        }
        catch (Exception ex)
        {
            Game.Instance.ShowDisconnectedPanel();
            Debug.Log(ex.Message);
        }
    }
 

 
    public static async Task<LoginResult> Login()
    {
        LoginResult result = null;
        try
        {
            var anonymousUser = await Anonymous.Get(projectId, SystemInfo.deviceUniqueIdentifier);
            if (anonymousUser != null)
            {
                // login anonymous user
                return await Anonymous.Login(projectId, SystemInfo.deviceUniqueIdentifier);
            }
            else
            {
                Game.Instance.ShowSignUpPanel();
            }
        }
        catch(Exception ex)
        {
            Game.Instance.ShowDisconnectedPanel();
            Debug.LogError(ex.Message);
        }

        return result;

    }

    public static  async Task<int> GetScore()
    {
        int _highScore = 0;
        try
        {
            var scorePresetModel = await Variable.Get(Game.Instance.UserToken, scorePresetId);
            if (scorePresetModel != null) _highScore = Int32.Parse(scorePresetModel.value);
        }
        catch (Exception ex)
        {
            Game.Instance.ShowDisconnectedPanel();
            Debug.LogError(ex.Message);
        }
        return _highScore;
    }

    public static async void SetScore(int newScore)
    {
        try
        {
             await Variable.Update(Game.Instance.UserToken, scorePresetId, newScore.ToString());
        }
        catch (Exception ex)
        {
            Game.Instance.ShowDisconnectedPanel();
            Debug.LogError(ex.Message);
        }
    }


    public static async Task<UserModel> GetUserById( string userId)
    {
        UserModel result = null;
        try
        {
            result = await User.GetById(Game.Instance.UserToken, userId);
        }
        catch (Exception ex)
        {
            Game.Instance.ShowDisconnectedPanel();
            Debug.LogError(ex.Message);
        }
        return result;
    }

    public static async Task<VariablesModel> GetLeaderboard()
    {
        VariablesModel result = null;
        try
        {
            var skip = 0;
            var take = 8;
            var _orderType = orderType.HighToLow;
            result = await Variable.GetList(Game.Instance.UserToken, scorePresetId,skip,take, _orderType);
        }
        catch (Exception ex)
        {
            Game.Instance.ShowDisconnectedPanel();
            Debug.LogError(ex.Message);
        }
        return result;
    }

}
