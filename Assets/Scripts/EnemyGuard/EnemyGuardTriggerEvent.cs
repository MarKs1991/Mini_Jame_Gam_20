using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardTriggerEvent : MonoBehaviour
{

    private BoxCollider2D boxCollider2D = new BoxCollider2D();
    public EnemyGuardAnimationEvents enemyGuardAnimationEvents;
    public EnemyGuard enemyGuard;
    private int layerNumber = 0;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player entered the enemy trigger area!");
            enemyGuardAnimationEvents.CommenceAttack();
            layerNumber = 12;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("Player exited the enemy trigger area!");
            enemyGuardAnimationEvents.CeaseAttack();
            layerNumber = 0;
        }
    }

    public void PlayerDamageCheck()
    {
        if (layerNumber == 0)
        {
            Debug.Log("Player was out of range. Tough luck!");
        }
        else if (layerNumber == 12)
        {
            Debug.Log("Player was in range. Apply damage!");
            enemyGuard.ApplyDamage();
            
        }
    }
}
