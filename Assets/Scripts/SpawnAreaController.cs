using UnityEngine;

public class SpawnAreaController : MonoBehaviour
{
    public GameObject powerUpPrefab;
    public float TimeBetweenSpawn = 19f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(Spawn), 6f, TimeBetweenSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        BoxCollider2D area = GetComponent<BoxCollider2D>();
        Vector2 randomPosition = new Vector2(
            Random.Range(area.bounds.min.x, area.bounds.max.x),
            Random.Range(area.bounds.min.y, area.bounds.max.y)
        );

        Instantiate(powerUpPrefab, randomPosition, Quaternion.identity);
    }
}
