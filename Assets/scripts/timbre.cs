using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private Renderer rend;
    // Este método se ejecuta cuando otro collider entra en el trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Cápsula con tag "Player"
        {
            Debug.Log("La cápsula tocó el cubo!");
            // Aquí puedes poner cualquier acción, por ejemplo cambiar color:
            GetComponent<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("La cápsula salió del cubo!");
            GetComponent<Renderer>().material.color = Color.gray; // Vuelve a gris al salir
        }
    }
}