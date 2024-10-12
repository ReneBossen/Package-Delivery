using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    private void Awake()
    {
        if (Instance != null) Debug.LogError("More than one Score");
        Instance = this;
    }
    private void Start()
    {
        PackageEventHandler.CostumerRecievedPackage += OnCostumerRecievedPackage;
    }

    private void OnCostumerRecievedPackage(object sender, EventArgs e)
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    public int GetScore() => score;
}
