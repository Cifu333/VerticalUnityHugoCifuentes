using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    private CharacterController controller;

    private Vector2 input;

    private bool Ismoving = false;

    private int count = 0;

    [SerializeField]
    private float jumpForce = 5;

    [SerializeField]
    private float gravity = 1;

    private Vector3 finalVelocity = Vector3.zero;
    private float velocityXZ = 5f;

    private float rotationSpeed = 5f;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;

        controller = GetComponent<CharacterController>();
    }


    
    private void Update()
    {
        
       

        input = Input_Manager._INPUT_MANAGER.GetLeftAxisUpdate();

        if (Input_Manager._INPUT_MANAGER.GetLeftAxisPressed())
        {
            Ismoving = true;
        }
        else
        {
            Ismoving = false;
        }

        //Debug.Log(Ismoving);
        
        //Calcular direccion XZ
        Vector3 direction = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f) * new Vector3(input.x,0, input.y);
        //transform.rotation = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f);
        direction.Normalize();


        if (direction != Vector3.zero)
        {
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
            this.transform.forward = direction;
        }

        

        direction.y = -1f;

        //Calcular velocidad XZ
        finalVelocity.x = direction.x * velocityXZ;
        finalVelocity.z = direction.z * velocityXZ;


        //transform.LookAt(new Vector3(direction.x,0f, direction.z));

        //transform.rotation = new Vector3 (0f,transform.rotation.y, 0f);


        if (count == 3)
        {
            jumpForce = 5;
            count = 0;
        }

        if (controller.isGrounded)

        {
            Debug.Log("ISGROUND");
            //Debug.Log(Input_Manager._INPUT_MANAGER.GetJumpButonPresed());
            if (Input_Manager._INPUT_MANAGER.getJUmpButton())
            {
                Debug.Log("isjumping");
                finalVelocity.y = jumpForce;
                jumpForce += jumpForce;
                count++;
            }
          

        }

        finalVelocity.y += direction.y * gravity * Time.deltaTime;


        controller.Move(finalVelocity * Time.deltaTime);
       



    }

    private void LookWhereYouWalk()
    {
        Vector3 direction = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f) * new Vector3(input.x, 0, input.y);
        transform.rotation = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f);
        direction.Normalize();

        /*Vector3 eulerRotation = camera.transform.rotation.eulerAngles;

        if (direction.y < 0)
        {
            eulerRotation.y += 180f;
        }

        if (direction.x > 0)
        {
            eulerRotation.y += 90f;
        }

        if (direction.x < 0)
        {
            eulerRotation.y += 270f;
        }

        if (direction.x != 0 || direction.y != 0)
        {
            //transform.LookAt(direction);
        }*/
    }

    public Vector3 SetJump()
    {
        finalVelocity.y = 10;
        return finalVelocity;
    }

    public bool IsMoving()
    {
        return Ismoving;
    }

    
    public int Getcount()
    {
        return count;
    }

    public bool GetGround()
    {
        return controller.isGrounded;
    }

}
