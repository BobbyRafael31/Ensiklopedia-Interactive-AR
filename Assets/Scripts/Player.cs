using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;
    public Rigidbody playerRigid;
    public float w_speed, wb_speed, old_speed, rn_speed, ro_speed;
    public float jumpForce = 5f;
    public bool walking;
    public Transform playerTransform;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    [SerializeField]
    private bool isGrounded;

    private void FixedUpdate()
    {

        // Move player
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerRigid.velocity = transform.forward * w_speed * Time.fixedDeltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                playerRigid.velocity = -transform.forward * wb_speed * Time.fixedDeltaTime;
            }

            // Rotate player
            if (Input.GetKey(KeyCode.A))
            {
                playerTransform.Rotate(0, -ro_speed * Time.fixedDeltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                playerTransform.Rotate(0, ro_speed * Time.fixedDeltaTime, 0);
            }
        }


    }

    private void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer);


        if (isGrounded)
        {
            //Jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRigid.velocity = new Vector3(playerRigid.velocity.x, jumpForce, playerRigid.velocity.z);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                playerAnim.SetTrigger("run");
                playerAnim.ResetTrigger("idle");
                walking = true;
            }

            if (Input.GetKeyUp(KeyCode.W))
            {
                playerAnim.SetTrigger("idle");
                playerAnim.ResetTrigger("run");
                walking = false;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                playerAnim.SetTrigger("runback");
                playerAnim.ResetTrigger("idle");
            }

            if (Input.GetKeyUp(KeyCode.S))
            {
                playerAnim.SetTrigger("idle");
                playerAnim.ResetTrigger("runback");
            }

            if (walking == true)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    w_speed = w_speed + rn_speed;
                    playerAnim.SetTrigger("sprint");
                    playerAnim.ResetTrigger("run");
                }

                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                    w_speed = old_speed;
                    playerAnim.ResetTrigger("sprint");
                    playerAnim.SetTrigger("run");
                }
            }
        }



    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
