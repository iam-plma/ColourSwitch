using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    private static LeaderboardManager _instance;
    public static LeaderboardManager Instance
    {
        get
        {
            if (_instance == null)
                Debug.LogError("Leaderboard Manager is null");

            return _instance;
        }
    }
    [SerializeField]
    private GameObject row;
    [SerializeField]
    private Transform rowsParent;

    List<PlayerLeaderboardEntry> leaderboard;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        leaderboard = PlayfabManager.leaderboard;
        buildLeaderboard();
    }

    public void buildLeaderboard()
    {
        Debug.Log(leaderboard.Count);

        foreach (Transform item in rowsParent)
            Destroy(item.gameObject);

        foreach(var item in leaderboard)
        {
            GameObject newGO = Instantiate(row, rowsParent);
            Text[] texts = newGO.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position+1).ToString();
            texts[1].text = item.PlayFabId;
            texts[2].text = item.StatValue.ToString();

        }
    }
}
