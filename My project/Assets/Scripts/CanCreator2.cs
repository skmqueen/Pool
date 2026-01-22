using UnityEngine;

public class CanCreator2 : MonoBehaviour
{
    public float tiempoJuego;
    public GameObject latoncia;
    public float tiempoLata;
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
            GameObject latoncia = CanPool.instance.PopObject();
            latoncia.SetActive(true);
            tiempoJuego = 0f;


        }
    }
}
