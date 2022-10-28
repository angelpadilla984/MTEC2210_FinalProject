using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBell : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip clip;

    private void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();
        clip = audioSource.clip;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Bell rung");
        audioSource.pitch = Random.Range(0.85f, 1.15f);
        audioSource.PlayOneShot(clip);

    }


}
