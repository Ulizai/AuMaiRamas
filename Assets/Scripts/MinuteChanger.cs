using UnityEngine;
using System;
public class MinuteChanger : NumberChanger {

    public override void StartRollout()
    {
        int delta = (int)(controller.target - DateTime.Now).Minutes;
        if (delta != current)
        {
            number0TopFront.SetActive(true);
            number1TopFront.SetActive(true);
            StartCoroutine(RollDownNumbers(delta));
        }
        current = delta;
    }
}
