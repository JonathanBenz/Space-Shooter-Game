using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour {
    Player player;
    ScoreKeeper scoreKeeper;
    Health playerHealth;
    int normalizationValue;
    [SerializeField] Slider healthSlider;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        player = FindObjectOfType<Player>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start() {
        playerHealth = player.GetComponent<Health>();
        normalizationValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth() / (float) normalizationValue;
        scoreText.text = scoreKeeper.GetScore().ToString();
    }
}
