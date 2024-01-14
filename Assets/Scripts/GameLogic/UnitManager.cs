using System.Collections.Generic;
using UnityEngine;

namespace GameLogic
{
    public class UnitManager : MonoBehaviour
    {
        public static UnitManager Instance { get; private set; }
        
        [SerializeField] private GameObject unitsContainer;
        public List<Unit> Units { get; private set; }
        
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
        }

        private void AddUnitsToList()
        {
            var unitComponents = unitsContainer.GetComponentsInChildren<Unit>();
            foreach (var go in unitComponents)
            {
                Units.Add(go);
            }
        }
    }
}
