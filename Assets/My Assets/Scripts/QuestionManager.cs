using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class QuestionManager : MonoBehaviour
{
    [Header("Set Question")]
    public Question[] questions;

    [Space]
    public TextMeshProUGUI questionTMPro;
    [Space]
    public TextMeshProUGUI asnwerATMPro;
    public TextMeshProUGUI asnwerBTMPro;
    public TextMeshProUGUI asnwerCTMPro;
    public TextMeshProUGUI asnwerDTMPro;

    [Space]
    public TextMeshProUGUI questionCountTMPro;
    [Space]

    public GameObject[] asnwerButton;
   
    public Button fiftyfiftyBtn;
    public Button livesBtn;

    [Space]

    // store the ununansweredQuestions.
    // Static so that when we reload the next scene it will remember the questions...
    private static List<Question> unansweredQuestions;

    private Question currentQuestion; //this will store question after get the random question

    // store the correct question
    private int currentNoQestion;

    public GameObject lives;

    public GameObject stageUI;

    public LevelManager levelManager;

    private int currenctQuestionIndex;

    public GameObject mainGameUI;

    // Start is called before the first frame update

    public void SetGame(Level _level)
    {
        questions = _level.question;
         currentNoQestion = questions.Length;
        // When start the game we want to load the questions
    }

    #region GetRandomQuestionMethod
    public void GetRandomQuestion()
    {
        EnableAnswerButton();
        // but first check is the unansweredQuestion is finish then we must load all the question to unansweredQuestions
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            // store to a list of unansweredQuestions <<< questions
            unansweredQuestions = questions.ToList<Question>();
        }

        // Get the random question index from list from unansweredQuestions
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);

        // lets select the question base on index
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionCountTMPro.text = (currentNoQestion--) + " / " + questions.Length; // 1++ / totalQuestions


        // remove question after set that current question from unansweredQuestion list
        unansweredQuestions.RemoveAt(randomQuestionIndex);

        // Set info to UI Text
        questionTMPro.text = currentQuestion.question.question;

        asnwerATMPro.text = currentQuestion.question.answerA;
        asnwerBTMPro.text = currentQuestion.question.answerB;
        asnwerCTMPro.text = currentQuestion.question.answerC;
        asnwerDTMPro.text = currentQuestion.question.answerD;

    }
    #endregion GetRandomQuestionMethod

    #region Buttons
    public void SelectButtonA()
    {
        if (currentQuestion.question.asnwerIsA == true)
        {

        }
        else
        {
            DoubleChanceUI();

            CheckLives();
        }

        NextQuestion();
    }

    public void SelectButtonB()
    {
        if (currentQuestion.question.asnwerIsB == true)
        {

        }
        else
        {
            DoubleChanceUI();

            CheckLives();

        }

        NextQuestion();

    }

    public void SelectButtonC()
    {
        if (currentQuestion.question.asnwerIsC == true)
        {

        }
        else
        {
            DoubleChanceUI();

            CheckLives();
        }

        NextQuestion();


    }

    public void SelectButtonD()
    {
        if (currentQuestion.question.asnwerIsD == true)
        {

        }
        else
        {
            DoubleChanceUI();

            CheckLives();
        }

        NextQuestion();



    }
    #endregion Buttons

    void CheckLives()
    {
        if (lives.transform.childCount == 1)
        {
        }
        else
        {
            Destroy(lives.transform.GetChild(0).gameObject);
        }
    }


    public void RemoveTwoWrongAnswer()
    {
        fiftyfiftyBtn.interactable = false;

    
        for (int i = 0; i < asnwerButton.Length; i++)
        {
            asnwerButton[i].GetComponent<Button>().interactable = false;
        }
        int correctAnswerIndex = 0;

        if (currentQuestion.question.asnwerIsA == true)
        {
            correctAnswerIndex = 0;
        }
        else if (currentQuestion.question.asnwerIsB == true)
        {
            correctAnswerIndex = 1;
        }
        else if (currentQuestion.question.asnwerIsC == true)
        {
            correctAnswerIndex = 2;
        }
        else
        {
            correctAnswerIndex = 3;
        }

        //enable the correct asnwer
        asnwerButton[correctAnswerIndex].GetComponent<Button>().interactable = true;

        var buttons = asnwerButton.Where(x => x.GetComponent<Button>().interactable == false).ToList();

        int randomIndex = Random.Range(0, buttons.Count);

        Debug.Log(buttons.Count);

        buttons[randomIndex].GetComponent<Button>().interactable = true;
        Debug.Log(randomIndex);

    }


    public void EnableAnswerButton()
    {
        foreach (var button in asnwerButton)
        {
            button.GetComponent<Button>().interactable = true;
        }
    }

    public void NextQuestion()
    {
        mainGameUI.SetActive(false);
        stageUI.SetActive(true);
        levelManager.UpdateTiles();
        fiftyfiftyBtn.interactable = true;
    }

    public void DoubleChances()
    {

    }

    public void DoubleChanceUI()
    {

    }

    public void LoadDoubleChancesQuestion()
    {

    }
}
