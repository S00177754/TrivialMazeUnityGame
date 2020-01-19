using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public CanvasGroup QuestionPanelGroup;
    List<string> Answers;
    string questionJson;
    TriviaQuestion question;
    System.Random random;

    bool isCorrect;
    public Text txtQuestion;
    public Text Answer1;
    public Text Answer2;
    public Text Answer3;
    public Text Answer4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        QuestionPanelGroup.alpha = 1;
        //Get Question object from API
        questionJson = ApiHelper.GetJsonFromAPI("TriviaQuestion"); //this will pull down all trivia questions so fromjson<TriviaQ> wont work, youll need to use the list wrapper
        question = JsonUtility.FromJson<TriviaQuestion>(questionJson);
        txtQuestion.text = question.Question;
        random = new System.Random();
        Answers = new List<string>();
        //Assign quesion answers to list
        Answers.Add(question.Answer);
        Answers.Add(question.FakeAnswerOne);
        Answers.Add(question.FakeAnswerTwo);
        Answers.Add(question.FakeAnswerThree);
        //shuffle list
        Shuffle(Answers);

        //Assign text to box and button text
        Answer1.text = Answers[0];
        Answer2.text = Answers[1];
        Answer3.text = Answers[2];
        Answer4.text = Answers[3];
    }

    void CheckAnswer()
    {
        //checks if answer given is correct
        //get button text
        //compare with answer
        //update UI dependint on isCorrect

    }


}
