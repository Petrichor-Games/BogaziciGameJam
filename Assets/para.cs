using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class para : MonoBehaviour
{
    public AudioClip clip;
    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.collider.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().AltinSayisi++;
            GameObject.Find("GameManager").GetComponent<GameManager>().Reflesh();
            audioSource.PlayOneShot(clip, 1f);
            Destroy(transform.gameObject);
        }
    }
}
