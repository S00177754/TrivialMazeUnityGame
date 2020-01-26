using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestionWallController : MonoBehaviour
{ 
    public bool isInRange;
    public bool isAnswered;
    public Canvas QuestionCanvas;
    public Material DefaultMaterial;
    public Material InRangeMaterial;
    QuestionController questionControler;

    [Header("Text Prompt")]
    public TMP_Text triggerText;

    void Start()
    {
        questionControler = QuestionCanvas.GetComponentInChildren<QuestionController>();
         
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            triggerText.gameObject.SetActive(true);
            transform.parent.gameObject.GetComponent<MeshRenderer>().material = InRangeMaterial;
            //transform.parent.gameObject.GetComponent<Material>().SetColor("Color", Color.white);
            if(Input.GetKeyDown(KeyCode.G))
            {
                QuestionCanvas.gameObject.SetActive(true);
                QuestionCanvas.enabled = true;

                GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject player in gos)
                {
                    player.GetComponent<PlayerMovementController>().MovementLocked = true;
                }
            }

            if(!isAnswered && QuestionCanvas.isActiveAndEnabled)
            {
                switch(questionControler.checkedAnswer)
                {
                    case (IsAnswerCorrect.unanswered):
                        break;//no need for further action needed while not answered
                    case (IsAnswerCorrect.no):
                        isAnswered = true;
                        questionControler.checkedAnswer = IsAnswerCorrect.unanswered;
                        questionControler.ActiveQuestion = questionControler.QuestionQueue.Dequeue();
                        questionControler.QuestionQueue.Enqueue(questionControler.ActiveQuestion);
                        QuestionCanvas.gameObject.SetActive(false);
                        GameObject[] gos = GameObject.FindGameObjectsWithTag("Player");
                        foreach (GameObject player in gos)
                        {
                            player.GetComponent<PlayerMovementController>().MovementLocked = false;
                        }
                        break;//cannot reattempt answer
                    case (IsAnswerCorrect.yes):
                        isAnswered = true;
                        if (transform.parent.gameObject != null)
                        {
                            Debug.Log("Destroy Wall");
                            transform.parent.gameObject.SetActive(false);
                            questionControler.checkedAnswer = IsAnswerCorrect.unanswered;
                            questionControler.ActiveQuestion = questionControler.QuestionQueue.Dequeue();
                            questionControler.QuestionQueue.Enqueue(questionControler.ActiveQuestion);
                            QuestionCanvas.gameObject.SetActive(false);

                            GameObject[] gameobjs = GameObject.FindGameObjectsWithTag("Player");
                            foreach (GameObject player in gameobjs)
                            {
                                player.GetComponent<PlayerMovementController>().MovementLocked = false;
                            }
                        }
                        break;
                }
            }
        }
        else
        {
            transform.parent.gameObject.GetComponent<MeshRenderer>().material = DefaultMaterial;
            triggerText.gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }
}
