using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Player _player;
    
    private void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered with " + other);
        if (other.CompareTag("Player"))
        {
            _player.CollectCoin();
            Destroy(gameObject);
        }
    }
}
