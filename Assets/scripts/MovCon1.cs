using UnityEngine;

public class MovCon1 : MonoBehaviour
{
    public float velocidad = 2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * velocidad * Time.deltaTime);  //Vector3(0,1,0)
    }
}
