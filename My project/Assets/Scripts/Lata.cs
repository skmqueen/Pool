using UnityEngine;

public class Lata : MonoBehaviour
{

    public float tiempoLataActiva = 4f;
    public GameObject latoncia;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tiempoLata = Time.deltaTime;
        GameObject prefab = latoncia;
        if (tiempoLata >= tiempoLataActiva)
        {
            Destroy(prefab);
        }
        
    }
}
