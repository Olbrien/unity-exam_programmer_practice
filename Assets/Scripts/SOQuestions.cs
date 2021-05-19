using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Questions", menuName = "Add Question")]
public class SOQuestions : ScriptableObject
{
    [TextArea(5,15)]
    public string question;
    [TextArea(5, 15)]
    public string wrongAnswer1;
    [TextArea(5, 15)]
    public string wrongAnswer2;
    [TextArea(5, 15)]
    public string wrongAnswer3;
    [TextArea(5, 15)]
    public string correctAnswer;
    [TextArea(5, 15)]
    public string showAnswer;
}
