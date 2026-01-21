using UnityEngine;

public class ArenaShrinker : MonoBehaviour
{
    [Header("Configuración del encogimiento")]
    public float shrinkSpeed = 0.2f; // velocidad de encogimiento
    public float minSize = 1.5f;     // tamaño mínimo permitido

    public SpriteRenderer bordeRenderer;
    void Update()
    {

        float t = transform.localScale.x / 10f;
        bordeRenderer.color = Color.Lerp(Color.red, Color.white, t);

        // Evitar que se haga demasiado pequeña
        if (transform.localScale.x > minSize)
        {
            float shrinkAmount = shrinkSpeed * Time.deltaTime;
            transform.localScale -= new Vector3(shrinkAmount, 0f, 0f);
        }
    }
}
