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
            ApplyDamage(collision.transform);

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            takeDamageFromPlayer(1);

        }
    }

    public void ApplyDamage()
    {
        if (GameObject.FindWithTag("Player").GetComponent<CharacterController2D>() != null)
            GameObject.FindWithTag("Player").GetComponent<CharacterController2D>().PlayPlayerDamage();

        if (GameObject.FindWithTag("Player").GetComponent<StatusManager>() != null)
            GameObject.FindWithTag("Player").GetComponent<StatusManager>().takeDamage(damage);

        //ToDo: Apply damage to player
        //ToDo: Trigger Player hurt animation
    }

    public void ApplyDamage(Transform transform)
    {
        if (transform.GetComponent<CharacterController2D>() != null)
            transform.GetComponent<CharacterController2D>().PlayPlayerDamage();

        if (transform.GetComponent<StatusManager>() != null)
            transform.GetComponent<StatusManager>().takeDamage(damage);
        //ToDo: Apply damage to player
        //ToDo: Trigger Player hurt animation
    }

    public void takeDamageFromPlayer(float dmg)
    {
        enemyHealth = enemyHealth - dmg;
        //TakeDmg Animation
      
    }
}
