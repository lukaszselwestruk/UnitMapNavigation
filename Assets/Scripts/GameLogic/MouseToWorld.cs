using UnityEngine;

namespace GameLogic
{
    public class MouseToWorld : MonoBehaviour
    {
        private static MouseToWorld instance;
        
        [SerializeField] private LayerMask mouseGroundLayerMask;

        private void Awake()
        {
            instance = this;
        }
        
        private void Update()
        {
            transform.position = MouseToWorld.GetPosition();
        }
        
        public static Vector3 GetPosition()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // not expensive in Unity 2022
            Physics.Raycast(ray, out var raycastHit, float.MaxValue, instance.mouseGroundLayerMask);
            return raycastHit.point;
        }
    }
}