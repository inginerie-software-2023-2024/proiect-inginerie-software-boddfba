using UnityEngine;
using System.Collections;

public class DemonMovement : MonoBehaviour
{
    private Animator anim;
    int hIdles;
    int hAngry;
    int hAttack;
    int hGrabs;
    int hThumbsUp;
    public Transform target;
    private float seenRange = 100f;
    public bool isDead = false;
    private float attackRange = 25f;
    public float walkSpeed = 10.0f;
    public float rotationSpeed = 5f;
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

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        hIdles = Animator.StringToHash("Idles");
        hAngry = Animator.StringToHash("Angry");
        hAttack = Animator.StringToHash("Attack");
        hGrabs = Animator.StringToHash("Grabs");
        hThumbsUp = Animator.StringToHash("ThumbsUp");

        getAttackAnimationClipLength();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (isDead == false) {
            DamagePlayer();
            FollowTarget(); }

    }

    private void FollowTarget()
    {
        var distance = Vector3.Distance(transform.position, target.position);

        if (distance > seenRange)
        {
            // Dacă jucătorul nu este în raza de vedere, atunci stai pe loc (Idle)
            return;
        }

        if (distance < attackRange)
        {
            // Dacă jucătorul este în raza de atac, atunci atacă
            anim.SetBool(hIdles, false);
            anim.SetBool(hAngry, false);
            anim.SetBool(hAttack, true);
            anim.SetBool(hThumbsUp, false);
            return;
        }
        anim.SetBool(hIdles, false);
        anim.SetBool(hAngry, true);
        anim.SetBool(hAttack, false);
        anim.SetBool(hThumbsUp, false);

        // Dacă jucătorul este în raza de vedere, dar nu în raza de atac, atunci urmărește-l
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        direction.y = 0;


        var lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        transform.Translate(direction * walkSpeed * Time.deltaTime, Space.World);
    }


    private void DamagePlayer()
    {
        timeSinceAttackStarted += Time.deltaTime;

        // Aplică damage doar când este în starea de atac
        if (anim.GetBool(hAttack) && timeSinceAttackStarted >= momentOfDamageInAttackAnimation && alreadyDamagedPlayerDuringThisAttack == false)
        {
            FindAnyObjectByType<PlayerStats>().changeHealth(-damageValuePerAttack);
            alreadyDamagedPlayerDuringThisAttack = true;
            Debug.Log("Attack");
        }

        if (timeSinceAttackStarted >= attackAnimationClipLength)
        {
            timeSinceAttackStarted = 0f;
            alreadyDamagedPlayerDuringThisAttack = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Detectare coleziune");
        if (collision.gameObject.CompareTag("Axe"))
        {
            Debug.Log("COLEZIUNEEE Axe");

            anim.SetBool(hIdles, false);
            anim.SetBool(hAngry, false);
            anim.SetBool(hAttack, false);
            anim.SetBool(hThumbsUp, true);
            isDead = true;

            FindAnyObjectByType<Inventory>().addItem(itemCodePlayerGetsWhenKilled, itemQuantityPlayerGetsWhenKilled);
        }
    }

    private void getAttackAnimationClipLength()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach (AnimationClip clip in clips)
        {
            switch (clip.name)
            {
                case "Attack":
                    attackAnimationClipLength = clip.length;
                    break;
            }
        }
    }

}
