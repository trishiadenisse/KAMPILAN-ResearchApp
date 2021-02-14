using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager1 : MonoBehaviour
{

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text factText;

    public GameObject PostTestPANEL;
    public GameObject GameOverPANEL;

    public Text ScoreTXT;

    int totalQuestions = 0;
    public int score;

    [SerializeField]
    private Text trueAnswerText;
    [SerializeField]
    private Text falseAnswerText;


    [SerializeField]
    private float timeBetweenQuestions = 1f;

    void Start ()
    {
       
        GameOverPANEL.SetActive(false);
        
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
            totalQuestions = unansweredQuestions.Count;
        }

        SetCurrentQuestion();     
    }

    public void retry (){
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver (){
        GameOverPANEL.SetActive(true);
        PostTestPANEL.SetActive(false);
        ScoreTXT.text = score + "/" + totalQuestions;
    }

    void SetCurrentQuestion()
    {
        if (unansweredQuestions.Count > 0)
        {
            int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
            currentQuestion = unansweredQuestions[randomQuestionIndex];

            factText.text = currentQuestion.fact;

        } else{
            Debug.Log("Out Of Questions!");
            GameOver();
            } 
    }

    IEnumerator TransitionToNextQuestion ()
    {
        unansweredQuestions.Remove (currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestions);
        SetCurrentQuestion ();
    }

    public void UserSelectTrue ()
    {

       
        if (currentQuestion.isTrue)
        {
            score += 1;
            Debug.Log("CORRECTT!!!");
            trueAnswerText.text = "CORRECT!!!";
            falseAnswerText.text = "WRONG!!!";
        } else
        {
            Debug.Log("WRONG!");
            trueAnswerText.text = "WRONG!!!";
            falseAnswerText.text = "CORRECT!!!";
        }

        StartCoroutine(TransitionToNextQuestion());
    }  
    
    public void UserSelectFalse ()
    {

       
        if (!currentQuestion.isTrue)
        {
            score += 1;
            Debug.Log("CORRECTT!!!");
            trueAnswerText.text = "CORRECT!!!";
            falseAnswerText.text = "WRONG!!!";
        } else
        {
            Debug.Log("WRONG!");
            trueAnswerText.text = "WRONG!!!";
            falseAnswerText.text = "CORRECT!!!";
        }

        StartCoroutine(TransitionToNextQuestion());
    }
}
