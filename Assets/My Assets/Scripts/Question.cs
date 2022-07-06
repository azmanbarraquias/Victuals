using UnityEngine;

[System.Serializable]
public class Question
{
    public QuestionData question;
}

[System.Serializable]
public class QuestionData
{
    [Header("Question")]
    public string question;

    [Space]

    public string answerA;
    public bool asnwerIsA;

    [Space]

    public string answerB;
    public bool asnwerIsB;

    [Space]

    public string answerC;
    public bool asnwerIsC;

    [Space]

    public string answerD;
    public bool asnwerIsD;

    [Space]

    public int cointEarn = 1;
}
