using Unity.VisualScripting;
using UnityEngine;

public class PorcentajeController : MonoBehaviour
{
    public float fuerza = 1.5f;
    
    // Método para detectar la colisión entre las dos bolas y darle fuerza
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Choque detectado entre las dos bolas");

        if (collision.gameObject.CompareTag("Bola")) 
        {
            Rigidbody2D rbBlueplayer = GetComponent<Rigidbody2D>();
            Rigidbody2D rbRedplayer = collision.gameObject.GetComponent<Rigidbody2D>();

            //Dirección de las dos bolas
            Vector2 direccion = (transform.position - collision.transform.position).normalized;


            // Aplicar fuerzas a las dos bolas
            rbBlueplayer.AddForce(-direccion * fuerza, ForceMode2D.Impulse);
        }
        
    }

}
