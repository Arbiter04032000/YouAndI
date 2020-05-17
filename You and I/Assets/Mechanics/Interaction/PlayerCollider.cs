using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerCollider : MonoBehaviour
{
    public Button target;
    Player1_Controls controls;
    Player1_Movement player;

    private void Awake()
    {
        controls = new Player1_Controls();
        player = gameObject.GetComponent<Player1_Movement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && player.enabled == true)
        {
            print("Attempting dialogue");
            target.onClick.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("Entered Trigger");
        target = collision.gameObject.GetComponent<Button>();
    }

    
}
