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
        [SerializeField] private TextMeshProUGUI textResponsivity;
        [SerializeField] private TextMeshProUGUI textStamina;
        private void Start()
        {
            UnitSelectSystem.Instance.OnSelectedUnitChanged += UnitSelectSystem_OnSelectedUnitChanged;
        }

        private void UnitSelectSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
        {
            var unit = UnitSelectSystem.Instance.GetSelectedUnit();
            textName.text = unit.name;
            textSpeed.text = unit.MoveSpeed.ToString("F1");
            textResponsivity.text = unit.Responsivity.ToString("F1");
            textStamina.text = unit.Stamina.ToString("F1");
        }
    }
}
