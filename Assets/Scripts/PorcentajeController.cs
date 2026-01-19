using Unity.VisualScripting;
using UnityEngine;

public class PorcentajeController : MonoBehaviour
{
    public float energy = 0;
    Rigidbody2D meRG;
    private void Start()
    {
        meRG = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 direcciton = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (this.CompareTag("BallR")) 
            {
                meRG.AddForce(direcciton * energy, ForceMode2D.Impulse);

            }
                    

        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if (this.CompareTag("BallB"))
            {
                meRG.AddForce(direcciton * energy, ForceMode2D.Impulse);
            }
                

        }

    }
    // Método para detectar la colisión entre las dos bolas y darle fuerza
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Choque detectado entre las dos bolas");

        if (collision.gameObject.CompareTag("BallR")|| collision.gameObject.CompareTag("BallB")) 
        {
            energy +=1.5f;
            Rigidbody2D otherRG = collision.gameObject.GetComponent<Rigidbody2D>();
            //Dirección de las dos bolas
            Vector2 direccionOther = (transform.position - collision.transform.position).normalized;


            // Aplicar fuerzas a las dos bolas
            meRG.AddForce(direccionOther * energy, ForceMode2D.Impulse);
        }
        
    }

}
