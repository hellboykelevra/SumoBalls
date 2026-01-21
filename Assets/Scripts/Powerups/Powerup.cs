using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class GameObjectEvent : UnityEvent<GameObject> { }

public class Powerup : MonoBehaviour
{
    public GameObjectEvent onActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onActivate.Invoke(collision.gameObject);
        }
    }
}
