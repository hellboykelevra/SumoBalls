using UnityEngine;

public class Spawner : MonoBehaviour
{
    void Start()
    {
        // Crear GameObject
        GameObject rectangulo = new GameObject("GameOverRect");

        // Posición en Y = 6
        rectangulo.transform.position = new Vector3(0f, -6f, 0f);

        // Escala 100
        rectangulo.transform.localScale = new Vector3(100f, 1f, 1f);

        // SpriteRenderer (TRANSPARENTE)
        SpriteRenderer sr = rectangulo.AddComponent<SpriteRenderer>();
        sr.sprite = CrearSpriteRectangular();
        sr.color = new Color(0f, 0f, 0f, 0f); // completamente transparente

        // Collider 2D (TRIGGER = lo atraviesan)
        BoxCollider2D col = rectangulo.AddComponent<BoxCollider2D>();
        col.isTrigger = true;

        // Componente GameOverController
        rectangulo.AddComponent<GameOverController>();
    }

    Sprite CrearSpriteRectangular()
    {
        Texture2D tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.white);
        tex.Apply();

        return Sprite.Create(
            tex,
            new Rect(0, 0, 1, 1),
            new Vector2(0.5f, 0.5f),
            1
        );
    }
}
