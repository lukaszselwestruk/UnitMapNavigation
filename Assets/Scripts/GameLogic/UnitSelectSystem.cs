using System;
using GameLogic.Grid;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameLogic
{
    public class UnitSelectSystem : MonoBehaviour
    {
        
        public static UnitSelectSystem Instance { get; private set; }
        public event EventHandler OnSelectedUnitChanged;
        public event EventHandler OnSelectedUnitChangeLider;
        
        [SerializeField] private Unit selectedUnit;
        [SerializeField] private LayerMask unitLayerMask;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one UnitSelectSystem");
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
                if (EventSystem.current.IsPointerOverGameObject()) return;
                if (TryHandleUnitSelection()) return;
                
                GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseToWorld.GetPosition());
                if (selectedUnit.GetMoveComponent().IsValidActionGridPosition(mouseGridPosition))
                {
                    selectedUnit?.GetMoveComponent().MoveTo(mouseGridPosition);
                    ChangeLeader();
                }
            }
        }

        private bool TryHandleUnitSelection()
        {
            var ray = Camera.main!.ScreenPointToRay(Input.mousePosition); // not expensive in Unity 2022
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

        public void SetSelectedUnit(Unit unit)
        {
            selectedUnit = unit;
            OnSelectedUnitChanged?.Invoke(this, EventArgs.Empty);
        }
        private void ChangeLeader()
        {
            OnSelectedUnitChangeLider?.Invoke(this, EventArgs.Empty);
        }
       
        public Unit GetSelectedUnit()
        {
            return selectedUnit;
        }
    }
    
}
