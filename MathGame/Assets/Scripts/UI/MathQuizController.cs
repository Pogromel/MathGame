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
    private float timeRemaining = 20f;
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
        timeRemaining = 20f;
        
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
        questions.Add("24 + 18 = ?");
        answers.Add(42);
        questions.Add("55 - 21 = ?");
        answers.Add(34);
        questions.Add("37 + 19 = ?");
        answers.Add(56);
        questions.Add("65 - 32 = ?");
        answers.Add(33);
        questions.Add("45 + 28 = ?");
        answers.Add(73);
        questions.Add("80 - 35 = ?");
        answers.Add(45);
        questions.Add("26 + 17 = ?");
        answers.Add(43);
        questions.Add("93 - 44 = ?");
        answers.Add(49);
        questions.Add("38 + 29 = ?");
        answers.Add(67);
        questions.Add("77 - 23 = ?");
        answers.Add(54);
        questions.Add("53 + 22 = ?");
        answers.Add(75);
        questions.Add("94 - 38 = ?");
        answers.Add(56);
        questions.Add("41 + 37 = ?");
        answers.Add(78);
        questions.Add("88 - 47 = ?");
        answers.Add(41);
        questions.Add("49 + 28 = ?");
        answers.Add(77);
        questions.Add("73 - 25 = ?");
        answers.Add(48);
        questions.Add("36 + 27 = ?");
        answers.Add(63);
        questions.Add("65 - 28 = ?");
        answers.Add(37);
        questions.Add("57 + 16 = ?");
        answers.Add(73);
        questions.Add("84 - 42 = ?");
        answers.Add(42);
        questions.Add("34 + 29 = ?");
        answers.Add(63);
        questions.Add("92 - 47 = ?");
        answers.Add(45);
        questions.Add("27 + 35 = ?");
        answers.Add(62);
        questions.Add("61 - 18 = ?");
        answers.Add(43);
        questions.Add("39 + 32 = ?");
        answers.Add(71);
        questions.Add("76 - 33 = ?");
        answers.Add(43);
        questions.Add("48 + 27 = ?");
        answers.Add(75);
        questions.Add("82 - 31 = ?");
        answers.Add(51);
    }
}
