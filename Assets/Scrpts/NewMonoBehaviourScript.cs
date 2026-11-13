using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    //public float fuckyou;
    
    public Answers[] answers;

    public TMP_Text tquestion;
    public TMP_Text thint;
    public TMP_InputField tanswers;
    public Slider slider;

    [SerializeField]
    private int index = 0;
    [SerializeField]
    private float timeRemaining = 10f;

    public Button submit;

    public Button AI;

    void Start()
    {
        TextHandler();
        submit.onClick.AddListener(Answercheck);
        AI.onClick.AddListener(AIassistence);

    }

    // Update is called once per frame
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        slider.value = timeRemaining / 10f;

        if(timeRemaining <= 0f)
        {
            Debug.Log("Time's up!");
            Application.Quit();
        }
    }

    void TextHandler()
    {
        tquestion.text = answers[index].QuestionText;
       // tanswers.text = answers[index].CorrectAnswer;
        Debug.Log(answers[index].QuestionText);
    }

    void AIassistence()
    {
        thint.text = "Hint: " + answers[index].Hint;
    }

    public void Answercheck()
    {
        if (tanswers.text == answers[index].CorrectAnswer && index < answers.Length - 1)
        {
           index++;
            TextHandler();
        }
        else
        {
            Debug.Log("wrong answer or index is out of bounds");
        }
    }

    [System.Serializable]
    public class Answers
    {
        public string QuestionText;
        public string CorrectAnswer;

        public string Hint;
    }

    public class PuzzleManager
    {
        public Answers[] answers = new Answers[3];
    }
}
