using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [Header("Componente de UI")]
    public TMP_Text timerText; // El TMP_Text que mostrará el temporizador

    private float tiempoActual = 0f;

    void Awake()
    {
        // Si no se asigna manualmente, busca TMP_Text en el mismo GameObject
        if (timerText == null)
            timerText = GetComponent<TMP_Text>();

        // Asegura que el Text esté activo
        if (timerText != null)
            timerText.gameObject.SetActive(true);
    }

    // Método que llama CameraController para iniciar el temporizador
    public void IniciarTemporizador(float tiempo)
    {
        tiempoActual = tiempo;

        // Mostrar inmediatamente el valor inicial
        ActualizarTexto();
    }

    void Update()
    {
        if (tiempoActual <= 0f)
            return;

        tiempoActual -= Time.deltaTime;
        if (tiempoActual < 0f)
            tiempoActual = 0f;

        ActualizarTexto();
    }

    void ActualizarTexto()
    {
        if (timerText == null) return;

        // Aseguramos que siempre sea un número entero
        int segundos = Mathf.CeilToInt(tiempoActual);

        // Aquí construimos correctamente el string con TMP
        timerText.text = $"Inversión en: {segundos}s";
    }
}
