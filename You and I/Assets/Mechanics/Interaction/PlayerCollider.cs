using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerCollider : MonoBehaviour
{
    public Button target;
    public Player1_Controls controls;
    Player1_Movement player;

    public DialogueMan diag;
    public bool diagActive;

    Color newColor;

    void Awake()
    {
        controls = new Player1_Controls();
        player = gameObject.GetComponent<Player1_Movement>();
        
        controls.Gameplay.Interact.performed += ctx => Interact();

        newColor = new Color(0.5f, 1f, 1f, 1f);
    }

    void Interact()
    {
        if (target == null)
        {
            return;
        }
        if (diagActive != true)
        {
            print("Attempting dialogue");
            target.onClick.Invoke();
            diagActive = true;
        }

    }

     void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && player.enabled == true)
        {
            print("Attempting dialogue");
            target.onClick.Invoke();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Entered Trigger");
        target = collision.gameObject.GetComponent<Button>();
        target.GetComponent<SpriteRenderer>().color = newColor;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        target.GetComponent<SpriteRenderer>().color = Color.white;
        target = null;
    }
}
