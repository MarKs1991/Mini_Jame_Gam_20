using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimationEvents : MonoBehaviour
{
    private Animator animator = new Animator();
    public List<AudioClip> clipList = new List<AudioClip>();
    private enum PlayerSounds { Walk1, Walk2, Walk3, Walk4}
    private AudioSource audioSource = new AudioSource();
    public CharacterController2D characterController2D;

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
}
