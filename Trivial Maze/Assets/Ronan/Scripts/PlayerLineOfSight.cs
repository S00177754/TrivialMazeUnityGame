using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLineOfSight : MonoBehaviour {

    public LayerMask LayerMask;
    public Camera playerCamera;
    RaycastHit[] hitResults;
    List<string> objectsBlockingView = new List<string>();

	void Update ()
    {
        hitResults = Physics.RaycastAll(playerCamera.transform.position, playerCamera.transform.forward, Mathf.Infinity, LayerMask);

        if(hitResults.Length > 0)
        {
            //ShowAllObjects();

            for (int i = 0; i < hitResults.Length; i++)
            {
                if (!objectsBlockingView.Contains(hitResults[i].collider.gameObject.name))
                {
                    objectsBlockingView.Add(hitResults[i].collider.gameObject.name);
                    
                }
            }

            for (int i = 0; i < objectsBlockingView.Count; i++)
            {
                HideObject(objectsBlockingView[i]);
            }
        }
        else
        {
            //Show all previously hit objects
            ShowAllObjects();
        }

        
	}

    private void HideObject(string name)
    {
        GameObject foundObject = GameObject.Find(name);
        SetObjectAlpha(foundObject, 0.1f);

    }


    private void ShowObject(string name)
    {
        GameObject foundObject = GameObject.Find(name);
        SetObjectAlpha(foundObject, 1f);
    }

    private void SetObjectAlpha(GameObject foundObject,float alphaValue)
    {
        MeshRenderer render = foundObject.GetComponent<MeshRenderer>();
        Color originalColor = render.material.color;
        originalColor.a = alphaValue;
        render.material.color = originalColor;
    }

    private void ShowAllObjects()
    {
        for (int i = 0; i < objectsBlockingView.Count; i++)
        {
            ShowObject(objectsBlockingView[i]);
        }

        objectsBlockingView.Clear();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(playerCamera.transform.position, (playerCamera.transform.position + (playerCamera.transform.forward * 100)));
    }
}
