using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
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
        if (yaProcesado) return;
        yaProcesado = true;

        // 🔴 MUY IMPORTANTE: restaurar el tiempo
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        string nombreObjeto = collider.gameObject.name;

        if (nombreObjeto == "RedPlayer")
        {
            SceneManager.LoadScene("BlueWin");
        }
        else if (nombreObjeto == "BluePlayer")
        {
            SceneManager.LoadScene("RedWin");
        }
        else
        {
            // Fallback: recarga la escena actual
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
