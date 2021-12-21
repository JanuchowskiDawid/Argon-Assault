using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ControllerScript : MonoBehaviour
{
    [Header("Control settings")]
    [SerializeField] InputAction movement;
    [SerializeField] InputAction firing;

    [Header("Movement settings")]
    [Tooltip("Defines how fast ship is moving")] [SerializeField] float controlSpeed = 10f;
    [Tooltip("Defines how far ship can move in ±x direction on screen")] [SerializeField] float xRange = 10f;
    [Tooltip("Defines how far ship can move in ±y direction on screen")] [SerializeField] float yRange = 6f;


    [Header("Rotation settings")]
    [Tooltip("Defines position factor on Pitch rotation")] [SerializeField] float positionPitchFactor = -2f;
    [Tooltip("Defines current movement factor on Pitch rotation")] [SerializeField] float controlPitchFactor = -10f;
    [Tooltip("Defines position factor on Yaw rotation")] [SerializeField] float positionYawFactor = 2.6f;
    [Tooltip("Defines current movement factor on Roll rotation")] [SerializeField] float controlRollFactor = -6f;

    [Header("Shooting settings")]
    [SerializeField] GameObject[] lasers;

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
            ActivateLasers(true);
        }
        else
        {
            ActivateLasers(false);
        }
    }

    private void ActivateLasers(bool isActive)
    {
        foreach (GameObject laser in lasers)
        {
            var emission = laser.GetComponent<ParticleSystem>().emission;
            emission.enabled = isActive;
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