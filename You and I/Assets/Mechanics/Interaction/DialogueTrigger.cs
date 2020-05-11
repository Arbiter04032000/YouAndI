using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public string treeTitle;
    public Dialogue dialogue;
    //public bool itemLine;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueMan>().startDialogue(dialogue);
    }
}
