using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Fear", menuName = "Fear/Fear", order = 1)]
public class ScriptableFear : ScriptableObject
{
    string FearName;
    int value;
    public ScriptableFear Create(Fear f)
    {
        FearName = f.name;
        value = f.value;
        return this;
    }
}
