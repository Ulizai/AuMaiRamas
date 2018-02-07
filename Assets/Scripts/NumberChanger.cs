using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

public abstract class NumberChanger : MonoBehaviour {
    protected ChangeBoards controller;
    protected NumberCollection numbers;

    public GameObject number0TopFront;
    public GameObject number0TopBack;
    public GameObject number0Top;
    public GameObject number0Bottom;

    public GameObject number1TopFront;
    public GameObject number1TopBack;
    public GameObject number1Top;
    public GameObject number1Bottom;

    protected int current;
    protected int iterration = -2;
    protected int totalRotation = 0;
    // Use this for initialization
    void Start ()
    {
        number0TopFront.SetActive(false);
        number1TopFront.SetActive(false);
        number0TopBack.SetActive(false);
        number1TopBack.SetActive(false);
        controller = GameObject.FindObjectOfType<ChangeBoards>();
        numbers = GameObject.FindObjectOfType<NumberCollection>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        StartRollout();
	}

    public abstract void StartRollout();

    protected IEnumerator RollDownNumbers(int targetNumber)
    {
        int currentNumber1 = current / 10;
        int targetNumber1 = targetNumber / 10;

        int currentNumber2 = current % 10;
        int targetNumber2 = targetNumber % 10;

        number0Top.GetComponent<Image>().sprite = numbers.numbersTop[targetNumber1];
        number1Top.GetComponent<Image>().sprite = numbers.numbersTop[targetNumber2];

        number0TopFront.GetComponent<Image>().sprite = numbers.numbersTop[currentNumber1];
        number0TopBack.GetComponent<Image>().sprite = numbers.numbersBottom[targetNumber1];

        number1TopFront.GetComponent<Image>().sprite = numbers.numbersTop[currentNumber2];
        number1TopBack.GetComponent<Image>().sprite = numbers.numbersBottom[targetNumber2];

        totalRotation = iterration;

        if (currentNumber1 == targetNumber1)
        {
            number0TopFront.SetActive(false);
            number0TopBack.SetActive(false);
        }

        while ((totalRotation%180)!=0)
        {
            totalRotation += iterration;
            if (currentNumber1!= targetNumber1)
            {
                number0TopFront.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(totalRotation, 0, 0));
                number0TopBack.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(totalRotation, 0, 0));
            }else
            {
                number0TopFront.SetActive(false);
                number0TopBack.SetActive(false);
            }

            number1TopFront.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(totalRotation, 0, 0));
            number1TopBack.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(totalRotation, 0, 0));

            if (totalRotation < -90)
            {
                if (currentNumber1 != targetNumber1)
                {
                    number0TopFront.SetActive(false);
                    number0TopBack.SetActive(true);
                }

                number1TopFront.SetActive(false);
                number1TopBack.SetActive(true);
            }

            yield return 0;
        }

        number0Bottom.GetComponent<Image>().sprite = numbers.numbersBottom[targetNumber1];
        number1Bottom.GetComponent<Image>().sprite = numbers.numbersBottom[targetNumber2];
        number0TopFront.SetActive(false);
        number1TopFront.SetActive(false);
        number0TopBack.SetActive(false);
        number1TopBack.SetActive(false);
        number0TopFront.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        number0TopBack.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        number1TopFront.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        number1TopBack.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
