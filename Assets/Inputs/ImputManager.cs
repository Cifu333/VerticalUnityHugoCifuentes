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
    private bool crouchButtonPressed = false;
    private bool hatleft = false;


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
            playerInputs.Character.Jump.performed += JumpButtonPresed;
            playerInputs.Character.Movement.performed += LeftAxisUpdate;
            playerInputs.Character.Crouch.performed += CrouchButtonPresed;
            playerInputs.Character.Crouch.performed += CrouchButtonReleased;
            playerInputs.Character.Hat.performed += TrowHat;

            _INPUT_MANAGER = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        crouchButtonPressed = false;

        timeSinceJumpPressed += Time.deltaTime;
        timeSinceCrouchPressed += Time.deltaTime;
        InputSystem.Update();
    }

    private void JumpButtonPresed(InputAction.CallbackContext context)
    {
        jumpButtonPressed = !jumpButtonPressed;

        timeSinceJumpPressed = 0f;
        Debug.Log("ESPACIO");
    }



    private void TrowHat(InputAction.CallbackContext context)
    {
        hatleft = !hatleft;

        timeSinceHatLeft = 0f;
        //Debug.Log("tiras sombrero");
    }


    private void LeftAxisUpdate(InputAction.CallbackContext context)
    {
        leftAxisValue = context.ReadValue<Vector2>();



        //Debug.Log("Magnitude: " + leftAxisValue.magnitude);
        //Debug.Log("Normalize: " + leftAxisValue.normalized);
    }

    private void CrouchButtonPresed(InputAction.CallbackContext context)
    {
        crouch = true;
        Debug.Log("agacha");
    }

    private void CrouchButtonReleased(InputAction.CallbackContext context)
    {
        crouch = false;
        Debug.Log("se levanta");
    }



    public Vector2 GetLeftAxisUpdate()
    {
        return leftAxisValue.normalized;
    }

    public bool GetLeftAxisPressed()
    {

        return leftAxisValue.x != 0 || leftAxisValue.y != 0;
    }

    public bool getJUmpButton()
    {
        //Debug.Log("Pruebasalto");
        return jumpButtonPressed;
    }

    public float GetTimeJumpButton()
    {
        return timeSinceJumpPressed;  
;
    }


    public bool GetTrowHat()
    {
        return hatleft;
        
    }

    public float GetCrouchButonPresed()
    {
        return timeSinceCrouchPressed;
    }

}
