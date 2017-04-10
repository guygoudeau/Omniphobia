using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Fear", menuName = "Fear/Fear", order = 1)]
public class ScriptableFear : ScriptableObject
{
    string FearName;
    bool CompletedStatus;
    public ScriptableFear Create(Fear f)
    {
        FearName = f.name;
        CompletedStatus = f.isCompleted;
        return this;
    }
}
