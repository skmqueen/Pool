using UnityEngine;
using System.Collections.Generic;
public class CanPool : MonoBehaviour
{
    public static CanPool instance;
    public GameObject prefab;
    public int maxElement;

    Stack<GameObject> pool = new Stack<GameObject>();

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        for (int i =0; i < maxElement; i++)
        {
            GameObject lata = Instantiate(prefab);
            lata.SetActive(false);
            pool.Push(lata);
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
 
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }
}
