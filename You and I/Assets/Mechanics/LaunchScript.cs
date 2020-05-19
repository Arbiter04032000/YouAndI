using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScript : MonoBehaviour
{
    public Dialogue dialogue;
    bool trigger;

    private void Awake()
    {
        trigger = false;
    }

    void Update()
    {
        if (trigger == false)
        {
            FindObjectOfType<DialogueMan>().startDialogue(dialogue, this.gameObject);
            trigger = true;
        }
    }
    
}
