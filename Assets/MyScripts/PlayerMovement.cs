using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour {
    public Camera playerCamera;
    public float walkSpeed = 4f;
    public float runSpeed = 6f;
    public float jumpPower = 2f;
    public float gravity = 10f;
 
    public GameObject pauseText;
    public GameObject reachObject;

 
    public float lookSpeed = 2f;
    public float lookXLimit = 60f;
 
 
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;
 
    public static bool canMove = true;
    
    CharacterController characterController;
    void Start() {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseText.SetActive(false);
        reachObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward * 2f;
    }
 
    void Update() {
        if (Input.GetButtonDown("Pause")) {
                Time.timeScale = 0f;
                pauseText.SetActive(true);
                canMove = false;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
        }

        if(!canMove) {
            return;
        }

        #region Handles Movment
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
 
        // Press Left Shift to run
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);
 
        #endregion
 
        #region Handles Jumping
        if (Input.GetButton("Jump") && canMove && characterController.isGrounded) {
            moveDirection.y = jumpPower;
        } else {
            moveDirection.y = movementDirectionY;
        }
 
        if (!characterController.isGrounded) {
            moveDirection.y -= gravity * Time.deltaTime;
        }
 
        #endregion
 
        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);
        reachObject.transform.position = playerCamera.transform.position + playerCamera.transform.forward * 2f;
 
        if (canMove) {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
 
        #endregion
    }
}
 