using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    public AudioSource characterAudioSource;
    public List<AudioClip> clipList = new List<AudioClip>();
    private enum audioMovementSoundClip {Jump1, Jump2, Jump3, Jump4, Hurt1, Hurt2, Hurt3, Hurt4, None};

    private PlayerAnimationEvents animeEvents;
    private bool executeJump = false;

    // Start is called before the first frame update
    void Start()
    {
        animeEvents = this.transform.GetChild(0).GetComponent<PlayerAnimationEvents>();
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            animeEvents.RunningStarted();
        }
        else
        {
            if (isGrounded || r2d.velocity.magnitude < 0.01f)
            {
                moveDirection = 0;
            }
            animeEvents.IdleStarted();
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (moveDirection < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }

        // Jumping Anticipation
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            float randomNumber = Random.Range(0f, 1f);
            if (randomNumber < 0.25f)
            {
                characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Jump1];
            }
            else if (randomNumber > 0.25f && randomNumber < 0.5f)
            {
                characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Jump2];
            }
            else if (randomNumber > 0.5f && randomNumber < 0.75f)
            {
                characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Jump3];
            }
            else
            {
                characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Jump4];
            }
            characterAudioSource.Play();

            animeEvents.JumpingStarted();
            
        }

        if (executeJump)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }

        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, (t.position.y + 1.5f), cameraPos.z);
        }
    }

    private void LateUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider)
                {
                    isGrounded = true;
                    if (animeEvents.GetLandingState())
                    {
                        Debug.Log("Jump about to be finished!");
                        animeEvents.LandingAchieved();
                    }
                    
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
    }

    public void PlayPlayerDamage()
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
        else
        {
            characterAudioSource.clip = clipList[(int)audioMovementSoundClip.Hurt4];
        }
    }

    public void SetExecuteJumpingTrigger(bool set)
    {
        Debug.Log("SetExecuteJumpingTrigger: " + set);
        executeJump = set;
    }
}
