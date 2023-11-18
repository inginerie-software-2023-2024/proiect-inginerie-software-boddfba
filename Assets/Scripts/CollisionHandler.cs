using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    bool prevAnimationIsAttacking = false;

    void Start()
    {
    
        GameObject otherCharacter = GameObject.Find("Player"); // Example
        if (otherCharacter != null)
        {
           animator = otherCharacter.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("Other character not found!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(animator.GetBool("isAttacking") == true && prevAnimationIsAttacking == false)
        {
            if(other.gameObject.tag == "Mob")
            {
                Debug.Log("ENTER: " + other.name);
            }

        }

        prevAnimationIsAttacking = animator.GetBool("isAttacking");
    }

    void OnTriggerStay(Collider other)
    {

     
        if (other.gameObject.tag == "Mob" && animator.GetBool("isAttacking") == true)
        {
            Debug.Log("STAY: " + other.name);
        }

        
    }



}
