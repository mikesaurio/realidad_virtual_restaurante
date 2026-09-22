using UnityEngine;

public class mov1 : MonoBehaviour
{
    public Transform cameraTransform;
    private float x;
    private float y;
    public float speed = 20f;
    public Joystick joystick_cam;

    void Start()
    {
        // Si no se asignó en el Inspector, busca la cámara principal
        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    void Update()
    {
       x = Time.deltaTime * joystick_cam.Vertical * speed;
       y = Time.deltaTime * joystick_cam.Horizontal * speed;
       cameraTransform.Rotate(-x, y, 0);
    }
}
