﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueMan : MonoBehaviour
{
    public Text nameText;
    public Text diagText;
    public GameObject contButton;
    //public Animator animator;
    private Queue<string> queue;
    private Dialogue dialogueScript;

    public GameObject dialogueOptions;
    public GameObject boxParent;

    public Inventory inventory;
    public Player1_Movement player;
    private PlayerCollider playerColl;

    Player1_Controls controls;

    List<Button> responsesList;
    int i;
    Button target;

    void Start()
    {
        i = 0;
        queue = new Queue<string>();
        dialogueOptions.SetActive(false);
        playerColl = player.GetComponent<PlayerCollider>();

        controls = new Player1_Controls();

        controls.Gameplay.Interact.performed += ctx => Interact();
        foreach(Transform child in dialogueOptions.transform)
        {
            responsesList[i] = child.GetComponent<Button>();
            i++;
        }
    }

    

    public void startDialogue(Dialogue dialogue)
    {


        HideDialogueOptions();
        //animator.SetBool("IsOpen", true);
        boxParent.SetActive(true);

        nameText.text = dialogue.name;
        queue.Clear();

        player.enabled = false;

        foreach (string sentence in dialogue.sentences)
        {
            queue.Enqueue(sentence);
        }

        dialogueScript = dialogue;

        DisplayNextSentence();
    }

    void Interact()
    {
        print("Attempting continue");
        if (contButton.activeSelf == true)
        {
            contButton.GetComponent<Button>().onClick.Invoke();
        }
        if (dialogueOptions.activeSelf == true)
        {
            target.onClick.Invoke();
        }
    }

    public void DisplayNextSentence()
    {
        if (queue.Count == 0 && dialogueScript.responses.Length == 0)
        {
            EndDialogue();
            return;
        }

        if (queue.Count == 0 && dialogueScript.responses.Length > 0)
        {
            ShowDialogueOptions();
            return;
        }

        string sentence = queue.Dequeue();

        //diagText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        diagText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            diagText.text += letter;
        }
        yield return new WaitForSeconds(0.05f);
    }

    public void EndDialogue()
    {
        //animator.SetBool("IsOpen", false);
        if(dialogueScript.itemLine == true)
        {
            
        }

        boxParent.SetActive(false);
        Debug.Log("Dialogue ended");

        player.enabled = true;
        playerColl.diagActive = false;
    }

    void ShowDialogueOptions()
    {
        Debug.Log("Reading" + dialogueScript.responses + " size" + dialogueScript.responses.Length);
        if (contButton.activeSelf == true)
        {
            contButton.SetActive(false);
            dialogueOptions.SetActive(true);
        }

        int i = 0;
        foreach (Transform response in dialogueOptions.transform.GetChild(0).GetChild(0))
        {
            if (i == dialogueScript.responses.Length)
            {
                break;
            }
            response.GetComponentInChildren<Text>().text = dialogueScript.responses[i].response;
            response.GetComponentInChildren<Button>().interactable = true;

            if (dialogueScript.responses[i] != null)
            {
                response.GetComponent<Button>().onClick.AddListener(dialogueScript.responses[i].dialogue.TriggerDialogue);
            }

            i++;
        }
        /*foreach (Transform response in dialogueOptions.transform.GetChild(0).GetChild(0))
        {
            if (response.GetComponentInChildren<Text>().text == "")
            {
                response.gameObject.SetActive(false);
            }
        }*/
        
    }

    void HideDialogueOptions()
    {
        dialogueOptions.SetActive(false);
        contButton.SetActive(true);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}

