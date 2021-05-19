using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetContentSize : MonoBehaviour
{
    public bool questionContent;
    public bool choiceQuestionsContent;
    public bool anwserContent;

    public RectTransform content;
    public RectTransform thisRect;


    // For Questions only.
    public RectTransform borderSize;
    public RectTransform redTransform;
    public RectTransform yellowTransform;
    public RectTransform greenTransform;

    void Start()
    {
        if (anwserContent)
        {
            Invoke("ChangeContentSizeForAnswers", 0.05f);
        }        

        if (questionContent)
        {
            Invoke("ChangeContentSizeForQuestions", 0.05f);
        }

        if (choiceQuestionsContent)
        {
            Invoke("ChangeContentSizeForChoiceQuestions", 0.05f);
        }
    }

    void ChangeContentSizeForAnswers()
    {
        content.sizeDelta = new Vector2(0, thisRect.sizeDelta.y + 220);
    }

    void ChangeContentSizeForChoiceQuestions()
    {
        borderSize.sizeDelta = new Vector2(borderSize.sizeDelta.x, thisRect.sizeDelta.y + 50);

        if (redTransform != null)
        {
            redTransform.sizeDelta = new Vector2(redTransform.sizeDelta.x, thisRect.sizeDelta.y + 50);
        }

        if (yellowTransform != null)
        {
            yellowTransform.sizeDelta = new Vector2(yellowTransform.sizeDelta.x, thisRect.sizeDelta.y + 50);
        }

        if (greenTransform != null)
        {
            greenTransform.sizeDelta = new Vector2(greenTransform.sizeDelta.x, thisRect.sizeDelta.y + 50);
        }
    }

    void ChangeContentSizeForQuestions()
    {
        content.sizeDelta = new Vector2(content.sizeDelta.x, thisRect.sizeDelta.y + 220);
    }
}
