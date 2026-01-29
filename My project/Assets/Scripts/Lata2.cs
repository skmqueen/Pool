using UnityEngine;

public class Lata2 : MonoBehaviour
{
    public float tiempoLataActiva = 4f;
    public GameObject latoncia;
    public float tiempoLata;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = latoncia.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tiempoLata += Time.deltaTime;
        GameObject prefab = latoncia;
        if (tiempoLata >= tiempoLataActiva)
        {
            tiempoLata = 0f;
            EsferasPool.instance.PushObject(latoncia);
            latoncia.transform.position = Vector3.zero;
  
            latoncia.SetActive(false);

        }

    }
}
