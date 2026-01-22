using UnityEngine;

public class CanCreator : MonoBehaviour
{
    public GameObject latoncia;
    public float tiempoLata = 5f;
    public float tiempoJuego;
    public float lataFuera = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        tiempoJuego += Time.deltaTime;
        Vector3 posicion = Vector3.zero;
        GameObject prefab = latoncia;

        if (tiempoJuego >= tiempoLata)
        {
            Instantiate(prefab, posicion, Quaternion.identity, transform);
            float tiempoLataActiva = Time.deltaTime;
            tiempoJuego = 0f;


        }
    }
}
