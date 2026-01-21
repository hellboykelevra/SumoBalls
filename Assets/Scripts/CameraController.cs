using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    [Header("Objetos a seguir")]
    public Transform objetoA;
    public Transform objetoB;

    [Header("Ajustes de cámara")]
    public float suavizado = 5f;
    public float distanciaZ = -10f;

    [Header("Inversión de cámara")]
    public float tiempoParaInvertir = 15f;
    public float duracionAnimacion = 2f;

    [Header("UI - Temporizador")]
    public TimerUI timerUI; // Referencia al script del temporizador (TMP_Text dentro de TimerUI)

    private Quaternion rotacionOriginal;
    private Quaternion rotacionInvertida;

    void Start()
    {
        // Guarda la rotación inicial
        rotacionOriginal = transform.rotation;

        // Calcula la rotación invertida
        rotacionInvertida = Quaternion.Euler(0f, 0f, 180f) * rotacionOriginal;

        // Inicia el bucle principal
        StartCoroutine(BucleCamara());
    }

    void LateUpdate()
    {
        if (objetoA == null || objetoB == null)
            return;

        // Calcula el punto medio entre los objetos
        Vector3 puntoMedio = (objetoA.position + objetoB.position) / 2f;
        puntoMedio.z = distanciaZ;

        // Mueve la cámara suavemente
        transform.position = Vector3.Lerp(
            transform.position,
            puntoMedio,
            Time.deltaTime * suavizado
        );
    }

    IEnumerator BucleCamara()
    {
        while (true)
        {
            // 🔔 Inicia temporizador antes de invertir la cámara
            if (timerUI != null)
                timerUI.IniciarTemporizador(tiempoParaInvertir);

            // Espera antes de invertir
            yield return new WaitForSeconds(tiempoParaInvertir);

            // 🔀 Inversión aleatoria
            yield return StartCoroutine(
                CambiarRotacion(rotacionOriginal, rotacionInvertida)
            );

            // 🔔 Inicia temporizador para el regreso
            if (timerUI != null)
                timerUI.IniciarTemporizador(tiempoParaInvertir * 2f);

            // Espera el doble de tiempo
            yield return new WaitForSeconds(tiempoParaInvertir * 2f);

            // 🔀 Regreso aleatorio
            yield return StartCoroutine(
                CambiarRotacion(rotacionInvertida, rotacionOriginal)
            );
        }
    }

    IEnumerator CambiarRotacion(Quaternion desde, Quaternion hasta)
    {
        bool suave = Random.value > 0.5f; // 🎲 50% probabilidad

        if (!suave)
        {
            // ⚡ Instantáneo
            transform.rotation = hasta;
            yield break;
        }

        // 🌀 Cambio suave
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime / duracionAnimacion;
            transform.rotation = Quaternion.Slerp(desde, hasta, t);
            yield return null;
        }

        transform.rotation = hasta;
    }
}
