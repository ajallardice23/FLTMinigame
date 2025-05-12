using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkliftController : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject winScreen;
    public GameObject pauseScreen;
    private float horizontalInput, verticalInput;
    private float currentSteerAngle, currentbreakForce;
    private bool isBreaking;

    //Credit to Prism on youtube for the tutorial on how to create realistic vehicle movements (https://www.youtube.com/@Prism-University). 
    //CREDIT ONLY FOR VEHICLE CODE REFER TO ASTERIKS
    
    
    //*VEHICLE CODE STARTS HERE* ----------------------------------------------------------------------------------------------------------------------------

    // Settings
    [SerializeField] private float motorForce, breakForce, maxSteerAngle;

    // Wheel Colliders
    [SerializeField] private WheelCollider frontLeftWheelCollider, frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider, rearRightWheelCollider;

    // Wheels
    [SerializeField] private Transform frontLeftWheelTransform, frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform, rearRightWheelTransform;
    
    //Forks
    [SerializeField] private GameObject forks;
    [SerializeField] private float forkMovementSpeed = 1.4f; 
    private void FixedUpdate() {
        //while deathscreen and winscreen not active allow movement (my code)
        if (!deathScreen.activeSelf && !winScreen.activeSelf && !pauseScreen.activeSelf)
        //while deathscreen and winscreen not active allow movement (my code)
       {
            GetInput();
            HandleMotor();
            HandleSteering();
            UpdateWheels();
        }
    }

    private void GetInput() {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor() {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking() {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }

    private void HandleSteering() {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels() {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
        Vector3 pos;
        Quaternion rotatewheel; 
        wheelCollider.GetWorldPose(out pos, out rotatewheel);
        wheelTransform.rotation = rotatewheel * Quaternion.Euler(0, 0, 90);
        wheelTransform.position = pos;
        


    }
    //*VEHICLE CODE ENDS HERE* ----------------------------------------------------------------------------------------------------------------------------

    public void Update()
    {
        //If the deathscreen and winscreen arent active, allow fork movement
        if (!deathScreen.activeSelf && !winScreen.activeSelf)
        {
            if (Input.GetKey(KeyCode.E))
            {
                MoveForks(Vector3.up);
            }

            if (Input.GetKey(KeyCode.Q))
            {
                MoveForks(Vector3.down);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                pauseScreen.SetActive(!pauseScreen.activeSelf);
            }
        }
            
        //pause in game movements
        if (pauseScreen.activeSelf || winScreen.activeSelf)
        {
            Time.timeScale = 0;
        }
        
        else
        {
            Time.timeScale = 1;
        }
    }

    //Movements for the forks
    private void MoveForks(Vector3 direction)
    {
        forks.transform.localPosition += direction * forkMovementSpeed * Time.deltaTime;
        Vector3 forksPosition = forks.transform.localPosition;
        //Setting limits for max&min height
        forksPosition.y = Mathf.Clamp(forksPosition.y, .35f, 1.2f);
        forks.transform.localPosition = forksPosition;
    }
}
