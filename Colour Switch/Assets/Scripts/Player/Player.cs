using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    private float speedForce = 4.5f;
    private float jumpForce = 6.0f;
    private bool resetJump = false;

    [SerializeField]
    private Sprite pinkSprite;
    [SerializeField]
    private Sprite blueSprite;

    private Animator anim;

    [HideInInspector]
    public GameObject collider = null;
    public int samePlatformJumpCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            Movement();
            SwitchColour();
   
    }

    private void SwitchColour()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ColourManager.Instance.SwitchBGColour();

            if (ColourManager.Instance.currentColor == PlatformType.Pink)
            {
                //GetComponent<SpriteRenderer>().sprite = pinkSprite;
                anim.SetTrigger("ChangeToPinkColor");
            }
            else if (ColourManager.Instance.currentColor == PlatformType.Blue)
            {
                //GetComponent<SpriteRenderer>().sprite = blueSprite;
                anim.SetTrigger("ChangeToBlueColor");
            }
        }

        //if (Input.GetMouseButtonDown(1))
        //    ColourManager.Instance.SwitchPlatformsColour();
    }

    private void Movement()
    {
        float horizontalinput = Input.GetAxisRaw("Horizontal");

        /*
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }
        */
        rb.velocity = new Vector2(horizontalinput * speedForce, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hit.collider != null)
        {
            if (!resetJump)
            {
                return true;
            }
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        resetJump = true;
        yield return new WaitForSeconds(0.1f);
        resetJump = false;
    }

    
}
