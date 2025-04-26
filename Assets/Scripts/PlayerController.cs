using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{

    public float speed = 0;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY; 
    public GameObject winTextObject;
    public int collectiblesCount;
    private PlayerInputActions _input;
    private bool _jumped = false;
    public GameObject chickenParticle;
    private AudioSource chickenAudio;
    public AudioClip chickenSound;
    public GameObject buttonRestart;
    public GameObject buttonMainMenu;
    public float jumpForce = 0.3f;


    public TextMeshProUGUI countText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent <Rigidbody>(); 
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);

        buttonMainMenu.SetActive(false);
        buttonRestart.SetActive(false);

        _input = new PlayerInputActions();
        _input.Player.Jump.performed += Jump_Performed;
        _input.Player.Jump.canceled += Jump_Canceled;
        _input.Enable();
        chickenAudio = GetComponent<AudioSource>();
    }

    private void Jump_Performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _jumped = true;
        rb.AddForce(Vector3.up * 10f, ForceMode.Impulse);
    }

    private void Jump_Canceled(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if(!_jumped)
        {
            var forceEffect = context.duration;
            rb.AddForce(Vector3.up * (10f * (float)forceEffect), ForceMode.Impulse);

        }
    }

    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); 
        movementX = movementVector.x; 
        movementY = movementVector.y;
        Debug.Log($"Move to {movementX}; {movementY}");
    }

    void OnJump(InputValue jumpValue)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log("Jump");
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PickUp")) {
            Instantiate(chickenParticle, transform.position, Quaternion.identity);
            chickenAudio.PlayOneShot(chickenSound);
            other.gameObject.SetActive(false);
            count+=1;
            SetCountText();
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.MoveRotation(Quaternion.RotateTowards(rb.rotation, toRotation, 720 * Time.fixedDeltaTime)); 
        }
    }



    void SetCountText() 
    {
       countText.text =  "Count: " + count.ToString();

        if (count >= collectiblesCount)
        {
            winTextObject.GetComponent<TextMeshProUGUI>().text = $"You Win!\nScore:{count}";
            winTextObject.SetActive(true);
            buttonMainMenu.SetActive(true);
            buttonRestart.SetActive(true);
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
            gameObject.GetComponent<PlayerController>().enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            buttonMainMenu.SetActive(true);
            buttonRestart.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = $"You Lose!\nScore:{count}";
        }
    }

}
