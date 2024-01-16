using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObjects")]
public class UnitData : ScriptableObject
{
    [SerializeField] private bool isLeader;
    public bool IsLeader
    {
        get => isLeader;
        private set => isLeader = value;
    }
    [SerializeField] private float moveSpeed;
    public float MoveSpeed
    {
        get => moveSpeed;
        private set => moveSpeed = value;
    }
    
    [SerializeField] private float mobility;
    public float Mobility
    {
        get => mobility;
        private set => mobility = value;
    }
    [SerializeField] private float stamina;
    public float Stamina 
    {
        get => stamina;
        private set => stamina = value;
    }
    [SerializeField] private bool isFollower;
    public bool IsFollower
    {
        get => isFollower;
        private set => isFollower = value;
    }
    
    private void OnEnable()
    {
        SetRandomStats(0.5f, 10f);
    }

    private void SetRandomStats(float min, float max)
    {
        MoveSpeed = Random.Range(min, max);
        Mobility = Random.Range(min, max);
        Stamina = Random.Range(min, max);
    }
    public void PromoteToLeader()
    {
        IsLeader = true;
        isFollower = false; 
    }

    public void DemoteFromLeader()
    {
        IsLeader = false;
        isFollower = true;
    }
}
