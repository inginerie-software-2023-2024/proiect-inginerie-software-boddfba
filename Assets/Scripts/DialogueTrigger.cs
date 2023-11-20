using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    bool player_detected = false;
    [SerializeField]
    private NPCConversation myConversation;
    private void Update()
    {
        if(player_detected && Input.GetKeyDown(KeyCode.F))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player_detected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detected= false;
    }
}
