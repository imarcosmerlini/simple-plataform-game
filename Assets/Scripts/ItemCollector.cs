using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int _bananasCollected = 0;
    [SerializeField] private Text _bananasText; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            _bananasCollected++;
            _bananasText.text = "Bananas: " + _bananasCollected;
        }
    }
}
