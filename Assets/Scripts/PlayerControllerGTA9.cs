using NUnit.Framework.Constraints;
using System.Collections;
using UnityEngine;

public class MovimientoBola2D : MonoBehaviour
{
    [Header("Players")]
    public GameObject enemyBall;

    public float fuerzaMovimiento = 5f;
    bool canJump = false;

    [HideInInspector]
    public bool estaVivo = true;
    private bool hasInversedControls = false;

    public enum TipoControl
    {
        WASD,
        Flechas
    }

    [Header("Tipo de control")]
    public TipoControl tipoControl = TipoControl.WASD;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!estaVivo) return;

        float inputHorizontal = 0f;

        if (tipoControl == TipoControl.WASD)
        {
            inputHorizontal = (Input.GetKey(KeyCode.A) ? -1 : 0) +
                              (Input.GetKey(KeyCode.D) ? 1 : 0);

            if (canJump && Input.GetKey(KeyCode.W))
            {
                rb.linearVelocityY = 0f;
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
                canJump = false;
            }
        }
        else
        {
            inputHorizontal = (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0) +
                              (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);

            if (canJump && Input.GetKey(KeyCode.UpArrow))
            {
                rb.linearVelocityY = 0f;
                rb.AddForce(Vector2.up * 5f, ForceMode2D.Impulse);
                canJump = false;
            }
        }

        if(hasInversedControls) inputHorizontal *= -1;
        
        rb.AddForce(Vector2.right * inputHorizontal * fuerzaMovimiento);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeadBarrier"))
        {
            estaVivo = false;
            rb.linearVelocity = Vector2.zero;
            rb.simulated = false; 
            return;
        }

        if (!collision.CompareTag("Player"))
        {
            canJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            canJump = false;
        }
    }

    public void InverseControls()
    {
        hasInversedControls = true;
        StartCoroutine("InverseControlsTimer");
    }

    IEnumerator InverseControlsTimer()
    {
        yield return new WaitForSeconds(5f);

        hasInversedControls = false;
    }
}
