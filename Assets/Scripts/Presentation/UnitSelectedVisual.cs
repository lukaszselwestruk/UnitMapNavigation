using System;
using GameLogic;
using Unity.VisualScripting;
using UnityEngine;
using Unit = GameLogic.Unit;

namespace Presentation
{
    public class UnitSelectedVisual : MonoBehaviour
    { 
        [SerializeField] private Unit unit;

        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        private void Start()
        {
            UnitSelectSystem.Instance.OnSelectedUnitChanged += UnitSelectSystem_OnSelectedUnitChanged;
            UpdateVisual();
        }
        
        private void UnitSelectSystem_OnSelectedUnitChanged(object sender, EventArgs empty)
        {
            UpdateVisual();
        }

        private void UpdateVisual()
        {
            if (UnitSelectSystem.Instance.GetSelectedUnit() == unit)
            {
                _meshRenderer.enabled = true;
            }
            else
            {
                _meshRenderer.enabled = false;
            }
        }
    }
}

