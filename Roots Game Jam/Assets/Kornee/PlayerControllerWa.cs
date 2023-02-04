using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerControllerWa : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    private float direction = 0f;
    private Rigidbody2D player;
    //GroundCheck
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    [Header("Camera")]
    public GameObject camera;
    [Range(0,50)]public float FollowSpeed;
    [Header("Roots")]
    public GameObject rootPrefab;
    public GameObject rootMover;
    public Line activeRoot;
    public float speedModifier;
    public float rotationForce;
    bool isRooting;
    [Header("Animation")]
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer= GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        MoveCameraOnPlayer();
        if (!isRooting)
        {
            HandleMovement();
        }
        HandleRoot();
    }

    public void HandleMovement()
    {
        //basic movement mechanics

        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        direction = Input.GetAxis("Horizontal");

        if (direction > 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            spriteRenderer.flipX= true;
            animator.SetBool("walking", true);
        }
        else if (direction < 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            spriteRenderer.flipX= false;
            animator.SetBool("walking", true);

        }
        else
        {
            spriteRenderer.flipX= false;
            animator.SetBool("walking", false); 
            player.velocity = new Vector2(0, player.velocity.y);
        }
    }

    public void MoveCameraOnPlayer()
    {
        Vector3 newPosition = transform.position;
        newPosition.z = -10;
        camera.transform.position = Vector3.Lerp(camera.transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }

    public void HandleRoot()
    {
        direction = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.Space) && isTouchingGround && activeRoot == null)
        {
            isRooting = true;
            GameObject newRoot = Instantiate(rootPrefab, groundCheck);
            activeRoot = newRoot.GetComponent<Line>();
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            isRooting = false;
            activeRoot = null;
            rootMover.transform.position = transform.position;
        }
        
        if (activeRoot != null)
        {
            rootMover.transform.Rotate(Vector3.forward * direction * Time.deltaTime * rotationForce);
            rootMover.transform.Translate(Vector2.down * Time.deltaTime * speedModifier);
            activeRoot.UpdateLine(rootMover.transform.position);
        }

        
    }
}
