using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D _Rigidbody2D;
    private Animator animator;

    public float horizontal;
    public float vertical;   // por ahora no se usa, puede servir luego para salto
    public float speed = 1f;
    public float jumpForce = 0.2f;

    private bool isJumping = false;

    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimiento lateral
        horizontal = Input.GetAxisRaw("Horizontal");

        // Animación de correr (Idle ↔ Run)
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        // Salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            _Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        _Rigidbody2D.linearVelocity = new Vector2(horizontal * speed, _Rigidbody2D.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Flag"))
        {
            SceneManager.LoadScene("Scene2"); // 👈 usa el nombre exacto de tu escena
        }
    }
}
