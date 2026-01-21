using UnityEngine;

public class Powerup_InverseControls : MonoBehaviour
{
    public void PowerupActivated(GameObject player)
    {
        player.GetComponent<MovimientoBola2D>()
            .enemyBall.GetComponent<MovimientoBola2D>().InverseControls();
    }
}
