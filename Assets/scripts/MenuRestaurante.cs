
using UnityEngine;

public class MenuRestaurante : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;

    public void AlternarMenu()
    {
        if (panelMenu != null)
        {
            panelMenu.SetActive(!panelMenu.activeSelf);
        }
    }
}
