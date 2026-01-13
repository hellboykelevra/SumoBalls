using UnityEngine;

public class script : MonoBehaviour {
    public float velocidad = 10f; // Grados por segundo, ajusta en el Inspector
    public float amplitud = 5f;   // Máxima desviación en grados (±5° por defecto)

    private float tiempo = 0f;

    void Update() {
        tiempo += Time.deltaTime;

        // Rotación suave en Z alternando positiva y negativa usando seno
        float rotacionZ = Mathf.Sin(tiempo * velocidad) * amplitud;

        // Aplicar solo al eje Z, manteniendo X e Y sin cambios
        transform.rotation = Quaternion.Euler(0f, 0f, rotacionZ);
    }
}
