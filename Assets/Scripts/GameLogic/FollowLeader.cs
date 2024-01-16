using UnityEngine;

namespace GameLogic
{
    [RequireComponent(typeof(UnitSelectLeader))]
    public class FollowLeader : MonoBehaviour
    {
        [SerializeField] private Unit unitFollowingLeader;
        private UnitSelectLeader _unitSelectLeader;
        private void Start()
        {
            _unitSelectLeader = GetComponent<UnitSelectLeader>();
        }

        private void Update()
        {
            if (!unitFollowingLeader.IsLeader)
            {
                unitFollowingLeader.GetMoveComponent().MoveTo(_unitSelectLeader.leader.GetGridPosition());
            }
        }
    }
}


