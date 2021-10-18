using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerScript : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] float controlSpeed;
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
        float newXPos = transform.localPosition.x + movement.ReadValue<Vector2>().x * Time.deltaTime * controlSpeed;
        float newYPos = transform.localPosition.y + movement.ReadValue<Vector2>().y * Time.deltaTime * controlSpeed;

        transform.localPosition = new Vector3(newXPos, newYPos, transform.localPosition.z);
    }
}
