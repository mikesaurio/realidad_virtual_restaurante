using UnityEngine;

public class AutomaticDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = new Vector3(-2.97f, 0.26f, 5.43f);
            transform.rotation = Quaternion.Euler(0f, -8.29f, 0f);
        }
    }
}