using GameLogic.Grid;
using UnityEngine;

namespace GameLogic
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] public UnitData unitData;
        private GridPosition _gridPosition;
        private Move _move;
        
        private void Awake()
        {
            _move = GetComponent<Move>();
        }
        
        private void Start()
        {
            _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            LevelGrid.Instance.AddUnitAtGridPosition(_gridPosition, this);
        }
        private void Update()
        {
            var newgridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            if (newgridPosition == _gridPosition) return;
            
            LevelGrid.Instance.UnitMovedGridPosition(this, _gridPosition, newgridPosition);
            _gridPosition = newgridPosition;
        }

        public Move GetMoveComponent()
        {
            return _move;
        }
        public GridPosition GetGridPosition()
        {
            return _gridPosition;
        }
        
    }
}
