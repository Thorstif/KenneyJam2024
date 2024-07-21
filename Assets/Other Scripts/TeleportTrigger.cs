using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public GameObject targetLocation;  // The GameObject to teleport to

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            TeleportPlayer(other.gameObject);
        }
    }

    private void TeleportPlayer(GameObject player)
    {
        if (targetLocation != null)
        {
            player.transform.position = targetLocation.transform.position;
        }
        else
        {
            Debug.LogError("Target location is not set!");
        }
    }
}