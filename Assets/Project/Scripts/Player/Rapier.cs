using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Rapier : MonoBehaviour
{
    [SerializeField] private System.Collections.Generic.List <RapierAttack> attacks;
    

    private int comboIndex = 0;
    private float lastAttackTimeStamp;
    private float combowWindowStamp;

    private RapierAttack attack;
   
    
    public void OnAttackInput(InputAction.CallbackContext context)
    {

        if (context.performed)
        {
            if (comboIndex > attacks.Count) { comboIndex = 0; } //resets indec if at the end of combo
            attack = attacks[comboIndex];

            combowWindowStamp = Time.time - lastAttackTimeStamp;
            lastAttackTimeStamp = Time.time;

            if (combowWindowStamp > attack.getComboWindow) { comboIndex = 0; } //resets index if combow window is missed

            ExecuteAttack(attack);
            
        }
        
    }

    IEnumerator ExecuteAttack(RapierAttack attack)
    {
        yield return new WaitForSeconds(attack.getHitDelay);
        attack.Attack(transform.position, transform.forward);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * attacks[comboIndex].getAttackLength);
    }

}


