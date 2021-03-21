using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    // Start is called before the first frame update
    private void Awake()
    {
    }

    public Vector3 GetWorldPosition(Vector2 position)
    {
        return _camera.ScreenToWorldPoint(position);
    }
}
