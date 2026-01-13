using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [Header("Escenas por color")]
    [Tooltip("Nombre de la escena para Player rojo")]
    public string escenaPlayerRojo = "EscenaRojo";
    [Tooltip("Nombre de la escena para Player azul")]
    public string escenaPlayerAzul = "EscenaAzul";

    private bool yaProcesado = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SeleccionarEscena(collision);
        }
    }

    private void SeleccionarEscena(Collider2D collider)
    {
        if (yaProcesado) return; // Evita dobles disparos
        yaProcesado = true;

        // Detener el tiempo
        Time.timeScale = 0f;

        // Obtener nombre del objeto que colisiona
        string nombreObjeto = collider.gameObject.name;

        if (nombreObjeto == "RedPlayer")
        {
            SceneManager.LoadScene("BlueWin");
        }
        else if(nombreObjeto == "BluePlayer")
        {
            SceneManager.LoadScene("RedWin");
        }
        else
        {
            Debug.LogWarning("No se ha definido una escena para el criterio dado. Reanudando tiempo.");
            Time.timeScale = 1f;
            yaProcesado = false;
        }
    }
}
