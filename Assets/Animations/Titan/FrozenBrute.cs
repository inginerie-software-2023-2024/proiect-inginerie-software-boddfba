using UnityEngine;
using static PlayerStats;

public class FrozenBrute : MonoBehaviour
{
    Animator animator;
    public float moveSpeed = 20f;
    public float rotationSpeed = 60f;
    private bool isAttacking = false;
    private bool is360 = false;
    private bool isJumpAttack = false;
    private bool isMartelo = false;
    private bool isHook = false;
    private bool isDead = false;
    private CharacterController characterController;
    PlayerStats playerStats;


    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

        // Find and store reference to PlayerStats component
        playerStats = GetComponent<PlayerStats>();
    }

    void Update()
    {
        if (isDead) { return; }

        // Access player's health using the PlayerStats reference
        float playerHealth = playerStats.getHealth();
        Debug.Log("Health: " + playerHealth);

        // Check for player's death
        if (playerHealth <= 0 && !isDead)
        {
            // Trigger death animation or perform death logic
            isDead = true;
            animator.SetBool("isDead", isDead);
            // Additional death logic can be added here
        }

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
            isAttacking = true;

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
        if (!Input.GetKey(KeyCode.Q))
            isAttacking = false;

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
