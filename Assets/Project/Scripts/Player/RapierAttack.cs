using System.Runtime.CompilerServices;
using UnityEngine;

public class RapierAttack : MonoBehaviour
{
    [SerializeField] private float dmg;
    [SerializeField] private float attackReach;
    [SerializeField] private float attackLength;
    [SerializeField] private float comboWindow;

   

    private int enemyLayerIndex = 7; // temp hardcoded
    private LayerMask targetLayer;

    public void Awake()
    {
        targetLayer = 1 << enemyLayerIndex;
    }
    public void Attack(Vector3 originPoint, Vector3 direction)
    {
        
        
        RaycastHit hitCollider = new RaycastHit();
        bool targetHit = Physics.Raycast(originPoint, direction,out hitCollider, attackReach, targetLayer, QueryTriggerInteraction.Ignore);

        if (targetHit)
        {
            //deal dmg 
        }
    }
}
