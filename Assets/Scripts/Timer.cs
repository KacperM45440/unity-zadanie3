using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float timerToCompleteQuestion = 15f;
    [SerializeField] private float timerToShowCorrectAnswer = 10f;
    
    [SerializeField] private Image timerImage;

    private bool isAnsweringQuestion = true;
    public float fillFraction;
    private float timerValue;

    private void Awake()
    {
        timerValue = timerToCompleteQuestion;
    }

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if (isAnsweringQuestion)
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timerToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timerToShowCorrectAnswer;
                GameManager.Instance.ShowCorrectAnswer();
                GameManager.Instance.SetUpButtonsState(false);
            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timerToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timerToCompleteQuestion;
                GameManager.Instance.GoToNextQuestion();
            }
        }

        timerImage.fillAmount = fillFraction;
        //Debug.Log(timerValue);
    }

    public void Activate(bool value)
    {
        gameObject.SetActive(value);
        timerImage.gameObject.SetActive(value);
    }
}
