 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderboardController : MonoBehaviour
{
    public LoginController loginController;
    public RectTransform Content;
    public GameObject ScorePanelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayPersonalHighscores()
    {
        ClearContent();
        GenerateScoresByUsername();
    }

    public void DisplayTopTenScores()
    {
        ClearContent();
        GenerateTopScores();
    }

    public void ClearContent()
    {
        for (int i = 0; i < Content.childCount; i++)
        {
            Destroy(Content.GetChild(i).gameObject);
        }
    }

    public void GenerateScoresByUsername()
    {
        List<TimeScore> scores = ApiHelper.GetScores(loginController.Username);

        GameObject scorePanel;

        for (int i = 0; i < scores.Count; i++)
        {
            scorePanel = Instantiate(ScorePanelPrefab, Content);
            scorePanel.GetComponent<TimerScorePanel>().SetDetails(scores[i]);
            scorePanel.GetComponent<TimerScorePanel>().SetPosition(i + 1);
        }
    }

    public void GenerateTopScores()
    {
        List<TimeScore> scores = ApiHelper.GetScores(10);

        GameObject scorePanel;

        for (int i = 0; i < scores.Count; i++)
        {
            scorePanel = Instantiate(ScorePanelPrefab, Content);
            scorePanel.GetComponent<TimerScorePanel>().SetDetails(scores[i]);
            scorePanel.GetComponent<TimerScorePanel>().SetPosition(i + 1);
        }
    }

}
