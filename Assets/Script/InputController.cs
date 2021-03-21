using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InputTypes
{
    Started, Performed, Canceled
}

public class InputController : MonoBehaviour
{
    public static InputController Instance;
    private InputManager _input;
    
    public event Action<InputTypes> InputAction = delegate(InputTypes types) {  };
    public event Action<InputTypes> PauseAction = delegate(InputTypes types) {  };

    private void Awake()
    {
        if (!Instance)
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        _input = new InputManager();
     
        
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    void Start()
    {
        _input.Player.Click.performed += _ => InputAction(InputTypes.Performed);
        _input.Player.Click.started += _ => InputAction(InputTypes.Started);
        _input.Player.Click.canceled += _ => InputAction(InputTypes.Canceled);
        
        _input.Player.PauseGame.performed += _ => PauseAction(InputTypes.Performed);
        _input.Player.PauseGame.started += _ => PauseAction(InputTypes.Started);
        _input.Player.PauseGame.canceled += _ => PauseAction(InputTypes.Canceled);
    }

    public Vector2 GetInputPosition()
    {
        return _input.Player.InputPosition.ReadValue<Vector2>();
    }
}
