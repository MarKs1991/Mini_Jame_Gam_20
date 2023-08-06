using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGuardAnimationEvents : MonoBehaviour
{
    private Animator animator = new Animator();
    public EnemyGuardTriggerEvent enemyGuardTriggerEvent;

    //Audio
    private enum audioMovementSoundClip { Hurt1, Hurt2, Hurt3, Dying };
    public AudioSource characterAudioSource;
    public List<AudioClip> clipList = new List<AudioClip>();


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
    public void getHitByMelee()
    {
        animator.SetTrigger("MeleeDamage");
        PlayEnemyDamageSoundeffect();
    }

    public void getHitByWave()
    {
        animator.SetTrigger("WaveDamage");
        PlayRangeDamageSoundeffect();
    }

    public void dying()
    {
        animator.SetTrigger("isDying");
        PlayDeathSoundeffect();
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
     

    public void PlayRangeDamageSoundeffect()
    {
        float randomNumber = Random.Range(0f, 1f);

        
        if (randomNumber < 0.5f)
        {
            characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Hurt2];
        }
        else if (randomNumber > 0.5f && randomNumber < 0.75f)
        {
            characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Hurt3];
        }


        characterAudioSource.Play();
    }
    public void PlayEnemyDamageSoundeffect()
    {
        float randomNumber = Random.Range(0f, 1f);

        if (randomNumber < 0.25f)
        {
            characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Hurt1];
        }
        else if (randomNumber > 0.25f && randomNumber < 0.5f)
        {
            characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Hurt2];
        }
        else if (randomNumber > 0.5f && randomNumber < 0.75f)
        {
            characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Hurt3];
        }


        characterAudioSource.Play();
    }
    public void PlayDeathSoundeffect()
    {
        float randomNumber = Random.Range(0f, 1f);

        characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Dying];



        characterAudioSource.Play();
    }
}
