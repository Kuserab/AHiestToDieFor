using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockUI : MonoBehaviour
{
    //controls each hand individually
    private Transform clockHourHandTransform;
    private Transform clockMinuteHandTransform;

    //this variable will keep track of in game time
    //use to scale guard flashlights over time
    public float day;

    //This will determine how long it takes to do a full clock rotation (12 to 12) in seconds
    public const float REAL_SECONDS_PER_INGAME_DAY = 360f;

    public float inGameTime;
    public bool gameIsRunning = false;
    //TODO: BUTTON THAT STORES TIME.TIME
    private void Awake()
    {
        gameIsRunning = false;
        clockHourHandTransform = transform.Find("Hour Hand");
        clockMinuteHandTransform = transform.Find("Minute Hand");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameIsRunning)
        {
            day += Time.deltaTime / REAL_SECONDS_PER_INGAME_DAY;

            float dayNormalized = day % 1f;

            float rotationDegreeesPerDay = 360f;
            clockHourHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreeesPerDay * 2f);

            float hoursPerDay = 12f;
            clockMinuteHandTransform.eulerAngles = new Vector3(0, 0, -dayNormalized * rotationDegreeesPerDay * hoursPerDay * 2f);
        }

    }

    public void runGame()
    {
        gameIsRunning = true;
    }
}
