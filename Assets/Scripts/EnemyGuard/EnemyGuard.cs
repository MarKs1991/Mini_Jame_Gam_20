using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuard : MonoBehaviour
{
    public float enemyHealth = 3f;
    public float damage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected!");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ApplyDamage();
        }
    }

    public void ApplyDamage()
    {
        Debug.Log("Player got damaged!");
        GameObject.FindWithTag("Player").GetComponent<CharacterController2D>().PlayPlayerDamage();
        //ToDo: Apply damage to player
        //ToDo: Trigger Player hurt animation
        //ToDo: Play hurt sound effect
    }
}
