using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator animator;
    public Transform target;
    public float rotationSpeed = 5f;
    public float walkSpeed = 10.0f;
    private float seenRange = 100f;
    private float attackRange = 25f;
    public AudioSource deathSound;

    void Start()
    {
        //target = Camera.main.transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animator.GetBool("isDead") == false)
            FollowTarget();
    }

    private void FollowTarget()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        //Debug.Log("Distance: " + distance);
        if (distance > seenRange)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isAttacking", false);
            return;
        }

        if (distance < attackRange)
        {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Axe"))
        {
            animator.SetBool("isDead", true);
            StartCoroutine(PlayDeathSoundWithDelay(0.7f));
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
