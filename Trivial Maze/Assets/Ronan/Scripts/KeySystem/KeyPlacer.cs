using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlacer : MonoBehaviour
{

    public List<GameObject> keys;
    public Transform parentGroup;

    public void InstantiateKeys()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("key");
        foreach (var go in gos)
        {
            Destroy(go);
        }
        foreach (var go in gos)
        {
            Instantiate(go,parentGroup,true);
        }

    }
}
