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

    private void Start()
    {
    }


    private void Update()
    {
        ///



        ////
       

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

        //Debug.Log(gameObject.name + ": " + finalVelocity);


        finalVelocity.y += direction.y * gravity * Time.deltaTime;


        controller.Move(finalVelocity * Time.deltaTime);
       



    }

    private void LookWhereYouWalk()
    {
        Vector3 direction = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f) * new Vector3(input.x, 0, input.y);
        transform.rotation = Quaternion.Euler(0f, camera.transform.eulerAngles.y, 0f);
        direction.Normalize();

        
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
