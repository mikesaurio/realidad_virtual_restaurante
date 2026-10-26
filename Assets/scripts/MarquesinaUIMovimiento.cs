
using UnityEngine;

public class MarquesinaUIMovimiento : MonoBehaviour
{
    [SerializeField] private float velocidad = 100f;
    [SerializeField] private float posicionInicial = 400f;
    [SerializeField] private float posicionFinal = -400f;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        Vector2 posicion = rectTransform.anchoredPosition;
        posicion.x -= velocidad * Time.deltaTime;

        if (posicion.x <= posicionFinal)
        {
            posicion.x = posicionInicial;
        }

        rectTransform.anchoredPosition = posicion;
    }
}
