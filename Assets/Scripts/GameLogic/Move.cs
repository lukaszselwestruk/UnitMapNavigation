using System.Collections.Generic;
using GameLogic.Grid;
using UnityEngine;

namespace GameLogic
{
    public class Move : MonoBehaviour
    {
        private Vector3 _targetPosition;

        [SerializeField] private int maxMoveDistance = 4;
        private Unit _unit;
        [SerializeField] public bool hasReachedTarget;
        private void Awake()
        {
            _targetPosition = transform.position;
        }
        void Start()
        {
            _targetPosition = transform.position;
            _unit = GetComponent<Unit>();
        }
        private void Update()
        {
            Motion();
        }

        private void Motion()
        {
            const float stoppingDistance = .1f;
            if (Vector3.Distance(transform.position, _targetPosition) > stoppingDistance)
            {
                var moveDirection = (_targetPosition - transform.position).normalized;
                transform.position += moveDirection * (_unit.MoveSpeed * Time.deltaTime);
                hasReachedTarget = false;
            }
            else
            {
                hasReachedTarget = true; 
            }
        }
        public void MoveTo(GridPosition gridPosition)
        {
            if (_unit.isFollower && !hasReachedTarget)
                this._targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition) - new Vector3(1f, 0, 1f);
            else
                this._targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
        }

        public bool IsValidActionGridPosition(GridPosition gridPosition)
        {
            List<GridPosition> validGridPositionList = GetValidGridPositionList();
            return validGridPositionList.Contains(gridPosition);
        }
        public List<GridPosition> GetValidGridPositionList()
        {
            List<GridPosition> validGridPositionList = new List<GridPosition>();

            GridPosition unitGridPosition = _unit.GetGridPosition();

            for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
            {
                for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
                {
                    GridPosition offsetGridPosition = new GridPosition(x, z);
                    GridPosition testGridPosition = unitGridPosition + offsetGridPosition;
              
                    if (!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                    {
                        continue;
                    }
             
                    if (unitGridPosition == testGridPosition)
                    {
                        continue;
                    }

                    if (LevelGrid.Instance.HasAnyUnitOnGridPosition(testGridPosition))
                    {
                        continue;
                    }
                    validGridPositionList.Add(testGridPosition);
                    
                }
            }

            return validGridPositionList;
        }


    }
}
