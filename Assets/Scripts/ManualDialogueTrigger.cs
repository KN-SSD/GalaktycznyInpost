using UnityEngine;

public class ManualDialogueTrigger : MonoBehaviour
{
     private NPCDialogue NPCDialogue;
    void Start()
    {

        NPCDialogue = GetComponent<NPCDialogue>();
        Invoke("StartSceneDialogue", 0.1f);
    }

    private void StartSceneDialogue()
    {
        NPCDialogue.TriggerDialogue();
    }
    
}
