using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    [Header("Audio Source")]
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip damage;
    public AudioClip EnemyDeath;
    public AudioClip Fire;
    public AudioClip Jump;
    public AudioClip Coin;


    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
