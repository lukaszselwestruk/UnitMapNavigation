using System;
using GameLogic.Grid;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public class Unit : MonoBehaviour
    {

        private GridPosition _gridPosition;
        private Move _move;
        [SerializeField] public bool isFollower;
        public bool IsLeader { get; private set; }
        public float MoveSpeed { get; private set; } 
        public float Mobility { get; private set; } 
        public float Stamina { get; private set; } 
        
        private void Awake()
        {
            _move = GetComponent<Move>();
            SetRandomStats(0.5f, 10f);
        }

        private void SetRandomStats(float min, float max)
        {
            MoveSpeed = Random.Range(min, max);
            Mobility = Random.Range(min, max);
            Stamina = Random.Range(min, max);
        }
        private void Start()
        {
            _gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            LevelGrid.Instance.AddUnitAtGridPosition(_gridPosition, this);
        }
        private void Update()
        {
            GridPosition newgridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
            if(newgridPosition != _gridPosition)
            {
                LevelGrid.Instance.UnitMovedGridPosition(this, _gridPosition, newgridPosition);
                _gridPosition = newgridPosition;
            }
        }
        
        public void PromoteToLeader()
        {
            IsLeader = true;
            isFollower = false; 
        }

        public void DemoteFromLeader()
        {
            IsLeader = false;
            isFollower = true;
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
