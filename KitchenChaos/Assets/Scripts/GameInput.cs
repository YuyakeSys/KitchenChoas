using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{

    public static GameInput Instance { get; private set; }

    //delegate can be customized
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractAlternateAction;
    public event EventHandler OnPauseAction;

    private PlayerInputActions playeriInputActions;

    private void Awake()
    {
        Instance = this;
        playeriInputActions = new PlayerInputActions();
        playeriInputActions.Player.Enable();

        // c# events
        playeriInputActions.Player.Interact.performed += Interact_performed;
        playeriInputActions.Player.InteractAlternate.performed += InteractAlternate_performed;
        playeriInputActions.Player.Pause.performed += Pause_performed;
    }

    //Unsubscribe
    public void OnDestroy()
    {
        playeriInputActions.Player.Interact.performed -= Interact_performed;
        playeriInputActions.Player.InteractAlternate.performed -= InteractAlternate_performed;
        playeriInputActions.Player.Pause.performed -= Pause_performed;

        playeriInputActions.Dispose();
    }

    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void InteractAlternate_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAlternateAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        // ? NON conditional operator
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNomalized()
    {
        Vector2 inputVector = playeriInputActions.Player.Move.ReadValue<Vector2>();


        // getkey stay true when using press the button
        /*        if (Input.GetKey(KeyCode.W))
                {
                    inputVector.y = +1;
                }
                if (Input.GetKey(KeyCode.A))
                {
                    inputVector.y = -1;
                }
                if (Input.GetKey(KeyCode.S))
                {
                    inputVector.x = -1;
                }
                if (Input.GetKey(KeyCode.D))
                {
                    inputVector.x = +1;
                }*/

        //Debug.Log(inputVector);
        inputVector = inputVector.normalized;

        return inputVector;
    }
}
