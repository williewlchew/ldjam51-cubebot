using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMain : MonoBehaviour
{
    public delegate void ChangeDimension();
    public static event ChangeDimension DimensionOne;
    public static event ChangeDimension DimensionTwo;
    public static event ChangeDimension DimensionThree;
    public float SlowFactor;
    public int MaxHourGlasses;
    private int TimeRemaining;
    private int HourGlassRemaining;
    public GameObject player;
    public GameObject playButton;
    public GameObject gameOver;
    public Text UITimer;
    public GameObject UIDim1;
    public GameObject UIDim2;
    public GameObject UIDim3;
    public Text UIGlassesLeft;
    private int CurrentDimension;

    void OnEnable()
    {
        DimensionOne += DimensionSwitch;
        DimensionTwo += DimensionSwitch;
        DimensionThree += DimensionSwitch;
    }
    void OnDisable()
    {
        DimensionOne -= DimensionSwitch;
        DimensionTwo -= DimensionSwitch;
        DimensionThree -= DimensionSwitch;
    }
    public void Play()
    {
        TimeRemaining = 10;
        CurrentDimension = 1;
        DimensionOne();
        HourGlassRemaining = MaxHourGlasses;
        InvokeRepeating("TimerCountdown", 0f, 1f);
        UIGlassesLeft.text = HourGlassRemaining.ToString() + "X";
        playButton.SetActive(false);
        UIDim1.SetActive(true);
    }

    private void TimerCountdown()
    {
        if (TimeRemaining > 0) {
            TimeRemaining--;
        };
        UITimer.text = TimeRemaining.ToString();
        if (TimeRemaining == 0 && CurrentDimension == 3 && HourGlassRemaining == 0) {
            gameOver.SetActive(true);
            CancelInvoke("TimerCountdown");
        } else if (TimeRemaining == 0) {
            CurrentDimension++;
            if (CurrentDimension > 3) {
                CurrentDimension = 1;
                DimensionOne();
            } else if (CurrentDimension == 2) {
                DimensionTwo();
            } else if (CurrentDimension == 3) {
                DimensionThree();
            }
            TimeRemaining = 10;
        }
    }

    private void DimensionSwitch()
    {
        HourGlassRemaining--;
        UIGlassesLeft.text = HourGlassRemaining.ToString() + "X";
        if (CurrentDimension == 1) {
            UIDim1.SetActive(true);
            UIDim2.SetActive(false);
            UIDim3.SetActive(false);
        } else if (CurrentDimension == 2) {
            UIDim1.SetActive(false);
            UIDim2.SetActive(true);
            UIDim3.SetActive(false);
        } else {
            UIDim1.SetActive(false);
            UIDim2.SetActive(false);
            UIDim3.SetActive(true);
        }
    }
    public void Pause()
    {
        // player.enabled = false;
        UIDim1.SetActive(false);
        UIDim2.SetActive(false);
        UIDim3.SetActive(false);
        playButton.SetActive(true);
        gameOver.SetActive(false);
    }

    private void Awake()
    {
        Pause();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
