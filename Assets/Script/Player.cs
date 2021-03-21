using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputController _inputController;
    private CameraController _cameraController;
    private GridHandler _gridHandler;
    private bool runGame = false;
    
    public event Action<bool> RunGame = delegate(bool b) {  }    ;
    
    private void Awake()
    {
        _cameraController = GetComponent<CameraController>();
        _inputController = InputController.Instance;
        _gridHandler = GetComponent<GridHandler>();
    }

    void Start()
    {
        _inputController.InputAction += InputHandler;
        _inputController.PauseAction += PauseAction;

    }

    private void PauseAction(InputTypes obj)
    {
        
        switch (obj)
        {
            case InputTypes.Started:
                runGame = !runGame;
                RunGame(runGame);
                break;
            case InputTypes.Performed:
                break;
            case InputTypes.Canceled:
                break;

        }
    }

    private void InputHandler(InputTypes obj)
    {
        switch (obj)
        {
            case InputTypes.Performed:

                break;
            case InputTypes.Started:
                var wordP = _inputController.GetInputPosition();
                var result = _cameraController.GetWorldPosition(wordP);
                var gridPosition = _gridHandler.RoundToMatrix(result);
                if (gridPosition != Vector2.one * -1)
                    _gridHandler.ItemChangeHandler(gridPosition);
                break;
            case InputTypes.Canceled:
                break;
        }
    }
}