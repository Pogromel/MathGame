using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathQuizController : MonoBehaviour
{
    public GameObject quizPanel;
    public TMP_Text questionText;  
    public TMP_InputField answerInput;  
    public TMP_Text timerText;  
    public Button submitButton;

    private List<string> questions = new List<string>();
    private List<int> answers = new List<int>();
    private int correctAnwser;
    private float timeRemaining = 5f;
    private bool quizActive = false;
    
    private System.Action<bool> onQuizComplete;
    void Start()
    {
        quizPanel.SetActive(false);
        PopulateQuestions();
        submitButton.onClick.AddListener(CheckAnswer);
    }

    
    void Update()
    {
        if (quizActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.unscaledDeltaTime;
                timerText.text = "Time: " + Mathf.Ceil(timeRemaining).ToString("F0");
            }
            else
            {
                EndQuiz(false);
            }
        }
    }

    public void StartQuiz(System.Action<bool> callback)
    {
        quizActive = true;
        quizPanel.SetActive(true);
        Time.timeScale = 0;
        int questionIndex = Random.Range(0, questions.Count);
        questionText.text = questions[questionIndex];
        correctAnwser = answers[questionIndex];
        timeRemaining = 5f;
        
        answerInput.text = "";
        
        onQuizComplete = callback;
    }
    
    void CheckAnswer()
    {
        if (int.TryParse(answerInput.text, out int enteredAnswer))
        {
            if (enteredAnswer == correctAnwser)
            {
                EndQuiz(true);
            }
            else
            {
                EndQuiz(false);
            }
        }
        else
        {
            
            Debug.LogError("Invalid input. Please enter a numerical value.");
            answerInput.text = "";
            answerInput.placeholder.GetComponent<TMP_Text>().text = "Enter a number!";
        }
    }

    void EndQuiz(bool success)
    {
        quizActive = false;
        quizPanel.SetActive(false);
        Time.timeScale = 1;
        
        onQuizComplete?.Invoke(success);
        
        Debug.Log(success ? "Correct Answer!" : "Wrong Answer or Time Out!");
    }

    void PopulateQuestions()
    {
        
        questions.Add("10 + 15 = ?");
        answers.Add(25);
        questions.Add("12 - 7 = ?");
        answers.Add(5);
        
    }
}
