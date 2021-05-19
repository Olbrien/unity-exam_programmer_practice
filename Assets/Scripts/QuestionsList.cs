using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;

public class QuestionsList : MonoBehaviour
{
    public GameObject[] questions;
    public List<GameObject> questionsList;
    public MenuButtonsMap menuButtonsMap;

    public GameObject finishWindow;
    public GameObject timerAndOtherStuff;

    [Space(10)]

    public TextMeshProUGUI numberOfQuestionsText;

    public TextMeshProUGUI finishPercentageCorrectQuestions;
    public TextMeshProUGUI finishCorrectQuestions;
    public TextMeshProUGUI finishTimeRemaining;
    public TextMeshProUGUI finishTimeTotal;
    public TextMeshProUGUI finishPassedOrNot;

    [Space(10)]

    public TextMeshProUGUI bestDateQuestion;
    public TextMeshProUGUI bestTimeQuestion;
    public TextMeshProUGUI bestTimeTime;
    public TextMeshProUGUI latestDateQuestion;
    public TextMeshProUGUI latestTimeQuestion;
    public TextMeshProUGUI latestTimeTime;
    public TextMeshProUGUI worstDateQuestion;
    public TextMeshProUGUI worstTimeQuestion;
    public TextMeshProUGUI worstTimeTime;



    [Space(10)]
    public int howManyQuestions;
    public int correctQuestions;
    public bool isPracticeExam;
    public bool isExam;
    public bool hasFinishedExam;

    int currentQuestionNumber;
    bool hasFinished;

    private void Awake()
    {
        ShuffleQuestions();

        if (isExam)
        {
            UpdateRecords();
        }
    }


    void UpdateRecords()
    {
        int firstTimeFinishing = PlayerPrefs.GetInt("firstTimeFinishing");

        if (PlayerPrefs.HasKey("latestCorrectQuestions"))
        {
            float subtractedMinutes = 105 - PlayerPrefs.GetFloat("latestMinutes");
            float subtractedSeconds = 60 - PlayerPrefs.GetFloat("latestSeconds");

            latestDateQuestion.text = "Latest: <color=#C87027>" + PlayerPrefs.GetString("latestDate");
            latestTimeQuestion.text = PlayerPrefs.GetInt("latestCorrectQuestions").ToString() + " Correct Questions";
            latestTimeTime.text = "with " + PlayerPrefs.GetFloat("latestPercentage").ToString() + "% in "
                                  + subtractedMinutes.ToString() + ":"
                                  + subtractedSeconds.ToString() + " minutes.";
        }

        if (PlayerPrefs.HasKey("worstCorrectQuestions") && firstTimeFinishing == 1)
        {
            float subtractedMinutes = 105 - PlayerPrefs.GetFloat("worstMinutes");
            float subtractedSeconds = 60 - PlayerPrefs.GetFloat("worstSeconds");

            worstDateQuestion.text = "Worst: <color=#C87027>" + PlayerPrefs.GetString("worstDate");
            worstTimeQuestion.text = PlayerPrefs.GetInt("worstCorrectQuestions").ToString() + " Correct Questions";
            worstTimeTime.text = "with " + PlayerPrefs.GetFloat("worstPercentage").ToString() + "% in "
                                  + subtractedMinutes.ToString() + ":"
                                  + subtractedSeconds.ToString() + " minutes.";
        }

        if (PlayerPrefs.HasKey("bestCorrectQuestions") && firstTimeFinishing == 1)
        {
            float subtractedMinutes = 105 - PlayerPrefs.GetFloat("bestMinutes");
            float subtractedSeconds = 60 - PlayerPrefs.GetFloat("bestSeconds");

            bestDateQuestion.text = "Best: <color=#C87027>" + PlayerPrefs.GetString("bestDate");
            bestTimeQuestion.text = PlayerPrefs.GetInt("bestCorrectQuestions").ToString() + " Correct Questions";
            bestTimeTime.text = "with " + PlayerPrefs.GetFloat("bestPercentage").ToString() + "% in "
                                  + subtractedMinutes.ToString() + ":"
                                  + subtractedSeconds.ToString() + " minutes.";
        }
    }

    public void ShuffleQuestions()
    {
        for (int i = 0; i < questions.Length; i++)
        {
            GameObject tmp = questions[i];
            int r = UnityEngine.Random.Range(i, questions.Length);
            questions[i] = questions[r];
            questions[r] = tmp;

            if (howManyQuestions != 0 && howManyQuestions > i)
            {
                questionsList.Add(questions[i]);
            }
        }
    }


