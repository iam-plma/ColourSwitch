using UnityEngine;
using Managers;
using Platforms;

namespace PlayerScripts
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D rb;

        //private float speedForce = 4.5f;
        private float speedForce = 15.0f;

        [SerializeField]
        private Sprite pinkSprite;
        [SerializeField]
        private Sprite blueSprite;

        private Animator anim;

        [HideInInspector]
        public GameObject colliderObj = null;
        public int samePlatformJumpCounter = 0;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
        }

        void Update()
        {
            Movement();
            SwitchColour();

        }

        private void SwitchColour()
        {

            if (Input.GetMouseButtonDown(0))
            {
                AudioManager.Instance.Play("Switch");
                ColourManager.Instance.SwitchBGColour();

                if (ColourManager.Instance.currentColor == PlatformType.Pink)
                {
                    anim.SetTrigger("ChangeToPinkColor");
                }
                else if (ColourManager.Instance.currentColor == PlatformType.Blue)
                {
                    anim.SetTrigger("ChangeToBlueColor");
                }
            }
        }

        private void Movement()
        {
            //for pc
            //float horizontalinput = Input.GetAxisRaw("Horizontal");
            //rb.velocity = new Vector2(horizontalinput * speedForce/2, rb.velocity.y);

            //for mobile
            Vector3 accVec = GetAccelerometerValue();
            rb.velocity = new Vector2(accVec.x * speedForce, rb.velocity.y);

        }

        private Vector3 GetAccelerometerValue()
        {
            Vector3 acc = Vector3.zero;
            float period = 0.0f;

            foreach (AccelerationEvent evnt in Input.accelerationEvents)
            {
                acc += evnt.acceleration * evnt.deltaTime;
                period += evnt.deltaTime;
            }
            if (period > 0)
            {
                acc *= 1.0f / period;
            }
            return acc;
        }
    }
}
