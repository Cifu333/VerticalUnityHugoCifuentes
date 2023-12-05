using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Input_Manager : MonoBehaviour
{
    public static Input_Manager _INPUT_MANAGER;

    private PlayerControl playerInputs;

    private Vector2 leftAxisValue = Vector2.zero;
    private float timeSinceCrouchPressed = 0f;
    private float timeSinceJumpPressed = 0f;
    private float timeSinceHatLeft = 0f;
    private bool crouch = false;

    private bool jumpButtonPressed = false;
    private float escButtonvar = 0.1f;


    //private bool Jump = false;
    private bool a;

    private void Awake()
    {
        if (_INPUT_MANAGER != null && _INPUT_MANAGER != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerInputs = new PlayerControl();
            playerInputs.Character.Enable();
            playerInputs.Character.Movement.performed += LeftAxisUpdate;
            playerInputs.Character.pause.performed += escButton;
           

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
   

        timeSinceJumpPressed += Time.deltaTime;
        timeSinceCrouchPressed += Time.deltaTime;
        escButtonvar += Time.deltaTime;


        InputSystem.Update();

    }




   


    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();



        //Debug.Log("Magnitude: " + leftAxisValue.magnitude);
        //Debug.Log("Normalize: " + leftAxisValue.normalized);
    }

    public Vector2 GetLeftAxisUpdate()
    {
        return leftAxisValue.normalized;
    }

    public bool GetLeftAxisPressed()
    {

        return leftAxisValue.x != 0 || leftAxisValue.y != 0;
    }

    private void escButton(InputAction.CallbackContext context)
    {
        escButtonvar = 0;
    }

    public float getescButton()
    {
        return escButtonvar;
    }


   

}
