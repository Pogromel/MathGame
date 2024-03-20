using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private Transform characterTransform;
    [SerializeField] private float movementSpeed;
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool isHeadBobEnabled;
    [SerializeField] private float headBobAplitude;
    [SerializeField] private float headBobFrequency;
    [SerializeField] private float returnSpeed;
    [SerializeField] private float ySpecificVelocity;
    [SerializeField] private float sprintChange;

    [Header("CameraControl")] 
    [SerializeField] private Transform cameraHolderTransform;

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Vector2 cameraSensitivity;
    [SerializeField] private float cameraRotationLimit;
    [SerializeField] private Vector3 cameraStartLocalPosition;
    private Vector2 cameraRotation = Vector2.zero;

    private void Start()
    {
        cameraStartLocalPosition = cameraTransform.localPosition;
        
    }

    private void Update()
    {
        Movement();
        Looking();
        UnderMapCheck();
        
    }

    private void Movement()
    {
        playerVelocity.z = Input.GetAxis("Vertical");
        playerVelocity.x = Input.GetAxis("Horizontal");

        playerVelocity.y = ySpecificVelocity;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerVelocity *= sprintChange;
        }

        playerVelocity *= movementSpeed * Time.deltaTime;
        playerVelocity = characterTransform.TransformDirection(playerVelocity);

        characterController.Move(playerVelocity);
    }

    private void Looking()
    {
        Vector2 mouseMovement = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        mouseMovement = mouseMovement * cameraSensitivity;
        cameraRotation.x += mouseMovement.x;
        cameraRotation.y += mouseMovement.y;
        cameraRotation.y = Mathf.Clamp(cameraRotation.y, -cameraRotationLimit, cameraRotationLimit);
        var xQuat = Quaternion.AngleAxis(cameraRotation.x, Vector3.up);
        var yQuat = Quaternion.AngleAxis(cameraRotation.y, Vector3.left);

        cameraHolderTransform.localRotation = yQuat;
        transform.localRotation = xQuat;
        if (isHeadBobEnabled && new Vector2(playerVelocity.x, playerVelocity.z).magnitude != 0)
        {
            Vector3 headBobber = new Vector3(0f, 0f, 0f);
            headBobber.y += Mathf.Sin(Time.time * headBobFrequency);
            headBobber *= headBobAplitude * Time.deltaTime;
            cameraTransform.localPosition += headBobber;
        }

        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, cameraStartLocalPosition,
            Time.deltaTime * returnSpeed);
    }

    private void UnderMapCheck()
    {
        if (transform.position.y <= -100)
        {
            transform.position = new Vector3(transform.position.x, 50f, transform.position.z);
        }
    }
    
}
