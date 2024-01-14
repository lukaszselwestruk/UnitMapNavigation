using System;
using System.Linq;
using UnityEngine;

namespace GameLogic
{
    public class UnitSelectLeader : MonoBehaviour
    {
        [SerializeField] private Unit unitToPromote;
        [SerializeField] public Unit leader;
        private void Start()
        {
            UnitSelectSystem.Instance.OnSelectedUnitChanged += UnitSelectSystem_OnSelectedUnitChanged;
            UnitSelectSystem.Instance.OnSelectedUnitChangeLider += UnitSelectSystem_OnSelectedUnitChangeLider;
        }
        
        private void UnitSelectSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
        {
            if (UnitSelectSystem.Instance.GetSelectedUnit() == unitToPromote)
            {
                unitToPromote.PromoteToLeader();
            }
            else
            {
                unitToPromote.DemoteFromLeader();
            }
        }
        
        private void UnitSelectSystem_OnSelectedUnitChangeLider(object sender, EventArgs empty)
        {
       
            var units = UnitManager.Instance.Units;
            foreach (var unit in units.Where(unit => unit.IsLeader))
            {
                leader = unit;
                break;
            }
        }

        
    }
}
