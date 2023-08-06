using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimationEvents : MonoBehaviour
{
    private Animator animator = new Animator();
    public List<AudioClip> clipList = new List<AudioClip>();
    private enum PlayerSounds { Walk1, Walk2, Walk3, Walk4, Shoot1, Shoot2, BonkWoosh1, BonkWoosh2, BonkWoosh3, Bonk1, Bonk2, Bonk3, None}
    private AudioSource audioSource = new AudioSource();
    public CharacterController2D characterController2D;
    public Transform bulletSpawn;
    public GameObject bulletGO;

    bool isLanding = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void JumpingConcluded()
    {
        animator.SetBool("isJumping", false);
        characterController2D.SetExecuteJumpingTrigger(false);
    }

    public void JumpingStarted()
    {
        Debug.Log("Jump started!");
        StartPlayerJump();
        animator.SetBool("isJumping", true);
        animator.SetBool("JumpFinished", false);
    }

    public void RunningStarted()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isMoving", true);
    }

    public void IdleStarted()
    {
        animator.SetBool("isJumping", false);
        animator.SetBool("isMoving", false);
    }

    public void WalkSoundInit()
    {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber < 0.25f)
        {
            audioSource.clip = clipList[(int)PlayerSounds.Walk1];
            audioSource.Play();
        }
        else if (randomNumber > 0.25f && randomNumber < 0.5f)
        {
            audioSource.clip = clipList[(int)PlayerSounds.Walk2];
            audioSource.Play();
        }
        else if(randomNumber > 0.5f && randomNumber < 0.75f)
        {
            audioSource.clip = clipList[(int)PlayerSounds.Walk3];
            audioSource.Play();
        }
        else
        {
            audioSource.clip = clipList[(int)PlayerSounds.Walk4];
            audioSource.Play();
        }
    }

    public void StartPlayerJump()
    {
        characterController2D.SetExecuteJumpingTrigger(true);
    }

    public void FinishPlayerJump()
    {
        characterController2D.SetExecuteJumpingTrigger(false);
        isLanding = true;
    }

    public void LandingAchieved()
    {
        animator.SetBool("JumpFinished", true);
        isLanding = false;
    }

    public bool GetLandingState()
    {
        return isLanding;
    }

    public void StartShooting()
    {
        animator.SetBool("isShooting", true);
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= 0.5f)
        {
            Debug.Log("Shot 1");
            audioSource.clip = clipList[(int)PlayerSounds.Shoot1];
        }
        else
        {
            Debug.Log("Shot 2");
            audioSource.clip = clipList[(int)PlayerSounds.Shoot2];
        }
        audioSource.Play();
    }

    public void FireBullet()
    {
        Instantiate(bulletGO, bulletSpawn.transform.position, Quaternion.identity);
    }

    public void StopShooting()
    {
        animator.SetBool("isShooting", false);
    }

    public bool GetIsShootingState()
    {
        return animator.GetBool("isShooting");
    }

    public void StartBonking()
    {
        animator.SetBool("isBonking", true);
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber < 0.3f)
        {
            audioSource.clip = clipList[(int)PlayerSounds.BonkWoosh1];
        }
        else if (randomNumber > 0.3f && randomNumber < 0.6f )
        {
            audioSource.clip = clipList[(int)PlayerSounds.BonkWoosh2];
        }
        else
        {
            audioSource.clip = clipList[(int)PlayerSounds.BonkWoosh3];
        }
        audioSource.Play();
    }

    public void StopBonking()
    {
        animator.SetBool("isBonking", false);
    }

    public void DoDamage()
    {
        Debug.Log("Bonk an enemy!");

        //ToDo: Only play these sounds, on a successful hit
        
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber < 0.3f)
        {
            audioSource.clip = clipList[(int)PlayerSounds.Bonk1];
        }
        else if (randomNumber > 0.3f && randomNumber < 0.6f)
        {
            audioSource.clip = clipList[(int)PlayerSounds.Bonk2];
        }
        else
        {
            audioSource.clip = clipList[(int)PlayerSounds.Bonk3];
        }
        audioSource.Play();     
        

        //ToDo: Do damage to foes
    }

    public bool GetBonkingState()
    {
        return animator.GetBool("isBonking");
    }
}
