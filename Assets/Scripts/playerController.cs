using TreeEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    private bool canMove = true;
    [SerializeField]private CoinManager coinManager;
    [SerializeField] private GameObject loseScreen;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private Animator animator;

    AudioManager audioManager;
    PauseMenu pauseMenu;

    private float scaleX;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        pauseMenu = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenu>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
    }

    private void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Physics2D.gravity = new Vector2(0, 9.81f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Physics2D.gravity = new Vector2(-9.81f, 0);
                transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.S))
            {
                Physics2D.gravity = new Vector2(0, -9.81f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Physics2D.gravity = new Vector2(9.81f, 0);
                transform.localScale = new Vector3((-1)*scaleX, transform.localScale.y, transform.localScale.z);
            }
        }
        animator.SetFloat("Speed", rb.velocity.magnitude);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioManager.PlaySFX(audioManager.wallTouch);
        canMove = true;
        animator.SetBool("isLanded", true);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        canMove = false;
        animator.SetBool("isLanded", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            audioManager.PlaySFX(audioManager.coin);
            coinManager.AddCoin();
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            audioManager.PlaySFX(audioManager.death);
            loseScreen.gameObject.SetActive(true);
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
            pauseMenu.ShowMenu();
            Debug.Log(Time.timeScale);
        }
    }

}
