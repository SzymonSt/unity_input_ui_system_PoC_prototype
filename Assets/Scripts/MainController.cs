using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[System.Serializable]
public class MoveEvent : UnityEvent<float, float> { }

[System.Serializable]
public class PauseEvent : UnityEvent<bool> { }

[System.Serializable]
public class PlayerControllerStateSwitchEvent : UnityEvent<bool> { }

public class MainController : MonoBehaviour
{
    public static MainController Instance { get; private set; }
    private  Controls _controls;
    public bool isUIControllerEnabled;
    public bool isPlayerControllerEnabled;
    public bool isGamePaused;
    public MoveEvent moveEvent;
    public PauseEvent pauseEvent;
    public PlayerControllerStateSwitchEvent playerControllerStateSwitchEvent;
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        _controls = new Controls();
        isPlayerControllerEnabled = _controls.Player.enabled;
        isUIControllerEnabled = _controls.UI.enabled;
        isGamePaused = false;
    }
    void OnEnable()
    {
        _controls.UI.Enable();
        isUIControllerEnabled = _controls.UI.enabled;
        _controls.UI.Pause.performed += OnPause;

        _controls.Player.Enable();
        isPlayerControllerEnabled = _controls.Player.enabled;
        _controls.Player.Move.performed += OnMove;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 movement = context.ReadValue<Vector2>();
        moveEvent.Invoke(movement.x, movement.y);
    }
    private void OnPause(InputAction.CallbackContext context)
    {
        isGamePaused = !isGamePaused;
        pauseEvent.Invoke(isGamePaused);
    }
    public void DisableUIInputActionMap()
    {
        _controls.UI.Disable();
        isUIControllerEnabled = _controls.UI.enabled;
    }
    public void EnableUIInputActionMap()
    {
        _controls.UI.Enable();
        isUIControllerEnabled = _controls.UI.enabled;
    }
    public void DisablePlayerInputActionMap()
    {
        _controls.Player.Disable();
        isPlayerControllerEnabled = _controls.Player.enabled;
        playerControllerStateSwitchEvent.Invoke(isPlayerControllerEnabled);
    }
    public void EnablePlayerInputActionMap()
    {
        _controls.Player.Enable();
        isPlayerControllerEnabled = _controls.Player.enabled;
        playerControllerStateSwitchEvent.Invoke(isPlayerControllerEnabled);
    }
}
