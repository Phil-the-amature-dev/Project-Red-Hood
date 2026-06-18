using System.Runtime.CompilerServices;
using System.Transactions;
using UnityEngine;
using UnityEngine.UIElements;

public class RapierAttack : MonoBehaviour
{
    
    
    [SerializeField] private float dmg;
    [SerializeField] private float attackReach;
    [SerializeField] private float attackLength;
    [SerializeField] private float hitDelay;
    [SerializeField] private float comboWindow; //seconds player has after last attack to execute this attack 

   

    private int enemyLayerIndex = 7; // temp hardcoded
    private LayerMask targetLayer;
    private bool comboHit;

    public bool getComboHit => comboHit;
    public float getComboWindow => comboWindow;

    public float getHitDelay => hitDelay;
    public float getAttackLength => attackLength;
    public float getAttackReach => attackReach;


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
