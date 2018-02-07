using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public class ChangeBoards : MonoBehaviour {
    public DateTime target;
    private Int32 targetYear;
    private Int32 targetMonth;
    private Int32 targetDay;
    private Int32 targetMinutes;
    private Int32 targetHour;


    public Dropdown yearDropdown;
    public Dropdown monthDropdown;
    public Dropdown dayDropdown;
    public Dropdown hourDropdown;
    public Dropdown minuteDropdown;

    private string targetDateKey = "TargetDate";

	// Use this for initialization
	void Start () {
	    if (PlayerPrefs.HasKey(targetDateKey))
        {
            target = new DateTime(long.Parse(PlayerPrefs.GetString(targetDateKey)));
        }else
        {
            target = DateTime.Now;
        }
        SetTarget();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void TargetYearChanged(Int32 newYear)
    {
        if ((newYear+2017)!=targetYear)
        {
            targetYear = newYear + 2017;
            RebuiltTarget();
        }
    }

    public void TragetMonthChanged(Int32 newMonth)
    {
        if (newMonth != targetMonth)
        {
            targetMonth = newMonth;
            RebuiltTarget();
        }
    }

    public void TargetDayChanged(Int32 newDay)
    {
        if (newDay != targetDay)
        {
            switch (targetMonth)
            {
                case 0:
                case 2:
                case 4:
                case 6:
                case 7:
                case 9:
                case 11:
                    targetDay = newDay;
                    RebuiltTarget();
                    break;
                case 1:
                    if (newDay>28)
                    {
                        targetDay = 27;
                        dayDropdown.value = 27;
                        RebuiltTarget();       
                    }
                    break;
                case 3:
                case 5:
                case 8:
                case 10:
                    if (newDay > 30)
                    {
                        targetDay = 29;
                        dayDropdown.value = 29;
                        RebuiltTarget();
                    }
                    break;
            }

        }
    }

    public void TargetHourChanged(Int32 newHour)
    {
        if (newHour != targetHour)
        {
            targetHour = newHour;
            RebuiltTarget();
        }
    }

    public void TargetMinutesChanged(Int32 newMinutes)
    {
       if (newMinutes != targetMinutes)
        {
            targetMinutes = newMinutes;
            RebuiltTarget();
        }
    }

    void OnFixedUpdate()
    {

    }

    private void RebuiltTarget()
    {
        DateTime newTarget = new DateTime(targetYear, targetMonth+1, targetDay+1, targetHour, targetMinutes, 0, 0);
        target = newTarget;
        PlayerPrefs.SetString(targetDateKey, newTarget.Ticks.ToString());
    }

    private void SetTarget()
    {
        targetYear = target.Year;
        targetMonth = target.Month - 1;
        targetDay = target.Day - 1;
        targetHour = target.Hour;
        targetMinutes = target.Minute;

        yearDropdown.value = targetYear - 2017;
        monthDropdown.value = targetMonth;
        dayDropdown.value = targetDay;
        hourDropdown.value = targetHour;
        minuteDropdown.value = targetMinutes;
    }
}
