using System.Collections.Generic;
using GameLogic.Grid;
using UnityEngine;

namespace GameLogic
{
    public class Move : MonoBehaviour
    {
        private Vector3 _targetPosition;
        [SerializeField] public bool _leaderHasMoved = false;
        [SerializeField] private int maxMoveDistance = 4;
        private Unit _unit;
        [SerializeField] public bool hasReachedTarget;
        private void Awake()
        {
            _targetPosition = transform.position;
        }

        private void Start()
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
                transform.position += moveDirection * (_unit.unitData.MoveSpeed * Time.deltaTime);
                hasReachedTarget = false;
            }
            else
            {
                hasReachedTarget = true; 
            }
        }
        public void MoveTo(GridPosition gridPosition)
        {
            if (_unit.unitData.IsLeader)
            {
                this._targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
            }
            else if (_unit.unitData.IsFollower)
            {
                this._targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition) - new Vector3(1f, 0, 1f);
            }
               
        }
        
        public bool IsValidActionGridPosition(GridPosition gridPosition)
        {
            var validGridPositionList = GetValidGridPositionList();
            return validGridPositionList.Contains(gridPosition);
        }

        private List<GridPosition> GetValidGridPositionList()
        {
            var validGridPositionList = new List<GridPosition>();

            var unitGridPosition = _unit.GetGridPosition();

            for (var x = -maxMoveDistance; x <= maxMoveDistance; x++)
            {
                for (var z = -maxMoveDistance; z <= maxMoveDistance; z++)
                {
                    var offsetGridPosition = new GridPosition(x, z);
                    var testGridPosition = unitGridPosition + offsetGridPosition;
              
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
