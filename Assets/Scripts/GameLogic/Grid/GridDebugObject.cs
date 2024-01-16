using UnityEngine;
using TMPro;
namespace GameLogic.Grid
{
    public class GridDebugObject : MonoBehaviour
    {
        [SerializeField] private TextMeshPro textmeshPro;
        private GridObject _gridObject;

        public void SetGridObject(GridObject gridObject)
        {
            this._gridObject = gridObject;
        }
        private void Update()
        {
            textmeshPro.text = _gridObject.ToString();
        }
    }
    
}
