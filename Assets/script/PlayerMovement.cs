using UnityEngine;

namespace Mui 
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody2D rb;
        private float MoveH, MoveV;
        [SerializeField] private float MoveSpeed;
        private Animator animator;


        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            MoveH = Input.GetAxis("Horizontal") * MoveSpeed;
            MoveV = Input.GetAxis("Vertical") * MoveSpeed;
            Flip();
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetBool("Attack1",true);
            }
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(MoveH, MoveV);
        }
        private void Flip()
        {
            //if (MoveH > 0)
            if (transform.position.x < Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
            //if (MoveH < 0)
            if (transform.position.x > Camera.main.ScreenToWorldPoint(Input.mousePosition).x)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
        }
    }
}

