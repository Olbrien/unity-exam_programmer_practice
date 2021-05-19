using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuButtonsMap : MonoBehaviour
{
    // Main Menu Buttons
    [Header("Menu GameObjects")]
    public GameObject loadingScreen;
    [Space(5)]
    public GameObject chooseTheSubject;
    public GameObject chooseThePracticeTest;
    public GameObject chooseOneOfTheFollowing;
    public GameObject chooseOneOfTheFollowingUnofficial;

    public GameObject mainMenu;

    // Questions and Answers Menu Buttons
    [Header("Questions and Answers Menu GameObjects")]
    [Space(10)]
    public GameObject chooseTheTopic;

    [Header("Questions List")]
    [Space(10)]
    public QuestionsList questionsList1;
    public QuestionsList questionsList2;
    public QuestionsList questionsList3;
    public QuestionsList questionsList4;
    public QuestionsList questionsList5;
    public QuestionsList questionsList6;
    public QuestionsList questionsList7;
    public QuestionsList questionsList8;
    public QuestionsList questionsList9;

    // Questions and Answers Menu Buttons
    [Header("Questions and Time in Minutes")]
    [Space(10)]
    public Image numberOfQuestionsColor;
    public Image timeInMinutesColor;
    public Text numberOfQuestionsInsertText;
    public Text timeInMinutesInsertText;
    public TextMeshProUGUI timeText;

    [Header("Questions and Answers Menu GameObjects")]
    [Space(10)]
    public GameObject finishTestExam;

    [HideInInspector]
    public bool startTheTimer;
    [HideInInspector]
    public float timeOfTest;
    [HideInInspector]
    public float begginingTime;

    public int questionsLimitForExam;

    void Update()
    {
        if (startTheTimer)
        {
            if (timeOfTest > 0)
            {
                timeOfTest -= Time.deltaTime;
                DisplayTime(timeOfTest);
            }

            else
            {                
                startTheTimer = false;

                questionsList1.FinishedTestTextFillment();
                finishTestExam.SetActive(true);
                questionsList1.hasFinishedExam = true;

                timeOfTest = 0;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    // Main Menu Methods

    public void OnClickUnity()
    {
        chooseTheSubject.SetActive(false);
        chooseThePracticeTest.SetActive(true);
    }

    public void OnClickUnityUCP572()
    {
        chooseThePracticeTest.SetActive(false);
        chooseOneOfTheFollowing.SetActive(true);
    }

    public void OnClickUnityUnofficial()
    {
        chooseThePracticeTest.SetActive(false);
        chooseOneOfTheFollowingUnofficial.SetActive(true);
    }

    public void OnClickListOfQuestionsAndAnswersOficial()
    {
        chooseOneOfTheFollowing.SetActive(false);
        StartCoroutine(LoadSceneQuestionsAndAnswersUnity(1));
    }

    public void OnClickListOfQuestionsAndAnswersUnoficial()
    {
        chooseOneOfTheFollowingUnofficial.SetActive(false);
        StartCoroutine(LoadSceneQuestionsAndAnswersUnity(2));
    }

    public void OnClickPracticeTestUCP()
    {
        chooseOneOfTheFollowing.SetActive(false);
        StartCoroutine(LoadSceneQuestionsAndAnswersUnity(3));
    }

    public void OnClickPracticeTestEbook()
    {
        chooseOneOfTheFollowingUnofficial.SetActive(false);
        StartCoroutine(LoadSceneQuestionsAndAnswersUnity(4));
    }

    public void OnClickExam()
    {
        chooseTheSubject.SetActive(false);
        StartCoroutine(LoadSceneQuestionsAndAnswersUnity(5));
    }

    IEnumerator LoadSceneQuestionsAndAnswersUnity(int sceneNumber)
    {
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneNumber);

        while (!operation.isDone)
        {
            yield return null;
        }
    }


    public void OnClickPreviousOnMainMenu()
    {
       if (chooseOneOfTheFollowing.activeInHierarchy) { chooseOneOfTheFollowing.SetActive(false); chooseThePracticeTest.SetActive(true); }
       else if (chooseThePracticeTest.activeInHierarchy) { chooseThePracticeTest.SetActive(false); chooseTheSubject.SetActive(true); }
       else if (chooseOneOfTheFollowingUnofficial.activeInHierarchy) { chooseOneOfTheFollowingUnofficial.SetActive(false); chooseThePracticeTest.SetActive(true); }
    }



    // Questions and Answers Menu Methods


    public void OnClickProgrammingCoreInteractions()
    {
        chooseTheTopic.SetActive(false);
        questionsList1.StartTheQuestions();
    }

    public void OnClickWorkingArtPipeline()
    {
        chooseTheTopic.SetActive(false);
        questionsList2.StartTheQuestions();
    }

    public void OnClickDevelopingApplicationSystems()
    {
        chooseTheTopic.SetActive(false);
        questionsList3.StartTheQuestions();
    }

    public void OnclickProgrammingSceneEnvironmentDesign()
    {
        chooseTheTopic.SetActive(false);
        questionsList4.StartTheQuestions();
    }

    public void OnclickOptimizingPerformancePlatforms()
    {
        chooseTheTopic.SetActive(false);
        questionsList5.StartTheQuestions();
    }

    public void OnClickWorkingInTeams()
    {
        chooseTheTopic.SetActive(false);
        questionsList6.StartTheQuestions();
    }

    public void OnClickPreviousOnTheScene()
    {
        chooseTheSubject.SetActive(false);

        var scene = SceneManager.GetActiveScene();        

        mainMenu.SetActive(false);
        StartCoroutine(LoadSceneQuestionsAndAnswersUnity(scene.buildIndex));
    }

    public void OnClickPreviousOnQuestionsAndAnswersMenu()
    {
        chooseTheSubject.SetActive(false);

        mainMenu.SetActive(false);
        StartCoroutine("LoadSceneToMainMenu");
    }

    IEnumerator LoadSceneToMainMenu()
    {
        loadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(0);

        while (!operation.isDone)
        {
            yield return null;
        }
    }


    ////////////////////////////////
    /// Packt 
    ///////////////////////////////
    

    public void OnClickPacktChapterOne()
    {
        chooseTheTopic.SetActive(false);
        questionsList1.StartTheQuestions();
    }

    public void OnClickPacktChapterTwo()
    {
        chooseTheTopic.SetActive(false);
        questionsList2.StartTheQuestions();
    }

    public void OnClickPacktChapterThree()
    {
        chooseTheTopic.SetActive(false);
        questionsList3.StartTheQuestions();
    }

    public void OnClickPacktChapterFour()
    {
        chooseTheTopic.SetActive(false);
        questionsList4.StartTheQuestions();
    }

    public void OnClickPacktChapterFive()
    {
        chooseTheTopic.SetActive(false);
        questionsList5.StartTheQuestions();
    }

    public void OnClickPacktChapterSix()
    {
        chooseTheTopic.SetActive(false);
        questionsList6.StartTheQuestions();
    }

    public void OnClickPacktChapterSeven()
    {
        chooseTheTopic.SetActive(false);
        questionsList7.StartTheQuestions();
    }

    public void OnClickPacktChapterEight()
    {
        chooseTheTopic.SetActive(false);
        questionsList8.StartTheQuestions();
    }

    public void OnClickPacktChapterNine()
    {
        chooseTheTopic.SetActive(false);
        questionsList9.StartTheQuestions();
    }


    ////////////////////////////////
    /// Unity Oficial Practice Exame 
    ///////////////////////////////
    

    public void OnClickStartPracticeTestUCP()
    {
        if (questionsList1.isExam)
        {
            SetTheTimer();

            questionsList1.howManyQuestions = 60;
            questionsList1.ShuffleQuestions();
            chooseTheTopic.SetActive(false);
            questionsList1.StartTheQuestions();

            startTheTimer = true;

            return;
        }

        if (numberOfQuestionsInsertText.text == "")
        {
            SetTheTimer();

            questionsList1.howManyQuestions = 60;
            questionsList1.ShuffleQuestions();
            chooseTheTopic.SetActive(false);
            questionsList1.StartTheQuestions();

            startTheTimer = true;

            return;
        }

        int numberParsed = int.Parse(numberOfQuestionsInsertText.text);
        if (numberParsed <= 5)
        {
            SetTheTimer();

            questionsList1.howManyQuestions = 6;
            questionsList1.ShuffleQuestions();
            chooseTheTopic.SetActive(false);
            questionsList1.StartTheQuestions();

            startTheTimer = true;
        }

        if (numberParsed > 5 && numberParsed <= questionsLimitForExam)
        {
            SetTheTimer();

            questionsList1.howManyQuestions = numberParsed;
            questionsList1.ShuffleQuestions();
            chooseTheTopic.SetActive(false);
            questionsList1.StartTheQuestions();

            startTheTimer = true;
        }

        else if (numberParsed > questionsLimitForExam)
        {
            numberOfQuestionsColor.color = new Color32(255, 148, 148, 255);
        }        
    }

    void SetTheTimer()
    {
        if (questionsList1.isExam)
        {
            timeText.text = "105:00";
            timeOfTest = 105 * 60;
            begginingTime = 105 * 60;
            return;
        }

        if (timeInMinutesInsertText.text == "")
        {
            timeText.text = "105:00";
            timeOfTest = 105 * 60;
            begginingTime = 105 * 60;
            return;
        }

        int numberParsed = int.Parse(timeInMinutesInsertText.text);

        if (numberParsed <= 0)
        {
            timeText.text = "105:00";
            timeOfTest = numberParsed * 60;
            begginingTime = numberParsed * 60;
        }

        else if (numberParsed > 0)
        {
            timeText.text = numberParsed + ":00";
            timeOfTest = numberParsed * 60;
            begginingTime = numberParsed * 60;
        }
    }
}
