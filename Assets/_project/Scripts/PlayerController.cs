using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    bool canPlay = true;
    [SerializeField]
    Transform pivotCamera;
    [SerializeField]
    Camera camera;
    [SerializeField]
    CharacterController characterController;
    [SerializeField]
    AudioSource audioSourcePas;

    [Space]
    [Header("Parameter")]
    [SerializeField]
    float speed = 2;
    [SerializeField]
    float gravity = 2;
    [SerializeField]
    float sensitivity = 2;
    [SerializeField]
    float footStepThreshold = 100;

    float speedX = 0;
    float speedZ = 0;
    float currentRotationX = 0;
    float footStepCount = 0;



    // Update is called once per frame
    void Update()
    {
        if (canPlay == true)
        {
            CheckPlayerInputCamera();
            Move();
        }
    }

    public void SetCanPlay(bool b)
    {
        canPlay = b;
    }

    public void Move()
    {
        if (Mathf.Abs(Input.GetAxis("Vertical")) != 0)
        {
            speedZ = Input.GetAxis("Vertical");
        }
        else
        {
            speedZ = 0;
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) != 0)
        {
            speedX = Input.GetAxis("Horizontal");
        }
        else
        {
            speedX = 0;
        }

        var forward = pivotCamera.forward;
        var right = pivotCamera.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        Vector3 move = right * speedX + forward * speedZ;
        move *= speed;

        //rigidbodyCharacter.velocity = move * defaultSpeed * Time.deltaTime;
        characterController.Move(move * Time.deltaTime);
        characterController.Move(new Vector3(0, gravity * Time.deltaTime, 0));
        if(characterController.isGrounded)
        {
            footStepCount += move.magnitude * Time.deltaTime;
            if(footStepCount >= footStepThreshold)
            {
                footStepCount = 0;
                audioSourcePas.pitch = Random.Range(0.5f, 1.5f);
                audioSourcePas.Play();
            }
        }
    }

    public void CheckPlayerInputCamera()
    {
        float rotateHorizontal = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float rotateVertical = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        currentRotationX -= rotateVertical;
        currentRotationX = Mathf.Clamp(currentRotationX, -90f, 90f);

        pivotCamera.localRotation = Quaternion.Euler(currentRotationX, 0f, 0f);
        transform.Rotate(Vector3.up * rotateHorizontal);
    }


}
