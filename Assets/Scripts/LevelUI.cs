using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public GameObject clock;
    private ClockUI clockUI;
    // Start is called before the first frame update
    void Start()
    {
        clockUI = clock.GetComponent<ClockUI>();
    }

    public void startGame()
    {
        clock.SetActive(true);
        clockUI.runGame();
    }
}
