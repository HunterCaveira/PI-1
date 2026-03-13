using UnityEngine;
using UnityEngine.InputSystem;

public class MovimentoGatinho : MonoBehaviour
{
    public float jumpForcePublic = 10;
    public float playerSpeed;
    
    public Rigidbody2D rb;

    private InputActions inputActions;

    private Vector2 moverDirections;

    [SerializeField] private Animator playeAnimation;

    [SerializeField]private Animator Rolagem;

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

        playeAnimation.SetFloat("eixoX", moverDirections.x);
        playeAnimation.SetFloat("eixoY", moverDirections.y);

        if (moverDirections != Vector2.zero)
        {

            playeAnimation.SetInteger("Andando",1);
        }
        else
        {
            playeAnimation.SetInteger("Andando",0);
        
        }

       

       
    }

    private void Jump(InputAction.CallbackContext ctx)
    {

       rb.AddForce(Vector2.up * jumpForcePublic, ForceMode2D.Impulse);

        
         





    }

}
