using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerScript : MonoBehaviour
{
    [SerializeField] InputAction movement;
    // Start is called before the first frame update
    void Start()
    {

    }
    void OnEnable()
    {
        movement.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = movement.ReadValue<Vector2>().x;
        Debug.Log(horizontalThrow);
        float verticalThrow = movement.ReadValue<Vector2>().y;
        Debug.Log(verticalThrow);

    }
}
