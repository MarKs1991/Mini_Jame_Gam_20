using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardAnimationEvents : MonoBehaviour
{
    private Animator animator = new Animator();
    public EnemyGuardTriggerEvent enemyGuardTriggerEvent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CommenceAttack()
    {
        animator.SetBool("isAttacking", true);
    }

    public void CeaseAttack()
    {
        animator.SetBool("isAttacking", false);
    }

    public void AttackCheck()
    {
        enemyGuardTriggerEvent.PlayerDamageCheck();
    }
}
