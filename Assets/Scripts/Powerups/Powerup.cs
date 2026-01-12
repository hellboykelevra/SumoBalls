using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Powerup : MonoBehaviour
{
    public UnityEvent<GameObject> onActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onActivate.Invoke(collision.gameObject);
        }
    }
}
