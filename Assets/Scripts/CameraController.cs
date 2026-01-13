using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Objetos a seguir")]
    public Transform objetoA;
    public Transform objetoB;

    private MovimientoBola2D playerA;
    private MovimientoBola2D playerB;

    [Header("Ajustes de cámara")]
    public float suavizado = 5f;
    public float distanciaZ = -10f;

    void Start()
    {
        if (objetoA != null)
            playerA = objetoA.GetComponent<MovimientoBola2D>();

        if (objetoB != null)
            playerB = objetoB.GetComponent<MovimientoBola2D>();
    }

    void LateUpdate()
    {
        if (objetoA == null || objetoB == null)
            return;

        Vector3 objetivo;

        // Ambos vivos
        if (playerA.estaVivo && playerB.estaVivo)
        {
            objetivo = (objetoA.position + objetoB.position) / 2f;
        }
        // Solo A vivo
        else if (playerA.estaVivo)
        {
            objetivo = objetoA.position;
        }
        // Solo B vivo
        else if (playerB.estaVivo)
        {
            objetivo = objetoB.position;
        }
        // Ninguno vivo
        else
        {
            return;
        }

        objetivo.z = distanciaZ;

        transform.position = Vector3.Lerp(
            transform.position,
            objetivo,
            Time.deltaTime * suavizado
        );
    }
}
