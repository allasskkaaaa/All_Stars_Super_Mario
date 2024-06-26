using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public bool TestMode;

    //Player Gameplay Variables
    public bool flowerGet = true;
    public bool mushroomGet = false;


    //Movement Variables
    [SerializeField] private int speed;
    [SerializeField] private int jumpForce = 3;

    //Groundcheck
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private float groundCheckRadius;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        if (speed <= 0)
        {
            speed = 5;
            if (TestMode) Debug.Log("Speed Set To Default Value");
        }

        if (jumpForce <= 0)
        {
            jumpForce = 3;
            if (TestMode) Debug.Log("Jump Force Set To Default Value");
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.02f;
            if (TestMode) Debug.Log("Ground Check Radius Set To Default Value");
        }

        if (groundCheck == null)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("GroundCheck");
            if (obj != null)
            {
                groundCheck = obj.transform;
                return;
            }
            GameObject newObj = new GameObject();
            newObj.transform.SetParent(transform);
            newObj.transform.localPosition = Vector3.zero;
            newObj.name = "GroundCheck";
            newObj.tag = newObj.name;
            groundCheck = newObj.transform;
            if (TestMode) Debug.Log("Ground Check Transform Created via Code - Did you forget to assign it in the inspector?");
        }


    }
    // Update is called once per frame
    void Update()
    {
        AnimatorClipInfo[] curPlayingClips = anim.GetCurrentAnimatorClipInfo(0);
        float xInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGroundLayer);

        //animation checks for physics
        if (curPlayingClips.Length > 0)
        {
            if (curPlayingClips[0].clip.name == "Attack")
                rb.velocity = Vector2.zero;
            else
            {
                Vector2 moveDirection = new Vector2(xInput * speed, rb.velocity.y);
                rb.velocity = moveDirection;

                //Input check for attack happens here in order to prevent fire from retriggering in the attack animation
                if (Input.GetButtonDown("Fire1"))
                    anim.SetTrigger("Attack");
            }
        }

        //Input checks
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            audioManager.PlaySFX(audioManager.Jump);
        }


        if (Input.GetButtonDown("Jump") && !isGrounded)
        {
            anim.SetTrigger("Groundpound");
            IncreaseGravity();
        }

        //Check if powerups are available

        if (mushroomGet == true)
        {
            anim.SetBool("RedMushroom", true);
            GameManager.Instance.lives++;
        }
        else
        {
            anim.SetBool("RedMushroom", false);
        }

        if (flowerGet == true)
        {
            anim.SetBool("FireFlower", true);
            GameManager.Instance.lives++;
        }
        else
        {
            anim.SetBool("FireFlower", false);
        }



        //Sprite Flipping
        if (xInput != 0) sr.flipX = (xInput < 0);

        //setting specific animation variables
        anim.SetFloat("speed", Mathf.Abs(xInput));
        anim.SetBool("isGrounded", isGrounded);

    }

    public void IncreaseGravity()
    {
        rb.gravityScale = 10;
    }

    public void cleanse()
    {
        flowerGet = false;
        mushroomGet = false;
        anim.SetBool("RedMushroom", false);
        anim.SetBool("FireFlower", false);
        anim.SetBool("isSmall", true);
        Debug.Log("Cleansed of all powerups");
    }
}