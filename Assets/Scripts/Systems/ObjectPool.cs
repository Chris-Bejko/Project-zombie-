using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> pooledObjects = new();

    [SerializeField]
    private GameObject objectToPool;

    [SerializeField]
    private int amountToPool;

    private void Awake()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            var go = Instantiate(objectToPool, transform);
            go.SetActive(false);
            pooledObjects.Add(go);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (var e in pooledObjects)
            if (!e.activeInHierarchy)
                return e;

        return Instantiate(objectToPool, transform);   
    }
}