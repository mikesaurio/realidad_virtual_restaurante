
using UnityEngine;

public class ControlLuces : MonoBehaviour
{
    [SerializeField] private Light[] luces;
    private bool lucesEncendidas = true;

    public void AlternarLuces()
    {
        lucesEncendidas = !lucesEncendidas;

        foreach (Light luz in luces)
        {
            if (luz != null)
            {
                luz.enabled = lucesEncendidas;
            }
        }
    }
}
