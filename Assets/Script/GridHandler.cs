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
    [SerializeField] private bool runGame;


    private Player _player;
    private Dictionary<Vector2Int, GameObject> itensPositions;
    private GameObject[,] _gameMatrix;

    private void Awake()
    {
        _player = GetComponent<Player>();
        itensPositions = new Dictionary<Vector2Int, GameObject>();
        _gameMatrix = new GameObject[matrixSize.x, matrixSize.x];
    }

    private void Start()
    {
        _player.RunGame += item => runGame = item;
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

    public void ItemChangeHandler(Vector2 gridPosition)
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

    private HashSet<Vector2Int> GetAroundCells()
    {
        var positions = new HashSet<Vector2Int>();

        foreach (var matrixPosition in itensPositions.Keys)
        {
            for (int i = -1; i < 2; i++)
            {
                if (i + matrixPosition.x < 0 || i + matrixPosition.x >= matrixSize.x) continue;

                for (int j = -1; j < 2; j++)
                {
                    if (j + matrixPosition.y < 0 || j + matrixPosition.y >= matrixSize.y) continue;

                    positions.Add(new Vector2Int(i + matrixPosition.x, j + matrixPosition.y));
                }
            }

        }
        
        
        return positions;
    }

    private GameObject ItemInPosition(Vector2Int position)
    {
        return _gameMatrix[position.x, position.y];
    }

    private bool ChangeVerification(Vector2Int position)
    {
        int sum = 0;
        for (int i = -1; i < 2; i++)
        {
            if (i + position.x < 0 || i + position.x >= matrixSize.x) continue;

            for (int j = -1; j < 2; j++)
            {
                if (j + position.y < 0 || j + position.y >= matrixSize.y || (j == 0 && 0 == i)) continue;
                
                sum += _gameMatrix[i + position.x, j + position.y] == null ? 0 : 1;
            }
        }

        bool hasItem = ItemInPosition(position) != null;
        
        //Unpopulated Item
        if (!hasItem ) return sum == 3;
        

        if (sum <= 1 || sum > 3)
            return hasItem;
        
        return !hasItem;
        
    }

   
    IEnumerator GameLoop()
    {
        while (true)
        {
            yield return new WaitUntil(() => runGame);
            List<Vector2Int> positionsToChange = new List<Vector2Int>();
            HashSet<Vector2Int> toAnaliseItems = GetAroundCells();
            
            print(toAnaliseItems.Count);
                // toAnaliseItems.a
            foreach(var cell in toAnaliseItems)
            {
                if(ChangeVerification(cell))
                    positionsToChange.Add(cell);
            }
            

            yield return new WaitForSeconds(iterationSpeed);
        
            positionsToChange.ForEach(
                item =>  ItemChangeHandler(item + initialPosition)
                );
            
        
        }
    }
}