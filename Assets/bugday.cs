using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bugday : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().YemekSayisi++;
            GameObject.Find("GameManager").GetComponent<GameManager>().Reflesh();
            Destroy(transform.gameObject);
        }
    }
}
