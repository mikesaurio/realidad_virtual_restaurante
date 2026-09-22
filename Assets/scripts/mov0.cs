using UnityEngine;

public class mov0 : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    public float jumpForce = 5f;
    public float rotationSpeed = 30f;
    public float cameraRotationSpeed = 60f;
    public Transform cameraTransform;
    private float y;
    public Joystick joystick_mov;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        y = transform.eulerAngles.y;

        // Si no se asignó en el Inspector, busca la cámara principal
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (joystick_mov != null)
        {
            x = joystick_mov.Horizontal;
            z = joystick_mov.Vertical;
        }

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * z + right * x) * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
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
}
