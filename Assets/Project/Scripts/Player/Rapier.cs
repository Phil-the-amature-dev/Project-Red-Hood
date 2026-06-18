using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class Rapier : MonoBehaviour
{
    [SerializeField] private System.Collections.Generic.List <RapierAttack> attacks;
    

    private int comboIndex = 0;
    private float lastAttackTimeStamp;
    private float combowWindowStamp;
    private bool isAttacking;
    private float timeTillNextAttack;

    private RapierAttack attack;
   
    
    public void OnAttackInput(InputAction.CallbackContext context)
    {

        
        if (context.performed)
        {
           
            if (!isAttacking)
            {
                Debug.Log("attacking");
                isAttacking = true;
                if (comboIndex >= attacks.Count) { comboIndex = 0; } //resets index if at the end of combo
                attack = attacks[comboIndex];

                combowWindowStamp = Time.time - lastAttackTimeStamp;
                lastAttackTimeStamp = Time.time;

                if (combowWindowStamp > attack.getComboWindow) { comboIndex = 0; } //resets index if combow window is missed
                ExecuteAttack(attack);
            }
        }
        
    }

    public void Update()
    {
        if (isAttacking)
        {
            if (Time.time < lastAttackTimeStamp + attack.getAttackLength)
            {
                return;
            }
            else
            {
                isAttacking = false;
                Debug.Log("attackEnd");
            }
        }
    }


    IEnumerator ExecuteAttack(RapierAttack attack)
    {
        RapierAttack previousAttack = attacks[(comboIndex - 1 + attacks.Count) % attacks.Count];


        yield return new WaitForSeconds(attack.getHitDelay);
        attack.Attack(transform.position, transform.forward);
        Debug.Log("Combo Index: " + comboIndex);
        comboIndex += 1;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + new Vector3(0,1,0), transform.forward * attacks[comboIndex].getAttackReach);
    }

}


