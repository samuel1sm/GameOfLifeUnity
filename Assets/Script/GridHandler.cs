using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridHandler : MonoBehaviour
{
    [SerializeField] private Vector2Int matrixSize = new Vector2Int(20, 20);
    [SerializeField] private Vector2 initialPosition = new Vector2(0.5f, 0.5f);
    [SerializeField] private GameObject gridItem;
    [SerializeField] private float iterationSpeed = 1f;

    private Dictionary<Vector2Int, GameObject> itensPositions;
    private GameObject[,] _gameMatrix;

    private void Awake()
    {
        itensPositions = new Dictionary<Vector2Int, GameObject>();
        _gameMatrix = new GameObject[matrixSize.x, matrixSize.x];
    }

    private void Start()
    {
        StartCoroutine(GameLoop());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < matrixSize.x; i++)
        {
            for (int j = 0; j < matrixSize.y; j++)
            {
                Gizmos.DrawWireCube(initialPosition + new Vector2(i, j), Vector3.one);
            }
        }
    }

    public Vector2 RoundToMatrix(Vector2 input)
    {
        var roundedInput = new Vector2(Mathf.Floor(input.x), Mathf.Floor(input.y));

        if (roundedInput.x <= -1 || roundedInput.x >= matrixSize.x ||
            roundedInput.y <= -1 || roundedInput.y >= matrixSize.y) return Vector2.one * -1;

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
            itensPositions.Remove(new Vector2Int(roundedInput.x, roundedInput.y));
        }
        else
        {
            var item = Instantiate(gridItem, new Vector3(gridPosition.x, gridPosition.y),
                Quaternion.identity, transform);
            _gameMatrix[roundedInput.x, roundedInput.y] = item;
            itensPositions.Add(new Vector2Int(roundedInput.x, roundedInput.y), item);
        }

    }

    private List<Vector2Int> GetAroundCells(Vector2Int matrixPosition)
    {
        var positions = new List<Vector2Int>();
        for (int i = -1; i < 2; i++)
        {
            if (i + matrixPosition.x < 0 || i + matrixPosition.x >= matrixSize.x) continue;

            for (int j = -1; j < 2; j++)
            {
                if (j + matrixPosition.y < 0 || j + matrixPosition.y >= matrixSize.y) continue;

                positions.Add(new Vector2Int(i + matrixPosition.x, j + matrixPosition.y));
            }
        }

        return positions;
    }

    private int CountAroundCells()
    {
        return 0;
    }
    
    private bool ChangeVerification(Vector2Int position)
    {
        return true;

    }

    IEnumerator GameLoop()
    {
        while (true)
        {
            List<Vector2Int> positionsToChange = new List<Vector2Int>();
            foreach (var value in itensPositions)
            {
                foreach(var cell in GetAroundCells(value.Key))
                {
                    
                    
                }
            }

            yield return new WaitForSeconds(iterationSpeed);
        }
    }
}