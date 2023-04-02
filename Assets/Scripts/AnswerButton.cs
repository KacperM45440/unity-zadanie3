using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI answerText;
    [SerializeField] private Image outline;
    [SerializeField] private Button button;

    private bool correctAnswer = false;

    private void Awake()
    {
        button.onClick.AddListener(CheckAnswer);
    }

    public void SetAnswer(string answer, bool correctAnswer)
    {
        outline.color = Color.white;
        answerText.text = answer;
        this.correctAnswer = correctAnswer;
    }

    private void CheckAnswer()
    {
        if (correctAnswer)
        {
            ShowCorrectAnswer();
        }
        else
        {
            ShowUnCorrectAnswer();
        }
        GameManager.Instance.UpdateScore(correctAnswer);
        GameManager.Instance.PrepareNewQuestion();
    }

    public void ShowCorrectAnswer()
    {
        outline.color = Color.green;
    }

    private void ShowUnCorrectAnswer()
    {
        outline.color = Color.red;
        GameManager.Instance.ShowCorrectAnswer();
    }

    public void SetUpButtonState(bool value)
    {
        button.interactable = value;
    }
}
