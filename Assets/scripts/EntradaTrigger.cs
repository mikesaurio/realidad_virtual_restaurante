using UnityEngine;

public class EntradaTrigger : MonoBehaviour
{
    public AudioSource timbre;

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("Trigger entered by: " + other.tag);
        if (!other.CompareTag("Player"))
            return;

        Vector3 direccion = other.transform.position - transform.position;

        // Solo suena al entrar al restaurante
        if (Vector3.Dot(direccion, transform.forward) < 0)
        {
            Debug.Log("¡El Player entró al restaurante!");
            timbre.Play();
        }
    }
}