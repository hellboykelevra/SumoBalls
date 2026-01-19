using UnityEngine;

public class Powerup_InverseControls : MonoBehaviour
{
    public void PowerupActivated(GameObject player)
    {
        if (player.CompareTag("PlayerA")) GameObject.FindGameObjectsWithTag("PlayerB");
        else GameObject.FindGameObjectsWithTag("PlayerA");
    }
}
