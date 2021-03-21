using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private InputController _inputController;
    private CameraController _cameraController;
    private GridHandler _gridHandler;

    private void Awake()
    {
        _cameraController = GetComponent<CameraController>();
        _inputController = InputController.Instance;
        _gridHandler = GetComponent<GridHandler>();
    }

    void Start()
    {
        _inputController.InputAction += InputHandler;
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
                    _gridHandler.NewItemHandler(gridPosition);
                break;
            case InputTypes.Canceled:
                break;
        }
    }
}