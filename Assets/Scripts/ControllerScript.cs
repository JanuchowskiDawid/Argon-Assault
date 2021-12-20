using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerScript : MonoBehaviour
{
    [SerializeField] InputAction movement;
    [SerializeField] InputAction firing;
    [SerializeField] float controlSpeed = 10f;

    [SerializeField] float xRange = 10f;

    [SerializeField] GameObject[] lasers;

    [SerializeField] float yRange = 6f;

    [SerializeField] float positionPitchFactor = -2f;
    [SerializeField] float controlPitchFactor = -10f;
    [SerializeField] float positionYawFactor = 2.6f;
    [SerializeField] float controlRollFactor = -6f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnEnable()
    {
        movement.Enable();
        firing.Enable();
    }

    void OnDisable()
    {
        movement.Disable();
        firing.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessRotation();
        ProcessFiring();
    }

    private void ProcessFiring()
    {
        if (firing.ReadValue<float>() > 0.5f)
        {
            ActivateLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }

    private void DeactivateLasers()
    {
        foreach(GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }

    private void ActivateLasers()
    {
        foreach (GameObject laser in lasers)
        {
            laser.SetActive(true);
        }
    }

    private void ProcessRotation()
    {
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlPitchFactor;

        float pitch = pitchDueToPosition + pitchDueToControlThrow;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

    }

    private void ProcessMovement()
    {
        xThrow = movement.ReadValue<Vector2>().x;
        yThrow = movement.ReadValue<Vector2>().y;

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * controlSpeed;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}