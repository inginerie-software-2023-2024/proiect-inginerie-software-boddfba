using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrollStateController : MonoBehaviour
{
    private Animator animator;
    public Transform target;
    public float rotationSpeed = 5f;
    public float walkSpeed = 20.0f;
    private float health = 100f;
    private float seenRange = 100f;
    private float attackRange = 15f;
    private float timeSinceAttackStarted = 0f;
    [SerializeField]
    private float momentOfDamageInAttackAnimation;
    [SerializeField]
    private float damageValuePerAttack;
    private float attackAnimationClipLength;
    private bool alreadyDamagedPlayerDuringThisAttack;
    public AudioSource deathSound;
    [SerializeField]
    private int itemCodePlayerGetsWhenKilled;
    [SerializeField]
    private int itemQuantityPlayerGetsWhenKilled;
    private bool alreadyDroppedItem = false;

    void Start()
    {
        //target = Camera.main.transform;
        animator = GetComponent<Animator>();
        getAttackAnimationClipLength();
        animator.SetBool("isWalking", true);
        animator.SetBool("isDead", false);
        animator.SetBool("isAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("isDead") == false)
        {
                FollowTarget();
                DamagePlayer();
        }

    }

    private void FollowTarget()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        /*Debug.Log("Distance: " + distance);*/
        if (distance > seenRange)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            return;
        }

        if (distance < attackRange)
        {
            if (animator.GetBool("isAttacking") == false)
            {
                timeSinceAttackStarted = 0f;
                alreadyDamagedPlayerDuringThisAttack = false;
            }

            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", true);

            return;
        }
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        direction.y = 0;
        animator.SetBool("isWalking", true);
        animator.SetBool("isAttacking", false);

        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        transform.Translate(direction * walkSpeed * Time.deltaTime, Space.World);
    }

    private void DamagePlayer()
    {
        timeSinceAttackStarted += Time.deltaTime;

        if (animator.GetBool("isAttacking") == true && timeSinceAttackStarted >= momentOfDamageInAttackAnimation && alreadyDamagedPlayerDuringThisAttack == false)
        {
            FindAnyObjectByType<FrozenPlayerStats>().changeHealth(-damageValuePerAttack);
/*            Debug.Log("Health: " + FindAnyObjectByType<FrozenPlayerStats>().getHealth());*/
            alreadyDamagedPlayerDuringThisAttack = true;
        }


        if (timeSinceAttackStarted >= attackAnimationClipLength)
        {
            timeSinceAttackStarted = 0f;
            alreadyDamagedPlayerDuringThisAttack = false;
        }
    }

    private void getAttackAnimationClipLength()
    {
        AnimationClip[] clips = animator.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "attack2":
                    attackAnimationClipLength = clip.length;
                    break;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Axe"))
        {
            FrozenBrute frozenBrute = FindAnyObjectByType<FrozenBrute>();

            // Debug.Log(frozenBrute);
            Debug.Log("Troll Health: " + health);
            health -= frozenBrute.damage;

            if (health < 0f) {
                animator.SetBool("isDead", true);

                PlayDeathSoundWithDelay(1f);
                if (alreadyDroppedItem == false)
                {
                    FindAnyObjectByType<Inventory>().addItem(itemCodePlayerGetsWhenKilled, itemQuantityPlayerGetsWhenKilled);
                    alreadyDroppedItem = true;
                }
            }
        }
    }
    private IEnumerator PlayDeathSoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        if (deathSound != null)
        {
            deathSound.Play(); // Play the death sound effect after the delay
        }
    }
}
