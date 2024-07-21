using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class Conversation : MonoBehaviour
{
    private GameObject player;
    public GameObject chatBubble;
    public GameObject dialogPrefab;
    public GameObject promptIcon;
    public string[] dialogs;

    private int currentDialogIndex = 0;
    public bool dialogAtStart = false;
    private bool playerNear = false;
    private bool dialogPlaying = false;

    public string flagToSet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        promptIcon.SetActive(false);

        if(dialogAtStart)
        {
            LockPlayerMovement();
            playerNear = true;
            dialogPlaying = true;
            PlayNextDialog();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerNear && !dialogPlaying)
        {
            if(Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                LockPlayerMovement();
                dialogPlaying = true;
                PlayNextDialog();
            }
        }
        else if(dialogPlaying)
        {
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0) || Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                PlayNextDialog();
            }
        }
    }

    private void LockPlayerMovement()
    {
        Movement movement = player.GetComponent<Movement>();
        movement.enabled = false;
    }

    private void UnlockPlayerMovement()
    {
        Movement movement = player.GetComponent<Movement>();
        movement.enabled = true;
    }

    private void PlayNextDialog()
    {
        Destroy(chatBubble);

        if (currentDialogIndex >= dialogs.Length)
        {
            UnlockPlayerMovement();
            GameProgressManager.Instance.SetFlag(flagToSet, true);
            Destroy(this);
            return;
        }

        if (dialogs[currentDialogIndex].StartsWith("P:"))
        {
            chatBubble = Instantiate(dialogPrefab, player.transform.position + new Vector3(0, 1.3f, 0), quaternion.identity);
            dialogs[currentDialogIndex] = dialogs[currentDialogIndex].Substring(2);
        }
        else
        {
            chatBubble = Instantiate(dialogPrefab, gameObject.transform.position + new Vector3(0, 1.3f, 0), quaternion.identity);
        }

        chatBubble.GetComponentInChildren<TextMeshProUGUI>().text = dialogs[currentDialogIndex];
        chatBubble.transform.rotation = Quaternion.LookRotation(Vector3.forward);

        currentDialogIndex++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerNear = true;
            promptIcon.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerNear = false;
            promptIcon.SetActive(false);
        }
    }
}
