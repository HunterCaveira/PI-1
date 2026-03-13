using UnityEngine;
using UnityEngine.InputSystem;

public class Movimento : MonoBehaviour
{
    public float jumpForcePublic = 10;
    public float playerSpeed;
    
    public Rigidbody2D rb;

    private InputActions inputActions;

    private Vector2 moverDirections;

    [SerializeField] private Animator playeAnimation;

    [SerializeField] private Animator Rolagem;
    [SerializeField] private AudioSource audioSourcePlayer;
    [SerializeField] private AudioClip sfxJump;
    [SerializeField] private AudioClip sfxOnGround;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        inputActions = new InputActions();
        inputActions.Player.Pular.performed += Jump; 

        
    }
    private void OnEnable()
    {

        inputActions.Enable();
        
    }

    private void OnDisable()
    {

        inputActions.Disable();
        
    }

    SpriteRenderer sprite;

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        moverDirections = inputActions.Player.Mover.ReadValue<Vector2>();

        transform.Translate(moverDirections * playerSpeed * Time.deltaTime);




        if (moverDirections.x != 0)
        {

            playeAnimation.SetInteger("Andando", 1);
        }
        else
        {
            playeAnimation.SetInteger("Andando", 0);
        
        }

        Vector2 movimento = inputActions.Player.Mover.ReadValue<Vector2>();

        if (moverDirections.x > 0)
        {

            sprite.flipX = false;
           

        }

        else if (moverDirections.x < 0)
        {

            sprite.flipX = true;
        
        }

       
    }

    private void Jump(InputAction.CallbackContext ctx)
    {

       rb.AddForce(Vector2.up * jumpForcePublic, ForceMode2D.Impulse);
        audioSourcePlayer.PlayOneShot(sfxJump);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gound"))
        {
            audioSourcePlayer.PlayOneShot(sfxOnGround);
        
        }
    }


}
