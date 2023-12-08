using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControl : MonoBehaviour
{
    public bool disabled = false;

    public float walkingSpeed = 7.5f;
    public float runningSpeed = 11.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 45.0f;

    public GameObject QuestPanelOne;
    public GameObject QuestPanelTwo;
    public GameObject QuestPanel;
    public GameObject QuestPanelStart;
    public GameObject KeyCollectPanel;
    public GameObject CastleOpenPanel;
    public GameObject QuestInfoPanel;
    public GameObject FinalPanel;

    public GameObject EnemiesObj;



    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canMove = true;

    void Start()
    {
        QuestPanelStart.SetActive(true);

        characterController = GetComponent<CharacterController>();

    }




    void Update()
    {

        if (!disabled)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            bool isRunning = Input.GetKey(KeyCode.LeftShift);
            float curSpeedX = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Vertical") : 0;
            float curSpeedY = canMove ? (isRunning ? runningSpeed : walkingSpeed) * Input.GetAxis("Horizontal") : 0;
            float movementDirectionY = moveDirection.y;
            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
            {
                moveDirection.y = jumpSpeed;
            }
            else
            {
                moveDirection.y = movementDirectionY;
            }


            if (!characterController.isGrounded)
            {
                moveDirection.y -= gravity * Time.deltaTime;
            }


            characterController.Move(moveDirection * Time.deltaTime);


            if (canMove)
            {
                rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);


                playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
                transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            QuestPanelOne.SetActive(true);

        }

        if (Input.GetKey(KeyCode.R))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            QuestPanelTwo.SetActive(true);

        }

        if (EnemiesObj.transform.childCount == 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            FinalPanel.SetActive(true);
            Destroy(gameObject);

        }

    }


    public void QuestPanelStartClose()
    {
        Debug.Log("Týkladýn");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        QuestPanelStart.SetActive(false);
    }

    public void QuestOneClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        QuestPanelOne.SetActive(false);
    }

    public void QuestTwoClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        QuestPanelTwo.SetActive(false);
    }


    public void KeyCollectPanelClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        KeyCollectPanel.SetActive(false);
    }

    public void CastleOpenPanelClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        CastleOpenPanel.SetActive(false);
    }

    public void QuestInfoPanelClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        QuestInfoPanel.SetActive(false);
    }

    public void FinalPanelClose()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FinalPanel.SetActive(false);
    }
}

