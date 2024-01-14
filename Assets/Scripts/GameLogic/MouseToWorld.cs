using UnityEngine;
using UnityEngine.EventSystems;

namespace GameLogic
{
    public class MouseToWorld : MonoBehaviour
    {
        private static MouseToWorld _instance;
        
        [SerializeField] private LayerMask mouseGroundLayerMask;

        private void Awake()
        {
            _instance = this;
        }
        
        private void Update()
        {
            transform.position = MouseToWorld.GetPosition();
        }
        
        public static Vector3 GetPosition()
        {
            var ray = Camera.main!.ScreenPointToRay(Input.mousePosition); // not expensive in Unity 2022
            Physics.Raycast(ray, out var raycastHit, float.MaxValue, _instance.mouseGroundLayerMask);
            return raycastHit.point;
        }
    }
}