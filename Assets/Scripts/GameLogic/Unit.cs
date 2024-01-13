using System;
using Unity.VisualScripting;
using UnityEngine;

namespace GameLogic
{
    public class Unit : MonoBehaviour
    {
        private Vector3 _targetPosition;
        [SerializeField] private string characterName;
        [SerializeField] private bool isLeader = false;


        private void Awake()
        {
            _targetPosition = transform.position;
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
                var moveSpeed = 4f;
                transform.position += moveDirection * (moveSpeed * Time.deltaTime);
            }
        }

        public void MoveTo(Vector3 targetPosition)
        {
            this._targetPosition = targetPosition;
        }

        public void PromoteToLeader()
        {
            isLeader = true;
        }

        public void DemoteFromLeader()
        {
            isLeader = false;
        }
    }
}
