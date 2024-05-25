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
"9785bf52c5fbb7fa144d4612d3121e5474bb6bd5af2390cc6d092fc3b200ea3d";

private void Start() {
    GetLeaderboard();
}



public void GetLeaderboard()
{
    LeaderboardCreator.GetLeaderboard(publicLeaderboardKey,((msg) => {
        names[0].text = msg[0].Username;
        scores[0].text = msg[0].Score.ToString();
    }));
}

public void SetLeaderboardEntry(string username,int score)
{

x = Int32.Parse(scores[0].text);

    if (x>score)
    {
        username = names[0].text;
        score = Int32.Parse(scores[0].text);
        
    }


    LeaderboardCreator.UploadNewEntry(publicLeaderboardKey,username,score,((msg)=>{
        
        GetLeaderboard();
    }));
}



}
