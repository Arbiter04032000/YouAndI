using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public static InputTest instance;
    public Player1_Controls controls;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        controls = new Player1_Controls();
        controls.Gameplay.Interact.performed += ctx => Interact();
    }

    void Interact()
    {
        print("Test");
    }
}