    // This method assigns the Question Numbers Text on each question, Enables the Question 1 GameObject
    // and assigns the Back, Next and Finish Button.
    public void StartTheQuestions()
    {
        if (isPracticeExam)
        {
            for (int i = 0; i < questionsList.Count; i++)
            {
                var questionsComponent = questionsList[i].GetComponent<Questions>();
                questionsComponent.AssignQuestionNumber(i + 1); // Question Number on Top of the Question.

                if (i == 0)
                {
                    questionsList[i].SetActive(true);
                    questionsComponent.nextQuestion.SetActive(true);        // Arrows Next Question
                    questionsComponent.previousQuestion.SetActive(false);   // Arrows Previous Question
                }

                else if (i == questionsList.Count - 1)
                {
                    questionsComponent.nextQuestion.SetActive(false);
                    questionsComponent.previousQuestion.SetActive(true);
                    questionsComponent.finishTest.SetActive(true);
                }

                else
                {
                    questionsComponent.nextQuestion.SetActive(true);
                    questionsComponent.previousQuestion.SetActive(true);
                }
            }

            numberOfQuestionsText.text = "of " + howManyQuestions.ToString();

            return;
        }


        for (int i = 0; i < questions.Length; i++)
        {            
            var questionsComponent = questions[i].GetComponent<Questions>();
            questionsComponent.AssignQuestionNumber(i + 1); // Question Number on Top of the Question.

            if (i == 0)
            {
                questions[i].SetActive(true);
                questionsComponent.nextQuestion.SetActive(true);        // Arrows Next Question
                questionsComponent.previousQuestion.SetActive(false);   // Arrows Previous Question
            }

            else if(i == questions.Length - 1)
            {
                questionsComponent.nextQuestion.SetActive(false);
                questionsComponent.previousQuestion.SetActive(true);
                questionsComponent.finishTest.SetActive(true);
            }

            else
            {
                questionsComponent.nextQuestion.SetActive(true);
                questionsComponent.previousQuestion.SetActive(true);
            }
        }
    }

    public void NextQuestion(int questionNumber)
    {
        questions[questionNumber - 1].SetActive(false);
        questions[questionNumber].SetActive(true);

        currentQuestionNumber = questionNumber;
    }

    public void PreviousQuestion(int questionNumber)
    {
        questions[questionNumber - 1].SetActive(false);
        questions[questionNumber - 2].SetActive(true);

        currentQuestionNumber = questionNumber;
    }

    public void OnClickReview()
    {
        questions[currentQuestionNumber].SetActive(false);
        questions[0].SetActive(true);
        finishWindow.gameObject.SetActive(false);
    }

