using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI finalScoreText;

    private void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start() {
        finalScoreText.text = scoreKeeper.GetScore().ToString();
    }
}
