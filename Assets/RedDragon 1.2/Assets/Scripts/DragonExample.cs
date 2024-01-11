using UnityEngine;
using System.Collections;
using UnityEditor;

public class DragonExample : MonoBehaviour
{
    private Animator anim;
    int IdleSimple;
    int IdleAgressive;
    int Bite;
    int Die;
    public Transform target;
    private float seenRange = 100f;
    public bool isDead = false;
    private float attackRange = 25f;
    [SerializeField]
    private float momentOfDamageInAttackAnimation;
    [SerializeField]
    private float damageValuePerAttack;
    [SerializeField]
    private int itemCodePlayerGetsWhenKilled;
    [SerializeField]
    private int itemQuantityPlayerGetsWhenKilled;
    private float timeSinceAttackStarted = 0f;
    private bool alreadyDamagedPlayerDuringThisAttack;
    private float attackAnimationClipLength;
    [SerializeField]
    public bool playerIsAttacking;
    [SerializeField]
    public int nr_of_healts;
    int count_healts = 0;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        IdleAgressive = Animator.StringToHash("IdleAgressive");
        Die = Animator.StringToHash("Die");
        IdleSimple = Animator.StringToHash("IdleSimple");
        Bite = Animator.StringToHash("Bite");
        playerIsAttacking = false;

        getAttackAnimationClipLength();

    }

    // Update is called once per frame
    void Update()
    {

        if (isDead == false)
        {
            DamagePlayer();
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance > seenRange)
        {
            return;
        }

        if (distance < attackRange)
        {
            // Dacă jucătorul este în raza de atac, atunci atacă
            Debug.Log("Animatia BITE ");
            anim.SetBool(IdleSimple, false);
            anim.SetBool(Bite, true);
            anim.SetBool(IdleAgressive, false);
            anim.SetBool(Die, false);
            return;
        }

        anim.SetBool(IdleSimple, false);
        anim.SetBool(Bite, false);
        anim.SetBool(IdleAgressive, true);
        anim.SetBool(Die, false);
        Debug.Log("Animatia BATTLE ");

        // Dacă jucătorul este în raza de vedere, dar nu în raza de atac, atunci urmărește-l
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        direction.y = 0;
    }


     private void DamagePlayer()
      {
          timeSinceAttackStarted += Time.deltaTime;

          // Aplică damage doar când este în starea de atac
          if (anim.GetBool(Bite) && timeSinceAttackStarted >= momentOfDamageInAttackAnimation && alreadyDamagedPlayerDuringThisAttack == false)
          {
              FindAnyObjectByType<PlayerStats>().changeHealth(-damageValuePerAttack);
              alreadyDamagedPlayerDuringThisAttack = true;
            Debug.Log("Attack DRAGON");

        }

          if (timeSinceAttackStarted >= attackAnimationClipLength)
          {
              timeSinceAttackStarted = 0f;
              alreadyDamagedPlayerDuringThisAttack = false;
          }
      }
   

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Axe") && playerIsAttacking == true && isDead == false && nr_of_healts == count_healts)
        {
            Debug.Log("Lovit Dragon");
            anim.SetBool(IdleSimple, false);
            anim.SetBool(Bite, false);
            anim.SetBool(IdleAgressive, false);
            anim.SetBool(Die, true);
            Debug.Log("Animatia DIE");
            isDead = true;

            FindAnyObjectByType<Inventory>().addItem(itemCodePlayerGetsWhenKilled, itemQuantityPlayerGetsWhenKilled);
        }
        if (collision.gameObject.CompareTag("Axe") && playerIsAttacking == true)
        {
            count_healts = count_healts + 1;
            Debug.Log("Hit: " + count_healts);
        }
     }

    private void getAttackAnimationClipLength()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Bite":
                    attackAnimationClipLength = clip.length;
                    break;
            }
        }
    }
}
