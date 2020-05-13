using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class CursorScript : MonoBehaviour
{
    public int controllerNo;

    Controls controls;
    Vector2 move;

    private void Awake()
    {
        controls = new Controls();

        //InputUser.PerformPairingWithDevice(controller1);
    }

    void MoveCursor()
    {

    }

    private void Start()
    {

        controls.Gameplay.RightStick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        controls.Gameplay.RightStick.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Gameplay.RightStick.canceled += ctx => move = Vector2.zero;

        //Vector2 m = new Vector2(move.x, move.y) * Time.deltaTime;
        transform.Translate(move);
    }
}
