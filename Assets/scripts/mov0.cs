using UnityEngine;

public class mov0 : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 startPosition;
    private Quaternion startRotation;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float fallLimit = -10f;
    public float rotationSpeed = 30f;
    public float cameraRotationSpeed = 60f;
    public Transform cameraTransform;
    private float y;
    public Joystick joystick_mov;
    public Joystick joystick_cam;
    public RestaurantUI restaurantUI;
    [SerializeField] private Animator puertaAnimator;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
        y = transform.eulerAngles.y;

        // Si no se asignó en el Inspector, busca la cámara principal
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    
    void FixedUpdate()
    {
        if (rb.position.y < fallLimit)
        {
            ResetPlayerPosition();
            return;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (joystick_mov != null)
        {
            x = joystick_mov.Horizontal;
            z = joystick_mov.Vertical;
        }

        bool moviendo =
            Mathf.Abs(x) > 0.1f ||
            Mathf.Abs(z) > 0.1f;

        bool moviendoCamara =
            joystick_cam != null &&
            (Mathf.Abs(joystick_cam.Horizontal) > 0.1f ||
            Mathf.Abs(joystick_cam.Vertical) > 0.1f);

        if (restaurantUI != null && (moviendo || moviendoCamara))
        {
            restaurantUI.OcultarInstrucciones();
        }

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 movement =
            (forward * z + right * x) * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + movement);
    }


    private void ResetPlayerPosition()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.position = startPosition;
        rb.rotation = startRotation;
        y = startRotation.eulerAngles.y;
        if (restaurantUI != null)
        {
            restaurantUI.MostrarInstrucciones();
        }
        if (puertaAnimator != null)
        {
            puertaAnimator.Rebind();
            puertaAnimator.Update(0f);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
             Saltar();
        }

         if(Input.GetKey(KeyCode.K)){
           y += Time.deltaTime * 300;
           transform.rotation = Quaternion.Euler(0,y,0);
        }

        if(Input.GetKey(KeyCode.J)){
            y -= Time.deltaTime * 300;
            transform.rotation = Quaternion.Euler(0,y,0);
        }

        if(Input.GetKey(KeyCode.U)){
            cameraTransform.Rotate(-2.0f,0,0);
        }
        if(Input.GetKey(KeyCode.N)){
            cameraTransform.Rotate(2.0f, 0, 0);
        }
    }

    public void Saltar()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
