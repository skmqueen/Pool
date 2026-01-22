using UnityEngine;
using System.Collections.Generic;

public class EsferasPool : MonoBehaviour
{
    public static EsferasPool instance;
    public GameObject prefab;
    public int maxElement = 10;

    Stack<GameObject> pool = new Stack<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        for (int i = 0; i < maxElement; i++)
        {
            GameObject esfera = Instantiate(prefab);
            esfera.SetActive(false);
            pool.Push(esfera);
        }
    }

    public GameObject PopObject()
    {
        GameObject obj;

        if (pool.Count > 0)
        {
            obj = pool.Pop();
        }
        else
        {
            obj = Instantiate(prefab);
        }

        // Reiniciar estado
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        obj.SetActive(true);
        return obj;
    }

    public void PushObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);
    }
}
