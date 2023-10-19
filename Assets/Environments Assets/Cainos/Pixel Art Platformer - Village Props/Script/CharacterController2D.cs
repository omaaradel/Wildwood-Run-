using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{// Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Animator playerAnimator;
    public Transform groundTransform;
    public FixedJoystick joystick;
    //public Camera mainCamera;

    bool facingRight = true;
    float moveDirection = 0;
    float move;
    [SerializeField] bool isGrounded = false;
    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        facingRight = t.localScale.x > 0;

        //if (mainCamera)
        //{
        //    cameraPos = mainCamera.transform.position;
        //}
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        float dir = joystick.Horizontal;
        if(dir>0.01) 
            moveDirection = 1;
        else if(dir < -0.01)
            moveDirection = -1;
#else
        // Movement controls
         move = Input.GetAxisRaw("Horizontal");
        //if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) /*&& (isGrounded || Mathf.Abs(r2d.velocity.x) > 0.01f)*/)
        //{
        //    moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        //}
        //else
        //{
        //    if (isGrounded || r2d.velocity.magnitude < 0.01f)
        //    {
        //        moveDirection = 0;
        //    }
        //}
#endif

        // Change facing direction
        if (move != 0)
        {
            playerAnimator.SetBool("Running", true);

            if (move > 0 && !facingRight)
            {
                facingRight = true;
                t.localScale = new Vector3(Mathf.Abs(t.localScale.x), t.localScale.y, transform.localScale.z);
            }
            if (move < 0 && facingRight)
            {
                facingRight = false;
                t.localScale = new Vector3(-Mathf.Abs(t.localScale.x), t.localScale.y, t.localScale.z);
            }
        }
        else
            playerAnimator.SetBool("Running", false);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }


        if (r2d.velocity.y > 0.01f && moveDirection == 0)
        {
            playerAnimator.SetTrigger("Up");
        }
        else if (r2d.velocity.y < -1.2f && !isGrounded && moveDirection == 0)
        {
            playerAnimator.SetTrigger("Down");
        }

        else if (r2d.velocity.y == 0 && isGrounded)
            playerAnimator.SetTrigger("Ground");

        // Camera follow
        //if (mainCamera)
        //{
        //    mainCamera.transform.position = new Vector3(t.position.x, cameraPos.y, cameraPos.z);
        //}
    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        // Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        Vector3 groundCheckPos = groundTransform.position;
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
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((move) * maxSpeed, r2d.velocity.y);

        // Simple debug
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(0, colliderRadius, 0), isGrounded ? Color.green : Color.red);
        Debug.DrawLine(groundCheckPos, groundCheckPos - new Vector3(colliderRadius, 0, 0), isGrounded ? Color.green : Color.red);

    }
}