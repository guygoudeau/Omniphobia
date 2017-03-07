using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(fileName = "FearList", menuName = "Fear/Fear List", order = 1)]
public class ScriptableFearList : ScriptableObject
{
    public List<ScriptableFear> ScriptableFears;
    
    public void Create(List<Fear> fears)
    {
        ScriptableFears = new List<ScriptableFear>();
        
        foreach(var f in fears)
        {
            ScriptableFear sf = CreateInstance<ScriptableFear>();
            sf.Create(f);
            ScriptableFears.Add(sf);
        }
        
        
    }
}
