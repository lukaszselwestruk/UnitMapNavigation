using System;
using UnityEngine;

namespace GameLogic
{
    public class UnitSelectSystem : MonoBehaviour
    {
        
        public static UnitSelectSystem Instance { get; private set; }
        public event EventHandler OnSelectedUnitChanged;
        
        [SerializeField] private Unit selectedUnit;
        [SerializeField] private LayerMask unitLayerMask;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.Log("There is more than one UnitSelectSystem");
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            SetSelectedUnit(selectedUnit);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (TryHandleUnitSelection()) return;
                selectedUnit?.MoveTo(MouseToWorld.GetPosition());
            }
        }

        private bool TryHandleUnitSelection()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // not expensive in Unity 2022
            if (Physics.Raycast(ray, out var raycastHit, float.MaxValue, unitLayerMask))
            {
                if (raycastHit.transform.TryGetComponent<Unit>(out var unit))
                {
                    SetSelectedUnit(unit);
                    return true;
                }
            }
            return false;
        }

        private void SetSelectedUnit(Unit unit)
        {
            selectedUnit = unit;
            OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
        }

        public Unit GetSelectedUnit()
        {
            return selectedUnit;
        }

    }
    
}
