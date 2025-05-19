using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetHighscore : MonoBehaviour
{
    TextMeshProUGUI Highscore;
    private void Start()
    {
        Highscore = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        Highscore.text = StaticSettings.MaxScore.ToString();
    }

}
