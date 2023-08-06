using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeRange : MonoBehaviour
{
    public StatusManager statusManager;

    public Transform enemyInRange;
    public bool isAttacking;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {

            statusManager.setAttackRange(true);

            Debug.Log("EnemyInRange!");

            statusManager.setAttackTarget(collision.transform);

           // Debug.Log(collision.transform);
            //if(isAttacking)
            //{
               /* if (collision.transform.GetComponent<EnemyGuard>())
                {
                    collision.transform.GetComponent<EnemyGuard>().takeDamageFromPlayer(1);
                    isAttacking = false;
                }*/
            //}


           
            //enemyInRange = collision
        }
       
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("Player entered the enemy trigger area!");

            statusManager.setAttackRange(false);
            statusManager.setAttackTarget(null);
        }
    }
    

    
}
