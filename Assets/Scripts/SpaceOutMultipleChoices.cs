using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceOutMultipleChoices : MonoBehaviour
{
    public Questions questions;

    public RectTransform content;
    public RectTransform wrongAnswerOne;
    public RectTransform wrongAnswerTwo;
    public RectTransform wrongAnswerThree;
    public RectTransform correctAnswerOne;


    void Start()
    {
        Invoke("SpaceMultipleChoices", 0.08f);
    }

    void SpaceMultipleChoices()
    {
        questions.RandomizeAnswers();


        if (questions.randomNumber == 0)
        {
            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                           wrongAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                                       wrongAnswerTwo.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerThree.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);


            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                               correctAnswerOne.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);
        }

        else if (questions.randomNumber == 1)
        {
            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                               correctAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                                       wrongAnswerThree.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerTwo.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);


            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerOne.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);
        }

        else if (questions.randomNumber == 2)
        {
            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                                       wrongAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);


            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                                       correctAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerThree.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerTwo.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);
        }

        else if (questions.randomNumber == 3)
        {
            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                           correctAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                                       wrongAnswerThree.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerTwo.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);


            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerOne.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);
        }

        if (questions.randomNumber == 4)
        {
            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                           wrongAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);


            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                                       correctAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerThree.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerTwo.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);
        }

        if (questions.randomNumber == 5)
        {
            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                           wrongAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                                       wrongAnswerTwo.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);


            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                               correctAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerThree.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);
        }


        if (questions.randomNumber == 6)
        {
            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                           wrongAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);


            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                                       correctAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerThree.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerTwo.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);
        }

        if (questions.randomNumber == 7)
        {
            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                           wrongAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                                       wrongAnswerTwo.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);


            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                               correctAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerThree.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);
        }

        else if (questions.randomNumber == 8)
        {
            wrongAnswerOne.localPosition = new Vector3(wrongAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                           wrongAnswerOne.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerOne.sizeDelta.y + 70);


            wrongAnswerTwo.localPosition = new Vector3(wrongAnswerTwo.localPosition.x, -content.sizeDelta.y + 80,
                                                       wrongAnswerTwo.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerTwo.sizeDelta.y + 70);


            wrongAnswerThree.localPosition = new Vector3(wrongAnswerThree.localPosition.x, -content.sizeDelta.y + 80,
                                               wrongAnswerThree.localPosition.z);


            content.sizeDelta = new Vector2(0, content.sizeDelta.y + wrongAnswerThree.sizeDelta.y + 70);


            correctAnswerOne.localPosition = new Vector3(correctAnswerOne.localPosition.x, -content.sizeDelta.y + 80,
                                               correctAnswerOne.localPosition.z);

            content.sizeDelta = new Vector2(0, content.sizeDelta.y + correctAnswerOne.sizeDelta.y + 70);
        }
    }

}
