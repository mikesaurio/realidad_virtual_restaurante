
using TMPro;
using UnityEngine;

public class RestaurantUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textoInstrucciones;
    [SerializeField] private GameObject panelInstrucciones;

    public void OcultarInstrucciones()
    {
        if (panelInstrucciones != null)
        {
            panelInstrucciones.SetActive(false);
        }
        else if (textoInstrucciones != null)
        {
            textoInstrucciones.gameObject.SetActive(false);
        }
    }
    public void MostrarInstrucciones()
    {
        if (panelInstrucciones != null)
        {
            panelInstrucciones.SetActive(true);
        }
        else if (textoInstrucciones != null)
        {
            textoInstrucciones.gameObject.SetActive(true);
        }
    }
}
