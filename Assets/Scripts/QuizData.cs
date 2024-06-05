using UnityEngine;

[CreateAssetMenu(fileName = "QuizData", menuName = "Quiz/QuizData")]
public class QuizData : ScriptableObject
{
    public Question[] questions;
}
