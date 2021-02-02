using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;


public class PlayfabManager : MonoBehaviour
{
    private static PlayfabManager _instance;
    public static PlayfabManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("PlayFab Manager is null");

            return _instance;
        }
    }

    [HideInInspector]
    public static List<PlayerLeaderboardEntry> leaderboard;

    public static string playerName;

    private void Awake()
    {
        _instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        Login();
    }

    private void Login()
    {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSucces, OnError);
    }

    private void OnSucces(LoginResult result)
    {
        Debug.Log("Successful login\\account create!");

        if (result.InfoResultPayload.PlayerProfile != null)
            playerName = result.InfoResultPayload.PlayerProfile.DisplayName;
    }

    private void OnError(PlayFabError error)
    {
        Debug.Log("Error while logging in\\creating account");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "HighScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    private void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) 
    {
        Debug.Log("Successfull Leaderboard sent");
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "HighScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    private void OnLeaderboardGet(GetLeaderboardResult result)
    {
        leaderboard = result.Leaderboard;
        LeaderboardManager.Instance.buildLeaderboard(leaderboard);
        Debug.Log("assigning leaderboard..." + leaderboard.Count);
    }

    public void SubmitNameButton(string input)
    {
        AudioManager.Instance.Play("Switch");

        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = input,
        };
        
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    private void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        GetLeaderboard();
        Debug.Log("Updated display name!");
        LeaderboardManager.Instance.leaderboardWindow.SetActive(true);
        LeaderboardManager.Instance.nameWindow.SetActive(false);
    }
}
