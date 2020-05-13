using UnityEngine;
using UnityEngine.InputSystem;

public class Player1_Movement : MonoBehaviour
{
    public float speed = 10f;
    public float deadZone = 1f;


    Player1_Controls controls;
    float move;
    float width;

    void Awake()
    {
        controls = new Player1_Controls();
        width = gameObject.transform.localScale.x;


        controls.Gameplay.Move.performed += ProcessMovement;
        controls.Gameplay.Move.canceled += StopMovement;
    }

    private void ProcessMovement(InputAction.CallbackContext controller)
    {
        move = controller.ReadValue<float>();
    }

    private void StopMovement(InputAction.CallbackContext controller)
    {
        move = 0f;
    }

    void Update()
    {
        print(move);
        if (move < -deadZone)
        {
            gameObject.transform.localScale = new Vector3(width, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }
        else if (move > deadZone)
        {
            gameObject.transform.localScale = new Vector3(-width, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
        }

        Vector2 m = new Vector2(move * speed, 0f) * Time.deltaTime;
        transform.Translate(m, Space.World);
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

