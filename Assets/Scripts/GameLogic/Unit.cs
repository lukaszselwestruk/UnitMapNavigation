using UnityEngine;

namespace GameLogic
{
    public class Unit : MonoBehaviour
    {
        private Vector3 _targetPosition;
      
        private void Update()
        {
            MoveTowardsTargetPosition();

            if(Input.GetMouseButtonDown(0))
                MoveTo(MouseToWorld.GetPosition());
        }

        private void MoveTowardsTargetPosition()
        {
            const float stoppingDistance = .1f;
            if (Vector3.Distance(transform.position, _targetPosition) > stoppingDistance)
            {
                var moveDirection = (_targetPosition - transform.position).normalized;
                var moveSpeed = 4f;
                transform.position += moveDirection * (moveSpeed * Time.deltaTime);
            }
        }

        private void MoveTo(Vector3 targetPosition)
        {
            this._targetPosition = targetPosition;
        }
    }
}
