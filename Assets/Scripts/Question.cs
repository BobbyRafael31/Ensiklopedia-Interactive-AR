using UnityEngine;

[CreateAssetMenu(fileName = "Question", menuName = "Quiz/Question")]
public class Question : ScriptableObject
{
    public string question;
    public bool isTrue;
}
