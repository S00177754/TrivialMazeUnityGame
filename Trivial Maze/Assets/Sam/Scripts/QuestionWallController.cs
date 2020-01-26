﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionWallController : MonoBehaviour
{ 
    public bool isInRange;
    public bool isAnswered;
    public Canvas QuestionCanvas;
    QuestionController questionControler;


    void Start()
    {
        questionControler = QuestionCanvas.GetComponentInChildren<QuestionController>();
         
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange)
        {
            //transform.parent.gameObject.GetComponent<Material>().SetColor("Color", Color.white);
            if(Input.GetKeyDown(KeyCode.G))
            {
                QuestionCanvas.gameObject.SetActive(true);
                QuestionCanvas.enabled = true;
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
                        QuestionCanvas.gameObject.SetActive(false);
                        break;//cannot reattempt answer
                    case (IsAnswerCorrect.yes):
                        isAnswered = true;
                        if (transform.parent.gameObject != null)
                        {
                            Debug.Log("Destroy Wall");
                            transform.parent.gameObject.SetActive(false);
                            questionControler.checkedAnswer = IsAnswerCorrect.unanswered;
                            QuestionCanvas.gameObject.SetActive(false);
                        }
                        break;
                }
            }
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