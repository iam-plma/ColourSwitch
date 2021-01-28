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

    public GameObject nameWindow;
    public GameObject leaderboardWindow;

    public InputField inputField;

    [HideInInspector]
    public string _name = null;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        
        _name = PlayfabManager.playerName;
        //Debug.Log("Leaderboard length: " + leaderboard.Count + " Player name: " + _name);

        if (_name == null)
            nameWindow.SetActive(true);
        else
        {
            leaderboardWindow.SetActive(true);
            PlayfabManager.Instance.GetLeaderboard();
        }
            
    }

    public void buildLeaderboard(List<PlayerLeaderboardEntry> leaderboard)
    {
        Debug.Log(leaderboard.Count);
        foreach (Transform item in rowsParent)
            Destroy(item.gameObject);

        foreach(var item in leaderboard)
        {
            GameObject newGO = Instantiate(row, rowsParent);
            Text[] texts = newGO.GetComponentsInChildren<Text>();
            texts[0].text = (item.Position+1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();
        }
    }

    public void Submit()
    {
        PlayfabManager.Instance.SubmitNameButton(_name);
    }

    public void SetName()
    {
        _name = inputField.text;
        Debug.Log(_name);
    }

    
}
