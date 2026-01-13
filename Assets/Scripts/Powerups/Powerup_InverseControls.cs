using UnityEngine;

public class Powerup_InverseControls : MonoBehaviour
{
    public void PowerupActivated(GameObject player)
    {
        Debug.Log("Powerup Obtained by: " + player.name);
        Destroy(gameObject);
    }
}
