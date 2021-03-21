using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] private Vector2Int matrixSize = new Vector2Int(20,20);
    [SerializeField] private Vector2 initialPosition = new Vector2(0.5f, 0.5f);
    [SerializeField] private GameObject gridItem;
    
    
    private GameObject[,] _gameMatrix;
    
    private void Awake()
    {
        _gameMatrix = new GameObject[matrixSize.x,matrixSize.x];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < matrixSize.x; i++)
        {
            for (int j = 0; j < matrixSize.y; j++)
            {
                Gizmos.DrawWireCube(initialPosition + new Vector2(i,j), Vector3.one );
            }
        }
    }
    
    public Vector2 RoundToMatrix(Vector2 input)
    {
        var roundedInput = new Vector2(Mathf.Floor(input.x), Mathf.Floor(input.y));
        
        if(roundedInput.x <= -1 ||  roundedInput.x >= matrixSize.x || 
           roundedInput.y <= -1 ||  roundedInput.y >= matrixSize.y) return Vector2.one * -1; 

        return roundedInput + initialPosition;
    }

    public void NewItemHandler(Vector2 gridPosition)
    {
        var roundedInput = new Vector2Int((int) Mathf.Floor(gridPosition.x), (int) Mathf.Floor(gridPosition.y));

        if (_gameMatrix[roundedInput.x, roundedInput.y])
        {
            var item = _gameMatrix[roundedInput.x, roundedInput.y];
            Destroy(item);
            _gameMatrix[roundedInput.x, roundedInput.y] = null;
        }
        else
        {
            var item = Instantiate(gridItem, new Vector3(gridPosition.x, gridPosition.y), 
                Quaternion.identity, transform);
            _gameMatrix[roundedInput.x, roundedInput.y] = item;
        }
        
    }
}
