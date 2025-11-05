using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hur snabbt vår karaktär får röra sig
    public float jumpForce = 5f; // Vilken force hopp knappen kan göra
    public Transform groundCheck; // Kolla om spelaren har rört vid marken
    public float groundCheckRadius = 0.2f; // Inom vilken radie kan vi röra marken
    public LayerMask groundLayer; // Vilket lager har marken
    [SerializeField] bool IsGrounded = false; // Om vi är på marken eller inte
    private Rigidbody2D rb; // Ref till vår rigidbody2D
    [SerializeField] KeyCode left = KeyCode.A; // du åker vänster med A
    [SerializeField] KeyCode right = KeyCode.D; //du åker höger med D

    private int extraJump;
    public int extraJumpValue = 1; //Amount of dubblejumps
    [SerializeField] int resetJump;

    private bool canDash = true;
    public bool isDashing;
    [SerializeField, Range(20,40)] private float dashingPower = 12f; // Dash power
    [SerializeField, Range(0,4)] private float dashingTime = 1f; // Dash duration
    [SerializeField, Range(0,4)] private float dashingCooldown = 1f; // Cooldown between dashes

    public Animator anim;
    

    private bool isFacingRight = true; // Kolla vilket håll karaktären tittar i

    


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>(); // Hämta vår Rigidbody 2D
        extraJump = extraJumpValue; // de är samma 
       

    }

    // Update is called once per frame
    void Update()
    {

        


        // Adjust speed if Left Shift is held for sprinting
        IsGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer); // Kolla om spelaren är på marken



        if (Input.GetButtonDown("Jump") && IsGrounded)// du kan hoppa om du är på marken
        {
            Jump();

        }
        else if (Input.GetButtonDown("Jump") && extraJump > 0)// om jag hoppar igen och extra jump är större än 0 extra jump
        {
            ExtraJump();
            extraJump--;
        }


        if (CompareTag("Player") == IsGrounded)// om jag är på marken reset extrajump
        {
            extraJump = resetJump;
        }


        float moveDirection = Input.GetAxis("Horizontal");  // Kolla om vi rör oss horisontellt
        anim.SetBool("Jump", !IsGrounded);

       
        Move(moveDirection); // Flytta spelaren
        if (moveDirection > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveDirection < 0 && isFacingRight)
        {
            Flip();
        }
        if (isDashing) return; // gör så du inte kan röra dig när du dashar

        if (Input.GetKeyDown(KeyCode.P) && canDash) StartCoroutine(Dash());// om du trycker på P och kan dasha, dasha
        {

        }
        
    }
    private void Move(float direction)
    {
        if (isDashing) return; // Ignore movement if dashing

        // Calculate movement and apply it to Rigidbody2D
        Vector2 movement = new Vector2(direction * moveSpeed, rb.velocity.y);
        rb.velocity = movement;

        float absoluteSpeed = Mathf.Abs(direction * moveSpeed);
        anim.SetFloat("Speed", absoluteSpeed);


    }

    private void Jump()
    {
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);// hopp höjd
    }
    private void ExtraJump()
    {
        rb.velocity = new Vector2(0f, jumpForce / 5); // Add vertical velocity to make double jumps consistent, divide by 5 to not make it too powerful
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); // Add vertical force for jump


    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;  // Flippa player spriten horisontellt
        transform.Rotate(0f, 180f, 0f);
    }
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        // Store and set gravity to zero for dash effect
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Determine dash direction based on player's facing direction
        rb.velocity = new Vector2((isFacingRight ? 1 : -1) * dashingPower, 1f);



        // Enable trail effect and wait for dash duration
        
        yield return new WaitForSeconds(dashingTime);

        // Reset dash state and gravity
      
        rb.gravityScale = originalGravity;
        isDashing = false;
        rb.velocity = new Vector2(0, rb.velocity.y);
        // Wait for cooldown before allowing next dash
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
