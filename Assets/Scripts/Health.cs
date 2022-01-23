using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    [SerializeField] int health = 50;
    [SerializeField] int score = 10;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    [SerializeField] bool isPlayer;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake() {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if(damageDealer != null) {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            if (isPlayer) {
                audioPlayer.PlayDamageClip();
                if (health <= 0) {
                    levelManager.LoadGameOver();
                    audioPlayer.PlayYodaSound();
                }
            }
            else if(health <= 0) {
                scoreKeeper.ModifyScore(score);
            }
            ShakeCamera();
            damageDealer.Hit();
        }
    }
    void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0) Destroy(gameObject);
    }

    void PlayHitEffect() {
        if (hitEffect != null) {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
    void ShakeCamera() {
        if (cameraShake != null && applyCameraShake)
            cameraShake.Play();
    }
    public int GetHealth() { return health; }
}