    public void FinishedTestTextFillment()
    {
        if (hasFinished)
        {
            return;
        }
        

        hasFinished = true;

        float percentage = (float)correctQuestions / (float)questionsList.Count;

        if (correctQuestions == 0)
        {
            finishPercentageCorrectQuestions.text = "You got 0%";
        }
        else if (correctQuestions >= 1)
        {
            percentage = percentage * 100;
            percentage = Mathf.RoundToInt(percentage);

            finishPercentageCorrectQuestions.text = "You got " + percentage + "%";
        }

        finishCorrectQuestions.text = correctQuestions + " out of " + questionsList.Count + " questions.";

        float time = menuButtonsMap.timeOfTest + 1;        

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        finishTimeRemaining.text = string.Format("{0:00}:{1:00}", minutes, seconds + " minutes remaining");

        float timeStart = menuButtonsMap.begginingTime / 60;

        finishTimeTotal.text = string.Format("of " + timeStart.ToString() +" minutes total.");

        string theDate = DateTime.Now.ToString("dd/MM/yyyy");


        if (isExam && PlayerPrefs.HasKey("latestCorrectQuestions"))
        {
            PlayerPrefs.SetInt("latestCorrectQuestions", correctQuestions);
            PlayerPrefs.SetFloat("latestPercentage", percentage);
            PlayerPrefs.SetFloat("latestMinutes", minutes);
            PlayerPrefs.SetFloat("latestSeconds", seconds);
            PlayerPrefs.SetString("latestDate", theDate);

            PlayerPrefs.SetInt("firstTimeFinishing", 1);

            float subtractedMinutes = 105 - PlayerPrefs.GetFloat("latestMinutes");
            float subtractedSeconds = 60 - PlayerPrefs.GetFloat("latestSeconds");

            latestDateQuestion.text = "Latest: <color=#C87027>" + PlayerPrefs.GetString("latestDate");
            latestTimeQuestion.text = PlayerPrefs.GetInt("latestCorrectQuestions").ToString() + " Correct Questions";
            latestTimeTime.text = "with " + PlayerPrefs.GetFloat("latestPercentage").ToString() + "% in "
                                  + subtractedMinutes.ToString() + ":"
                                  + subtractedSeconds.ToString() + " minutes.";

            if (PlayerPrefs.GetInt("latestCorrectQuestions") > PlayerPrefs.GetInt("bestCorrectQuestions"))
            {
                PlayerPrefs.SetInt("bestCorrectQuestions", correctQuestions);
                PlayerPrefs.SetFloat("bestPercentage", percentage);
                PlayerPrefs.SetFloat("bestMinutes", minutes);
                PlayerPrefs.SetFloat("bestSeconds", seconds);
                PlayerPrefs.SetString("bestDate", theDate);

                subtractedMinutes = 105 - PlayerPrefs.GetFloat("bestMinutes");
                subtractedSeconds = 60 - PlayerPrefs.GetFloat("bestSeconds");

                bestDateQuestion.text = "Best: <color=#C87027>" + PlayerPrefs.GetString("bestDate");
                bestTimeQuestion.text = PlayerPrefs.GetInt("bestCorrectQuestions").ToString() + " Correct Questions";
                bestTimeTime.text = "with " + PlayerPrefs.GetFloat("bestPercentage").ToString() + "% in "
                                      + subtractedMinutes.ToString() + ":"
                                      + subtractedSeconds.ToString() + " minutes.";
            }

            if (PlayerPrefs.GetInt("latestCorrectQuestions") < PlayerPrefs.GetInt("worstCorrectQuestions"))
            {
                PlayerPrefs.SetInt("worstCorrectQuestions", correctQuestions);
                PlayerPrefs.SetFloat("worstPercentage", percentage);
                PlayerPrefs.SetFloat("worstMinutes", minutes);
                PlayerPrefs.SetFloat("worstSeconds", seconds);
                PlayerPrefs.SetString("worstDate", theDate);

                subtractedMinutes = 105 - PlayerPrefs.GetFloat("worstMinutes");
                subtractedSeconds = 60 - PlayerPrefs.GetFloat("worstSeconds");

                worstDateQuestion.text = "Worst: <color=#C87027>" + PlayerPrefs.GetString("worstDate");
                worstTimeQuestion.text = PlayerPrefs.GetInt("worstCorrectQuestions").ToString() + " Correct Questions";
                worstTimeTime.text = "with " + PlayerPrefs.GetFloat("worstPercentage").ToString() + "% in "
                                      + subtractedMinutes.ToString() + ":"
                                      + subtractedSeconds.ToString() + " minutes.";
            }
        }



        if (isExam && !PlayerPrefs.HasKey("latestCorrectQuestions"))
        {
            PlayerPrefs.SetInt("latestCorrectQuestions", correctQuestions);
            PlayerPrefs.SetFloat("latestPercentage", percentage);
            PlayerPrefs.SetFloat("latestMinutes", minutes);
            PlayerPrefs.SetFloat("latestSeconds", seconds);
            PlayerPrefs.SetString("latestDate", theDate);

            PlayerPrefs.SetInt("firstTimeFinishing", 0);

            float subtractedMinutes = 105 - PlayerPrefs.GetFloat("latestMinutes");
            float subtractedSeconds = 60 - PlayerPrefs.GetFloat("latestSeconds");

            latestDateQuestion.text = "Latest: <color=#C87027>" + PlayerPrefs.GetString("latestDate");
            latestTimeQuestion.text = PlayerPrefs.GetInt("latestCorrectQuestions").ToString() + " Correct Questions";
            latestTimeTime.text = "with " + PlayerPrefs.GetFloat("latestPercentage").ToString() + "% in "
                                  + subtractedMinutes.ToString() + ":"
                                  + subtractedSeconds.ToString() + " minutes.";


            if (!PlayerPrefs.HasKey("worstCorrectQuestions"))
            {
                PlayerPrefs.SetInt("worstCorrectQuestions", correctQuestions);
                PlayerPrefs.SetFloat("worstPercentage", percentage);
                PlayerPrefs.SetFloat("worstMinutes", minutes);
                PlayerPrefs.SetFloat("worstSeconds", seconds);
                PlayerPrefs.SetString("worstDate", theDate);
            }

            if (!PlayerPrefs.HasKey("bestCorrectQuestions"))
            {
                PlayerPrefs.SetInt("bestCorrectQuestions", correctQuestions);
                PlayerPrefs.SetFloat("bestPercentage", percentage);
                PlayerPrefs.SetFloat("bestMinutes", minutes);
                PlayerPrefs.SetFloat("bestSeconds", seconds);
                PlayerPrefs.SetString("bestDate", theDate);
            }
        }

        if (correctQuestions == 0)
        {
            finishPassedOrNot.text = "You Failed!";
            finishPassedOrNot.color = new Color32(255, 88, 59, 255);
            return;
        }

        if (percentage < 80)
        {
            finishPassedOrNot.text = "You Failed!";
            finishPassedOrNot.color = new Color32(255, 88, 59, 255);
        }

        else if (percentage >= 80)
        {
            finishPassedOrNot.text = "You Passed!";
            finishPassedOrNot.color = new Color32(127, 255, 95, 255);
        }
    }

    public void OnClickResetRecord()
    {
        PlayerPrefs.DeleteAll();
        timerAndOtherStuff.SetActive(false);
        menuButtonsMap.OnClickExam();
    }
}
