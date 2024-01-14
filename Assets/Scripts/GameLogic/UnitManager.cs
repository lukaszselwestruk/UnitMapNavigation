using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class UnitManager : MonoBehaviour
    {
        public static UnitManager Instance { get; private set; }
        
        [SerializeField] private GameObject unitsContainer;
        public List<Unit> Units { get; private set; }
        public Unit John { get; private set; }
        public Unit George { get; private set; }
        public Unit David { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one UnitManager");
                Destroy(gameObject);
                return;
            }

            Instance = this;
            Units = new List<Unit>();
        }
        private void Start()
        {
            AddUnitsToList();
            SeparateUnitsToUnit();
        }

        private void AddUnitsToList()
        {
            var unitComponents = unitsContainer.GetComponentsInChildren<Unit>();
            foreach (var go in unitComponents)
            {
                Units.Add(go);
            }
        }

        private void SeparateUnitsToUnit()
        {
            foreach (var unit in Units)
            {
                switch (unit.name)
                {
                    case "John":
                        John = unit;
                        break;
                    case "George":
                        George = unit;
                        break;
                    case "David":
                        David = unit;
                        break;
                }
            }
        }
    }
}
