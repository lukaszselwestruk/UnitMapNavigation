using System;
using UnityEngine;

namespace GameLogic
{
    public class UnitSelectLeader : MonoBehaviour
    {
        [SerializeField] private Unit unit;

        private void Awake()
        {
            UnitSelectSystem.Instance.OnSelectedUnitChanged += UnitSelectSystem_OnSelectedUnitChanged;
        }

        private void UnitSelectSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
        {
            if (UnitSelectSystem.Instance.GetSelectedUnit() == unit)
            {
                unit.PromoteToLeader();
            }
            else
            {
                unit.DemoteFromLeader();
            }
        }
    }
}
