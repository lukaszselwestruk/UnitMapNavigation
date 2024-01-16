using System;
using System.Linq;
using GameLogic;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UnitStatsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI textName;
        [SerializeField] private TextMeshProUGUI textSpeed;
        [SerializeField] private TextMeshProUGUI textMobility;
        [SerializeField] private TextMeshProUGUI textStamina;
        private void Start()
        {
            UnitSelectSystem.Instance.OnSelectedUnitChanged += UnitSelectSystem_OnSelectedUnitChanged;
        }

        private void UnitSelectSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
        {
            var unit = UnitSelectSystem.Instance.GetSelectedUnit();
            textName.text = unit.name;
            textSpeed.text = unit.unitData.MoveSpeed.ToString("F1");
            textMobility.text = unit.unitData.Mobility.ToString("F1");
            textStamina.text = unit.unitData.Stamina.ToString("F1");
        }
    }
}
