using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum IsAnswerCorrect
{
    yes, no, unanswered
}

public class QuestionController : MonoBehaviour
{
    public CanvasGroup QuestionPanelGroup;
    List<string> Answers;
    string questionJson;
    public List<TriviaQuestion> Questions;
    public Queue<TriviaQuestion> QuestionQueue;
    public TriviaQuestion ActiveQuestion;
    System.Random random;

    public float closeTimer;
    public bool isAnswered;
    bool isInitialized = false;
    public IsAnswerCorrect checkedAnswer;
    public Text txtQuestion;

    public List<Button> ButtonList;
    public List<Text> AnswerList;

    Button btnClickedButton;
    string ClickedButton;

    void Initialize()
    {
        isInitialized = true;
        ActiveQuestion = null;
        QuestionQueue = new Queue<TriviaQuestion>();
        Questions = new List<TriviaQuestion>();
        Answers = new List<string>();
        checkedAnswer = IsAnswerCorrect.unanswered;
        isAnswered = false;
        //Get Question object from API
        Questions = ApiHelper.GetQuestions();
        closeTimer = 0f;

        //initialise queue for each question from API
        foreach (TriviaQuestion question in Questions)
        {
            QuestionQueue.Enqueue(question);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(!isAnswered)
        //{
            if(checkedAnswer == IsAnswerCorrect.unanswered)
            {
                switch(checkedAnswer)
                {
                    case (IsAnswerCorrect.unanswered):
                        break;

                    case (IsAnswerCorrect.yes):
                        foreach (var button in ButtonList)
                        {
                            button.image.color = Color.gray;
                        }
                        btnClickedButton.image.color = Color.green;
                        //closeTimer = 5000f;
                        isAnswered = true;
                        ActiveQuestion = QuestionQueue.Dequeue();
                        QuestionQueue.Enqueue(ActiveQuestion);
                        transform.parent.gameObject.SetActive(false);
                        break;

                    case (IsAnswerCorrect.no):
                        foreach (var button in ButtonList)
                        {
                            button.image.color = Color.gray;
                        }
                        btnClickedButton.image.color = Color.red;
                        //closeTimer = 5000f;
                        ActiveQuestion = QuestionQueue.Dequeue();
                        QuestionQueue.Enqueue(ActiveQuestion);
                        isAnswered = true;
                        transform.parent.gameObject.SetActive(false);
                        break;
                }
            }
        //}


        //if (checkedAnswer == IsAnswerCorrect.no || checkedAnswer == IsAnswerCorrect.yes)
        //{
        //    if (closeTimer > 0f)
        //        closeTimer -= Time.deltaTime;
        //    if (closeTimer <= 0f)
        //        gameObject.SetActive(false);
               

        //}
    }


    //Fisher-Yates shuffle
    void Shuffle<T>(List<T> shuffleThis)
    {
        int j = shuffleThis.Count;
        while (j > 1)
        {
            j--;
            int k = random.Next(j + 1);
            T value = shuffleThis[k];
            shuffleThis[k] = shuffleThis[j];
            shuffleThis[j] = value;
        }
    }

    private void OnEnable()
    {
        if(!isInitialized)
            Initialize();
        //initialise question
        checkedAnswer = IsAnswerCorrect.unanswered;
        QuestionPanelGroup.alpha = 1;
        ActiveQuestion = QuestionQueue.Dequeue();
        QuestionQueue.Enqueue(ActiveQuestion);
        txtQuestion.text = ActiveQuestion.Question;

        foreach (var button in ButtonList)
        {
            button.image.color = Color.gray;
        }

        random = new System.Random();//using system.Random to differentiate from UnityEngine.Random

        //Assign quesion answers to list
        Answers.Clear();//clear previous answers
        Answers.Add(ActiveQuestion.Answer);
        Answers.Add(ActiveQuestion.FakeAnswerOne);
        Answers.Add(ActiveQuestion.FakeAnswerTwo);
        Answers.Add(ActiveQuestion.FakeAnswerThree);
        //shuffle list
        Shuffle(Answers);

        //Assign text to box and button text
        AnswerList[0].GetComponentInChildren<Text>().text = Answers[0];
        AnswerList[1].GetComponentInChildren<Text>().text = Answers[1];
        AnswerList[2].GetComponentInChildren<Text>().text = Answers[2];
        AnswerList[3].GetComponentInChildren<Text>().text = Answers[3];
    }

    public void ButtonClick()
    {
        //if(EventSystem.current.currentSelectedGameObject.gameObject.GetType() == typeof(Button))
        //{
            ClickedButton = EventSystem.current.currentSelectedGameObject.gameObject.name;
            
            switch(ClickedButton)
            {
                case ("Answer1"):
                    CheckAnswer(Answers[0]);
                    break;
                case ("Answer2"):
                    CheckAnswer(Answers[1]);
                    break;
                case ("Answer3"):
                    CheckAnswer(Answers[2]);
                    break;
                case ("Answer4"):
                    CheckAnswer(Answers[3]);
                    break;
                default:
                    break;
            }
        
    }

    void CheckAnswer(string contentString)
    {
        //checks if answer given is correct
        if(contentString == ActiveQuestion.Answer)
        {
            checkedAnswer = IsAnswerCorrect.yes;
        }
        else
        {
            checkedAnswer = IsAnswerCorrect.no;
        }

        btnClickedButton = EventSystem.current.currentSelectedGameObject.gameObject.GetComponent<Button>();
    }

    public bool IsAnsweredAndCorrect()
    {
        if (checkedAnswer == IsAnswerCorrect.yes)
            return true;
        else
            return false;
    }
}
