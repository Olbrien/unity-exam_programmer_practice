using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Questions : MonoBehaviour
{
    [Header("Questions List and Scriptable Object Question")]
    public QuestionsList questionsList;
    public SOQuestions soQuestions;
    MenuButtonsMap menuButtonsMap;


    [Header("Main GameObjects")]
    [Space(10)]
    public GameObject chooseTheSubject;

    [Header("Top Part")]
    [Space(10)]
    public GameObject showAnswerGameObject;
    public GameObject showQuestionGameObject;

    [Header("Scroll Views Question / Answer")]
    [Space(10)]
    public GameObject scrollViewQuestion;
    public GameObject scrollViewAnswer;

    [Header("Quit / Finished Test Windows")]
    [Space(10)]
    public GameObject quitWindow;
    public GameObject finishWindow;

    [Header("Question Next / Back / Finish / Finish Questions and Answers Text")]
    [Space(10)]
    public GameObject nextQuestion;
    public GameObject previousQuestion;
    public GameObject finishTest;
    public TextMeshProUGUI finishQuestionsAndAnswersText;

    public GameObject finishTestExam;


    [Header("Question Text")]
    [Space(10)]
    public TextMeshProUGUI questionNumber;

    [Header("Top Question Color")]
    [Space(10)]
    public Image topQuestionColor;

    [Header("Questions")]
    [Space(10)]
    public GameObject wrongAnswerOne;
    public GameObject wrongAnswerTwo;
    public GameObject wrongAnswerThree;
    public GameObject correctAnswerFour;

    [Header("Questions Button Interactibility")]
    [Space(10)]

    public Button wrongAnswerOneRayCast;
    public Button wrongAnswerTwoRayCast;
    public Button wrongAnswerThreeRayCast;
    public Button correctAnswerFourRayCast;

    [Header("Submit / Correct / Wrong")]
    [Space(10)]
    public GameObject submitAnswer;
    public GameObject wrongAnswer;
    public GameObject correctAnswer;


    [Header("Answers")]
    [Space(10)]

    public GameObject wrongAnswerOneYellowColor;
    public GameObject wrongAnswerOneRedColor;
    public GameObject wrongAnswerTwoYellowColor;
    public GameObject wrongAnswerTwoRedColor;
    public GameObject wrongAnswerThreeYellowColor;
    public GameObject wrongAnswerThreeRedColor;
    public GameObject correctAnswerOneYellowColor;
    public GameObject correctAnswerOneGreenColor;


    [Header("Contents from Questions and from Answers")]
    [Space(10)]
    public RectTransform contentQuestionsTransform;
    public RectTransform contentAnswersTransform;


    [Header("Scriptable Object Text Requirements")]
    [Space(10)]
    public TextMeshProUGUI questionTextForSO;
    public TextMeshProUGUI wrongAnswer1TextForSO;
    public TextMeshProUGUI wrongAnswer2TextForSO;
    public TextMeshProUGUI wrongAnswer3TextForSO;
    public TextMeshProUGUI correctAnswerTextForSO;
    public TextMeshProUGUI showAnswerTextForSO;


    int whichAnswerHeChose;
    bool isAnswerCorrect;
    bool hasTheQuestionBeenAnswered;

    [HideInInspector]
    public int randomNumber;
    bool didHeSwitchAnswer;
    bool wasItCorrectAnswer;

    int currentQuestionNumber;


    void OnEnable()
    {
        if (questionsList.hasFinishedExam)
        {
            WrongAndCorrectAnswer();
        }
    }

    void WrongAndCorrectAnswer()
    {
        OnClickSubmitAnswer();
        showAnswerGameObject.SetActive(true);
    }


    void Start()
    {
        menuButtonsMap = FindObjectOfType<MenuButtonsMap>();
        randomNumber = Random.Range(0, 9);
        AssignTheSOToTheGameObject();

        if (questionsList.isPracticeExam)
        {
            showAnswerGameObject.SetActive(false);
        }
    }


    public void AssignQuestionNumber(int number)
    {
        questionNumber.text = "Question " + number;
        currentQuestionNumber = number;
    }

    void AssignTheSOToTheGameObject()
    {
        questionTextForSO.text = soQuestions.question;
        wrongAnswer1TextForSO.text = soQuestions.wrongAnswer1;
        wrongAnswer2TextForSO.text = soQuestions.wrongAnswer2;
        wrongAnswer3TextForSO.text = soQuestions.wrongAnswer3;
        correctAnswerTextForSO.text = soQuestions.correctAnswer;
        showAnswerTextForSO.text = soQuestions.showAnswer;
    }


    public void RandomizeAnswers()
    {        
        Vector3 vectorPlacerholder;

        switch (randomNumber)
        {
            case 0:
                break;
            case 1:
                vectorPlacerholder = wrongAnswerThree.transform.position;
                wrongAnswerThree.transform.position = wrongAnswerTwo.transform.position;
                wrongAnswerTwo.transform.position = vectorPlacerholder;

                vectorPlacerholder = wrongAnswerOne.transform.position;
                wrongAnswerOne.transform.position = correctAnswerFour.transform.position;
                correctAnswerFour.transform.position = vectorPlacerholder;
                break;
            case 2:
                vectorPlacerholder = correctAnswerFour.transform.position;
                correctAnswerFour.transform.position = wrongAnswerTwo.transform.position;
                wrongAnswerTwo.transform.position = vectorPlacerholder;
                break;
            case 3:
                vectorPlacerholder = correctAnswerFour.transform.position;
                correctAnswerFour.transform.position = wrongAnswerOne.transform.position;
                wrongAnswerOne.transform.position = vectorPlacerholder;

                vectorPlacerholder = wrongAnswerTwo.transform.position;
                wrongAnswerTwo.transform.position = wrongAnswerThree.transform.position;
                wrongAnswerThree.transform.position = vectorPlacerholder;
                break;
            case 4:
                vectorPlacerholder = wrongAnswerTwo.transform.position;
                wrongAnswerTwo.transform.position = correctAnswerFour.transform.position;
                correctAnswerFour.transform.position = vectorPlacerholder;
                break;
            case 5:
                vectorPlacerholder = wrongAnswerThree.transform.position;
                wrongAnswerThree.transform.position = correctAnswerFour.transform.position;
                correctAnswerFour.transform.position = vectorPlacerholder;
                break;
            case 6:
                vectorPlacerholder = wrongAnswerTwo.transform.position;
                wrongAnswerTwo.transform.position = correctAnswerFour.transform.position;
                correctAnswerFour.transform.position = vectorPlacerholder;
                break;
            case 7:
                vectorPlacerholder = correctAnswerFour.transform.position;
                correctAnswerFour.transform.position = wrongAnswerThree.transform.position;
                wrongAnswerThree.transform.position = vectorPlacerholder;
                break;
            case 8:
                break;
        }
    }

    public void OnClickWrongAnswerOne()
    {
        wrongAnswerOneYellowColor.SetActive(true);
        wrongAnswerTwoYellowColor.SetActive(false);
        wrongAnswerThreeYellowColor.SetActive(false);
        correctAnswerOneYellowColor.SetActive(false);
        isAnswerCorrect = false;
        whichAnswerHeChose = 1;

        if (questionsList.isPracticeExam)
        {
            IsPracticeExam(whichAnswerHeChose);
            return;
        }

        submitAnswer.SetActive(true);
    }

    public void OnClickWrongAnswerTwo()
    {
        wrongAnswerOneYellowColor.SetActive(false);
        wrongAnswerTwoYellowColor.SetActive(true);
        wrongAnswerThreeYellowColor.SetActive(false);
        correctAnswerOneYellowColor.SetActive(false);
        isAnswerCorrect = false;
        whichAnswerHeChose = 2;

        if (questionsList.isPracticeExam)
        {
            IsPracticeExam(whichAnswerHeChose);
            return;
        }

        submitAnswer.SetActive(true);
    }

    public void OnClickWrongAnswerThree()
    {
        wrongAnswerOneYellowColor.SetActive(false);
        wrongAnswerTwoYellowColor.SetActive(false);
        wrongAnswerThreeYellowColor.SetActive(true);
        correctAnswerOneYellowColor.SetActive(false);
        isAnswerCorrect = false;
        whichAnswerHeChose = 3;

        if (questionsList.isPracticeExam)
        {
            IsPracticeExam(whichAnswerHeChose);
            return;
        }

        submitAnswer.SetActive(true);
    }

    public void OnClickCorrectAnswerOne()
    {
        wrongAnswerOneYellowColor.SetActive(false);
        wrongAnswerTwoYellowColor.SetActive(false);
        wrongAnswerThreeYellowColor.SetActive(false);
        correctAnswerOneYellowColor.SetActive(true);
        isAnswerCorrect = true;
        whichAnswerHeChose = 4;

        if (questionsList.isPracticeExam)
        {
            IsPracticeExam(whichAnswerHeChose);
            return;
        }

        submitAnswer.SetActive(true);
    }


    public void OnClickSubmitAnswer()
    {
        hasTheQuestionBeenAnswered = true;

        if (isAnswerCorrect)
        {
            if (!questionsList.isPracticeExam)
            {
                submitAnswer.SetActive(false);
                correctAnswer.SetActive(true);
                wrongAnswer.SetActive(false);
            }

            else if (questionsList.isPracticeExam)
            {                
                topQuestionColor.color = new Color32(96, 255, 135, 255);
            }

            wrongAnswerOneRayCast.interactable = false;
            wrongAnswerTwoRayCast.interactable = false;
            wrongAnswerThreeRayCast.interactable = false;
            correctAnswerFourRayCast.interactable = false;

            wrongAnswerOneYellowColor.SetActive(false);
            wrongAnswerTwoYellowColor.SetActive(false);
            wrongAnswerThreeYellowColor.SetActive(false);
            correctAnswerOneYellowColor.SetActive(false);

            correctAnswerOneGreenColor.SetActive(true);

            questionsList.correctQuestions += 1;
        }

        else
        {
            if (!questionsList.isPracticeExam)
            {
                submitAnswer.SetActive(true);
                correctAnswer.SetActive(false);
                wrongAnswer.SetActive(true);
            }

            else if (questionsList.isPracticeExam)
            {                
                topQuestionColor.color = new Color32(255, 136, 117, 255);
            }

            wrongAnswerOneRayCast.interactable = false;
            wrongAnswerTwoRayCast.interactable = false;
            wrongAnswerThreeRayCast.interactable = false;
            correctAnswerFourRayCast.interactable = false;

            wrongAnswerOneYellowColor.SetActive(false);
            wrongAnswerTwoYellowColor.SetActive(false);
            wrongAnswerThreeYellowColor.SetActive(false);
            correctAnswerOneYellowColor.SetActive(false);

            correctAnswerOneGreenColor.SetActive(true);

            switch (whichAnswerHeChose)
            {
                case 1:
                    wrongAnswerOneRedColor.SetActive(true);
                    break;
                case 2:
                    wrongAnswerTwoRedColor.SetActive(true);
                    break;
                case 3:
                    wrongAnswerThreeRedColor.SetActive(true);
                    break;                
            }
        }
    }


    public void OnClickShowAnswer()
    {
        if (hasTheQuestionBeenAnswered == false)
        {
            wrongAnswerOneRayCast.interactable = false;
            wrongAnswerTwoRayCast.interactable = false;
            wrongAnswerThreeRayCast.interactable = false;
            correctAnswerFourRayCast.interactable = false;


            correctAnswerOneGreenColor.SetActive(true);

            wrongAnswerOneYellowColor.SetActive(false);
            wrongAnswerTwoYellowColor.SetActive(false);
            wrongAnswerThreeYellowColor.SetActive(false);
            correctAnswerOneYellowColor.SetActive(false);


            submitAnswer.SetActive(false);
        }

        showAnswerGameObject.SetActive(false);
        showQuestionGameObject.SetActive(true);

        scrollViewQuestion.SetActive(false);
        scrollViewAnswer.SetActive(true);
    }


    public void OnClickShowQuestion()
    {
        showAnswerGameObject.SetActive(true);
        showQuestionGameObject.SetActive(false);

        scrollViewQuestion.SetActive(true);
        scrollViewAnswer.SetActive(false);
    }

    
    public void OnClickQuit()
    {
        quitWindow.SetActive(true);
    }

    public void OnClickStayOnQuit()
    {
        quitWindow.SetActive(false);
    }

    public void OnClickQuitOnQuit()
    {
        this.gameObject.SetActive(false);
        menuButtonsMap.OnClickPreviousOnTheScene();
    }

    public void OnClickNextQuestion()
    {
        questionsList.NextQuestion(currentQuestionNumber);
    }

    public void OnClickPreviousQuestion()
    {
        questionsList.PreviousQuestion(currentQuestionNumber);
    }


    public void OnClickFinish()
    {
        if (questionsList.isPracticeExam)
        {
            questionsList.FinishedTestTextFillment();
            finishTestExam.SetActive(true);
            menuButtonsMap.startTheTimer = false;
            questionsList.hasFinishedExam = true;
            return;
        }

        finishWindow.SetActive(true);

        if (questionsList.isPracticeExam)
        {
            if (questionsList.correctQuestions > questionsList.questionsList.Count - 3)
            {
                finishQuestionsAndAnswersText.text = "You got " + questionsList.correctQuestions + " out of "
                                         + questionsList.questionsList.Count + ". \n \n" +
                                         "Maybe there's still hope! Good job you!";
            }
            else
            {
                finishQuestionsAndAnswersText.text = "You got " + questionsList.correctQuestions + " out of "
                                                     + questionsList.questionsList.Count + ". \n \n" +
                                                     "You're still not ready for it. Study more!";
            }
            return;
        }


        if (questionsList.correctQuestions > questionsList.questions.Length - 3)
        {
            finishQuestionsAndAnswersText.text = "You got " + questionsList.correctQuestions + " out of "
                                     + questionsList.questions.Length + ". \n \n" +
                                     "Maybe there's still hope! Good job you!";
        }
        else
        {
            finishQuestionsAndAnswersText.text = "You got " + questionsList.correctQuestions + " out of "
                                                 + questionsList.questions.Length + ". \n \n" +
                                                 "You're still not ready for it. Study more!";
        }
    }


    void IsPracticeExam(int number)
    {
        topQuestionColor.color = new Color32(250, 255, 112, 255);

        if (didHeSwitchAnswer)
        {
            didHeSwitchAnswer = false;

            if (wasItCorrectAnswer)
            {
                wasItCorrectAnswer = false;
                questionsList.correctQuestions -= 1;
            }
        }

        if (didHeSwitchAnswer == false)
        {
            if (whichAnswerHeChose == 1 || whichAnswerHeChose == 2 || whichAnswerHeChose == 3)
            {
                didHeSwitchAnswer = true;
            }

            else if (whichAnswerHeChose == 4)
            {
                didHeSwitchAnswer = true;
                wasItCorrectAnswer = true;
                questionsList.correctQuestions += 1;
            }
        }
    }
}
