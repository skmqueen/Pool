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
        GameObject objectToReturn = null;
        if (pool.Count != 0)
        {
            objectToReturn = pool.Pop();
        }
        else
        {
            objectToReturn = Instantiate(prefab);
            objectToReturn.SetActive(false);
        }

        return objectToReturn;
    }

    public void PushObject(GameObject obj)
    {
        obj.SetActive(false);
        pool.Push(obj);

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
