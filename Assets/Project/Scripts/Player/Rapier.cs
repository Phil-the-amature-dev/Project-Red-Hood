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
    private float lastAttackTimeStamp = 0;
    private float combowWindowStamp;
    private bool isAttacking;
    private float timeTillNextAttack;

    private RapierAttack attack;


    public void Start()
    {
        Debug.Log(comboIndex);
        lastAttackTimeStamp = 0;
        attack = attacks[0];
    }

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

                if (Time.time - lastAttackTimeStamp > attack.getComboWindow) { comboIndex = 0; } //resets index if combow window is missed
                StartCoroutine(ExecuteAttack(attack));
                comboIndex += 1;

                lastAttackTimeStamp = Time.time;
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


    public IEnumerator ExecuteAttack(RapierAttack attack)
    {
        //RapierAttack previousAttack = attacks[(comboIndex - 1 + attacks.Count) % attacks.Count];


        //play animation
        yield return new WaitForSeconds(attack.getHitDelay); //waits for apex of attack (aka when the ray should cast)
        attack.Attack(transform.position, transform.forward); //cast ray
        Debug.Log("Combo Index: " + comboIndex);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position + new Vector3(0,1,0), transform.forward * attacks[comboIndex].getAttackReach);
    }

}


