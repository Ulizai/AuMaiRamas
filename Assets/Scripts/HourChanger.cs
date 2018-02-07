using UnityEngine;
using System;
using System.Collections;

public class HourChanger : NumberChanger {

    public override void StartRollout()
    {
        int delta = (int)(controller.target - DateTime.Now).Hours;
        if (delta != current)
        {
            number0TopFront.SetActive(true);
            number1TopFront.SetActive(true);
            StartCoroutine(RollDownNumbers(delta));
        }
        current = delta;
    }
}
