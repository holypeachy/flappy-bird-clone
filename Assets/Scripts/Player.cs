using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private bool jump = false;
    public bool dead { get; private set; }
    [SerializeField] private float jumpForce = 550f;

    [SerializeField] private GameObject image;
    private GameOver gameOver;

    [SerializeField] private Animator animator;

    [SerializeField] private AudioSource wing;
    [SerializeField] private AudioSource die;
    [SerializeField] private AudioSource hit;


    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.gravityScale = 4f;
        gameOver = image.GetComponent<GameOver>();

        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && !dead)
        {
            jump = true;
        }

        if (dead && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            Jump();
        }

        Rotate();
    }

    void Jump()
    {
        rigid.velocity = new Vector2(0, 0);
        rigid.AddForce(Vector2.up * jumpForce);
        jump = false;
        rigid.rotation = 45f;
        animator.SetTrigger("flap");
        wing.Play();
        
    }

    void Rotate()
    {
        if (rigid.rotation > -40f && !dead)
        {
            rigid.rotation += -3f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipes") || collision.gameObject.CompareTag("Bounds"))
        {
            hit.Play();
            die.Play();
            dead = true;
            gameOver.Setup();
        }
    }
}
