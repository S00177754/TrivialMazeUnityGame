using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaDoorController : MonoBehaviour
{
    public GameObject QuestionCanvas;

    private void Start()
    {
        QuestionCanvas.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        QuestionCanvas.SetActive(true);
    }
}
