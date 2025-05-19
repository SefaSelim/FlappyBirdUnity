using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Dan.Main;
using UnityEngine.SocialPlatforms.Impl;
using System;

public class Leaderboard : MonoBehaviour
{

int x;
[SerializeField]
private List<TextMeshProUGUI> names;

[SerializeField]
private List<TextMeshProUGUI> scores;

private string publicLeaderboardKey =
"3f7661280f10ccf8ad37cbe9452740a29b04f3cf20aee5cbf6c60b4f00338a17";

private void Start() {
    GetLeaderboard();
}



public void GetLeaderboard()
{
    LeaderboardCreator.GetLeaderboard(publicLeaderboardKey,((msg) => {
        int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
        for (int i = 0; i < loopLength; ++i)
        {
            names[i].text = msg[i].Username;
            scores[i].text = msg[i].Score.ToString();
        }
    }));
}

public void SetLeaderboardEntry(string username,int score)
{
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, username, score, ((msg) => { 
        GetLeaderboard();
        }));

}



}
