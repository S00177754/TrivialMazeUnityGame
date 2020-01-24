using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlacer : MonoBehaviour
{

    public List<Transform> keys;
    public GameObject KeyPrefab;

    public void InstantiateKeys()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("key");

        foreach (var go in gos)
        {
            Destroy(go);
        }

        foreach (var key in keys)
        {
            Instantiate(KeyPrefab,key);
        }

    }
}
