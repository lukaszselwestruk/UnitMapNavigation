using GameLogic;
using UnityEngine;

namespace UI
{
    public class UnitSelectButton : MonoBehaviour
    {
        public void JohnButtonClicked()
        {
            UnitSelectSystem.Instance.SetSelectedUnit(UnitManager.Instance.John);
        }
        public void GeorgeButtonClicked()
        {
            UnitSelectSystem.Instance.SetSelectedUnit(UnitManager.Instance.George);
        }
        public void DavidButtonClicked()
        {
            UnitSelectSystem.Instance.SetSelectedUnit(UnitManager.Instance.David);
        }
    }
}
