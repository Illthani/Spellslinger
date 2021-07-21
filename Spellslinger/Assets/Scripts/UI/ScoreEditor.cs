using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreEditor : MonoBehaviour
{
    private int scoreCounter = 0;


    public GameObject textGO;

    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int scoreAddition = 1)
    {
        scoreCounter += scoreAddition;
        textGO.GetComponent<TextMeshProUGUI>().text = scoreCounter.ToString();

    }
}
