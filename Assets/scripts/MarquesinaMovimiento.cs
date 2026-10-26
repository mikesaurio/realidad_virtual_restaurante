
using UnityEngine;

public class MarquesinaMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad = 1.5f;
    [SerializeField] private float posicionInicial = 2f;
    [SerializeField] private float posicionFinal = -2f;

    private void Update()
    {
        Vector3 posicion = transform.localPosition;

        posicion.x -= velocidad * Time.deltaTime;

        if (posicion.x <= posicionFinal)
        {
            posicion.x = posicionInicial;
        }

        transform.localPosition = posicion;
    }
}
