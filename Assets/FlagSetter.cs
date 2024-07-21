using UnityEngine;

public class FlagSetter : MonoBehaviour
{
    public string flagName;
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            GameProgressManager.Instance.SetFlag(flagName, true);
        }
    }

}
