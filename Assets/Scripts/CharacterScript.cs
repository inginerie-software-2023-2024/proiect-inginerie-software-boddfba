using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 20f;
    public float rotationSpeed = 60f;
    private bool isAttacking = false;
    private bool is360 = false;
    private bool isJumpAttack = false;
    private bool isMartelo = false;
    private bool isHook = false;
    private CharacterController characterController;
    public DragonExample dragonExample;
    public DemonMovement demon;
    public DemonMovement demon1;
    public DemonMovement demon2;
    public DemonMovement demon3;
    public DemonMovement demon4;
    public DemonMovement demon5;
    public DemonMovement demon6;
    public DemonMovement demon7;
    public DemonMovement demon8;
    public DemonMovement demon9;
    public DemonMovement demon10;
    public DemonMovement demon11;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float horizontalInput = 0f;
        float verticalInput = 0f;

        // Detect movement input from WASD keys
        if (Input.GetKey(KeyCode.W))
            verticalInput = 1f;

        if (Input.GetKey(KeyCode.S))
            verticalInput = -1f;

        if (Input.GetKey(KeyCode.A))
            horizontalInput = -1f;

        if (Input.GetKey(KeyCode.D))
            horizontalInput = 1f;

        // Check for walking animation
        animator.SetBool("isWalking", verticalInput != 0);

        // Check for different attack animations
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isAttacking = true;
            if (demon != null && dragonExample != null) {
            dragonExample.playerIsAttacking = true;
            demon.playerIsAttackingNPC = true;
            demon1.playerIsAttackingNPC = true;
            demon2.playerIsAttackingNPC = true;
            demon3.playerIsAttackingNPC = true;
            demon4.playerIsAttackingNPC = true;
            demon5.playerIsAttackingNPC = true;
            demon6.playerIsAttackingNPC = true;
            demon7.playerIsAttackingNPC = true;
            demon8.playerIsAttackingNPC = true;
            demon9.playerIsAttackingNPC = true;
            demon10.playerIsAttackingNPC = true;
            demon11.playerIsAttackingNPC = true; }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
            is360 = true;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            isJumpAttack = true;

        if (Input.GetKeyDown(KeyCode.Alpha4))
            isMartelo = true;

        if (Input.GetKeyDown(KeyCode.Alpha5))
            isHook = true;

        // Update the total movement
        Vector3 moveDirection = transform.forward * verticalInput;
        float moveSpeedModifier = (isAttacking || is360 || isJumpAttack || isMartelo || isHook) ? 0f : moveSpeed;

        // Apply movement to the CharacterController
        characterController.SimpleMove(moveDirection * moveSpeedModifier);

        // Rotate the character
        transform.Rotate(new Vector3(0, horizontalInput * Time.deltaTime * rotationSpeed, 0));

        // Set the animation parameters
        animator.SetBool("isAttacking", isAttacking);
        animator.SetBool("is360", is360);
        animator.SetBool("isJumpAttack", isJumpAttack);
        animator.SetBool("isMartelo", isMartelo);
        animator.SetBool("isHook", isHook);

        // Reset the attack flags when the corresponding key is released
        if (!Input.GetKey(KeyCode.Q)) {
        isAttacking = false;
            if (demon != null && dragonExample != null)
            {
                dragonExample.playerIsAttacking = false;
                demon.playerIsAttackingNPC = false;
                demon1.playerIsAttackingNPC = false;
                demon2.playerIsAttackingNPC = false;
                demon3.playerIsAttackingNPC = false;
                demon4.playerIsAttackingNPC = false;
                demon5.playerIsAttackingNPC = false;
                demon6.playerIsAttackingNPC = false;
                demon7.playerIsAttackingNPC = false;
                demon8.playerIsAttackingNPC = false;
                demon9.playerIsAttackingNPC = false;
                demon10.playerIsAttackingNPC = false;
                demon11.playerIsAttackingNPC = false;
            }
        }


        if (!Input.GetKey(KeyCode.Alpha2))
            is360 = false;

        if (!Input.GetKey(KeyCode.Alpha3))
            isJumpAttack = false;

        if (!Input.GetKey(KeyCode.Alpha4))
            isMartelo = false;

        if (!Input.GetKey(KeyCode.Alpha5))
            isHook = false;
    }
}
