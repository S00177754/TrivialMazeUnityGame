using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum isAnswerCorrect
{
    yes, no, unanswered
}

public class QuestionController : MonoBehaviour
{
    public CanvasGroup QuestionPanelGroup;
    List<string> Answers;
    string questionJson;
    ListWrapper<TriviaQuestion> Questions;
    Queue<TriviaQuestion> QuestionQueue;
    TriviaQuestion ActiveQuestion;
    System.Random random;

    isAnswerCorrect checkedAnswer;
    public Text txtQuestion;
    public Button btnAnswer1;
    public Text Answer1;
    public Button btnAnswer2;
    public Text Answer2;
    public Button btnAnswer3;
    public Text Answer3;
    public Button btnAnswer4;
    public Text Answer4;

    public List<Button> ButtonList;
    public List<Text> AnswerList;

    Button btnClickedButton;
    string ClickedButton;
    string answewrString;

    void Start()
    {
        //Get Question object from API
        questionJson = ApiHelper.GetJsonFromAPI("TriviaQuestion"); 
        Questions = JsonUtility.FromJson<ListWrapper<TriviaQuestion>>(questionJson);
        //initialise queue for each question from API
        foreach (TriviaQuestion question in Questions.Items)
        {
            QuestionQueue.Enqueue(question);
        }
    }

    // Update is called once per frame
    void Update()
    {




        if(isActiveAndEnabled)
        {
            switch(checkedAnswer)
            {
                case (isAnswerCorrect.unanswered):
                    
                    break;
                case (isAnswerCorrect.yes):
                    foreach (var button in ButtonList)
                    {
                        button.image.color = Color.gray;
                    }
                    btnClickedButton.image.color = Color.green;
                    break;
                case (isAnswerCorrect.no):
                    foreach (var button in ButtonList)
                    {
                        button.image.color = Color.gray;
                    }
                    btnClickedButton.image.color = Color.red;
                    break;
            }
        }
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
        //initialise question
        checkedAnswer = isAnswerCorrect.unanswered;
        QuestionPanelGroup.alpha = 1;
        ActiveQuestion = QuestionQueue.Dequeue();
        QuestionQueue.Enqueue(ActiveQuestion);
        txtQuestion.text = ActiveQuestion.Question;

        foreach (var button in ButtonList)
        {
            button.image.color = Color.gray;
        }

        random = new System.Random();//using system.Random to differentiate from UnityEngine.Random
        Answers = new List<string>();
        //Assign quesion answers to list
        Answers.Clear();//clear previous answers
        Answers.Add(ActiveQuestion.Answer);
        Answers.Add(ActiveQuestion.FakeAnswerOne);
        Answers.Add(ActiveQuestion.FakeAnswerTwo);
        Answers.Add(ActiveQuestion.FakeAnswerThree);
        //shuffle list
        Shuffle(Answers);

        //Assign text to box and button text
        btnAnswer1.GetComponentInChildren<Text>().text = Answers[0];
        //Answer1.text = Answers[0];
        Answer2.text = Answers[1];
        Answer3.text = Answers[2];
        Answer4.text = Answers[3];
    }

    public void ButtonClick()
    {
        if(EventSystem.current.currentSelectedGameObject.gameObject.GetType() == typeof(Button))
        {
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
    }

    

    void CheckAnswer(string contentString)
    {
        //checks if answer given is correct
        if(contentString == ActiveQuestion.Answer)
        {
            checkedAnswer = isAnswerCorrect.yes;
        }
        else
        {
            checkedAnswer = isAnswerCorrect.no;
        }
        //get button text
        //compare with answer
        //update UI dependint on isCorrect

    }

    public bool IsAnsweredAndCorrect()
    {
        if (checkedAnswer == isAnswerCorrect.yes)
            return true;
        else
            return false;
    }
}
