using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip playerShootingClip;
    [SerializeField] AudioClip enemyShootingClip;
    [SerializeField] [Range(0f, 1f)] float playerShootingVolume = 1f;
    [SerializeField] [Range(0f, 1f)] float enemyShootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    [Header("Death")]
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0f, 1f)] float deathVolume = 1f;

    public void PlayPlayerShootingClip() {
        PlayClip(playerShootingClip, playerShootingVolume);
    }
    public void PlayEnemyShootingClip() {
        PlayClip(enemyShootingClip, enemyShootingVolume);
    }
    public void PlayDamageClip() {
        PlayClip(damageClip, damageVolume);
    }
    public void PlayYodaSound() {
        PlayClip(deathClip, deathVolume);
    }
    void PlayClip(AudioClip clip, float volume) {
        if (clip != null) {
            AudioSource.PlayClipAtPoint(clip, transform.position, volume);
        }
    }

    //I dont use audioplayer in multiple scenes but imma still make a singleton method for practice reasonz
    void ManageSingleton() {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else
            DontDestroyOnLoad(gameObject);
    }
}
