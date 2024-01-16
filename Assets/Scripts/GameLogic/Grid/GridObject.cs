using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;

namespace GameLogic.Grid
{
    public class GridObject
    {

        private GridSystem _gridSystem;
        private GridPosition _gridPosition;
        private List<Unit> _units;

        public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            this._gridSystem = gridSystem;
            this._gridPosition = gridPosition;
            _units = new List<Unit>();
        }

        public override string ToString()
        {
            string unitString = "";
            foreach (var unit in _units)
            {
                unitString += unit + "\n";
            }
            return _gridPosition.ToString() + "\n" + unitString;
        }

        public void AddUnit(Unit unit)
        {
            _units.Add(unit);
        }

        public void RemoveUnit(Unit unit)
        {
            _units.Remove(unit);
        }
        public List<Unit> GetUnitList()
        {
            return _units;
        }

        public bool HasAnyUnit()
        {
            return _units.Count > 0;
        }
    }
}

