using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName ="Date and Time", menuName ="Scriptables/Dates and Times", order =1)]
public class DateTime : ScriptableObject
{
    public int DayCount;
    public string Day;
    public string Time;
    public List<string> WeekDays;
}
