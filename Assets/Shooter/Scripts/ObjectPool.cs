using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int createOnStart;

    private List<GameObject> pool = new();

    private void Start()
    {
        for(int i = 0; i < createOnStart; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        var gameObject = Instantiate(prefab);
        gameObject.SetActive(false);

        pool.Add(gameObject);

        return gameObject;
    }

    public GameObject GetObject()
    {
        var objectToTake = pool.Find(x => x.activeInHierarchy == false);

        if(objectToTake == null)
        {
            objectToTake = CreateNewObject();
        }

        objectToTake.SetActive(true);

        return objectToTake;
    }
}
