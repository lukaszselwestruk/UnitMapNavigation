using UnityEngine;

namespace GameLogic
{
    public class Unit : MonoBehaviour
    {
        private Vector3 _targetPosition;
        [SerializeField] private float moveSpeed = 4f;
        [SerializeField] public bool isFollower = false;
        [SerializeField] public bool hasReachedTarget = false;
        public bool IsLeader { get; private set; } = false;
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
                transform.position += moveDirection * (moveSpeed * Time.deltaTime);
                hasReachedTarget = false;
            }
            else
            {
                hasReachedTarget = true; 
            }
        }
        
        public void MoveTo(Vector3 targetPosition)
        {
            var stoppingDistance = isFollower ? 2f : .1f;

            if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
            {
                this._targetPosition = targetPosition;
            }
            else
            {
                this._targetPosition = transform.position; 
            }
        }

        private void FixedUpdate()
        {
            var hitColliders = Physics.OverlapSphere(transform.position, 1f);
            foreach (var hitCollider in hitColliders)
            {
                var unit = hitCollider.GetComponent<Unit>();
                if (!ReferenceEquals(unit, null) && unit != this && hasReachedTarget)
                {
                    _targetPosition += (_targetPosition - unit.transform.position).normalized;
                }
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
    }
}
