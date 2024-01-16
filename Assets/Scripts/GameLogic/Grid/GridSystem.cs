using UnityEngine;

namespace GameLogic.Grid
{
    public class GridSystem
    {
        private readonly int _width;
        private readonly int _height;
        private readonly float _cellSize;
        private readonly GridObject[,] _gridObjects;
    
        public GridSystem(int width, int height, float cellSize)
        {
            this._width = width;
            this._height = height;
            this._cellSize = cellSize;
        
            _gridObjects = new GridObject[_width, _height];
        
            for (var x = 0; x < _width; x++)
            {
                for (var z = 0; z < _height; z++)
                { 
                    GridPosition gridPosition = new GridPosition(x, z);
                    _gridObjects[x, z] = new GridObject(this, new GridPosition(x, z));
               
                }
            }
        }
    
        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return new Vector3(gridPosition.x, 0, gridPosition.z) * _cellSize;
        }
    
        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return new GridPosition(
                Mathf.RoundToInt(worldPosition.x / _cellSize),
                Mathf.RoundToInt(worldPosition.z/ _cellSize));
        }

        public void CreateDebugObjects(Transform debugPrefab)
        {
            for (var x = 0; x < _width; x++)
            {
                for (var z = 0; z < _height; z++)
                { 
                    GridPosition gridPosition = new GridPosition(x, z);
                    Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
                    GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                    gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                }
            }
        }
        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return _gridObjects[gridPosition.x, gridPosition.z];
        }
    
        public bool IsValidGridPosition(GridPosition gridPosition)
        {
            return gridPosition.x >= 0 && 
                   gridPosition.z >=0 && 
                   gridPosition.x < _width && 
                   gridPosition.z < _height;
        }
    }
}
