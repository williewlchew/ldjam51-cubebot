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
    public GameObject UIKey0;
    public GameObject UIKey1;
    public GameObject UIKey2;
    public GameObject UIKey3;
    public Text UIGlassesLeft;
    private int CurrentDimension;
    private bool SlowFlag;
    private int KeysAcquired;

    void OnEnable()
    {
        SlowFactor = 2f;
        DimensionOne += DimensionSwitch;
        DimensionTwo += DimensionSwitch;
        DimensionThree += DimensionSwitch;
        PlayerController.SlowTime += AbilitySlowTime;
        PlayerController.SkipDimension += AbilitySkipDimension;
    }
    void OnDisable()
    {
        DimensionOne -= DimensionSwitch;
        DimensionTwo -= DimensionSwitch;
        DimensionTwo -= AbilitySlowTime;
        DimensionThree -= DimensionSwitch;
        DimensionThree -= AbilitySlowTime;
    }
    public void Play()
    {
        KeysAcquired = 0;
        SlowFlag = false;
        TimeRemaining = 10;
        CurrentDimension = 1;
        HourGlassRemaining = MaxHourGlasses;
        UIGlassesLeft.text = HourGlassRemaining.ToString() + "X";
        HourGlassRemaining++;
        DimensionOne();
        playButton.SetActive(false);
        UIDim1.SetActive(true);
    }

    IEnumerator TimerCountdown()
    {
        while(true) {
            if (TimeRemaining < 0) {
                UITimer.text = (0).ToString();
            } else {
                UITimer.text = TimeRemaining.ToString();
            }
            if (SlowFlag) {
                yield return new WaitForSeconds(1f * SlowFactor);
            } else {
                yield return new WaitForSeconds(1f);
            }
            TimeRemaining--;
            if (TimeRemaining < 0 && HourGlassRemaining <= 0) {
                gameOver.SetActive(true);
                StopCoroutine("TimerCountdown");
            } else if (TimeRemaining < 0) {
                TimeRemaining = 10;
                CurrentDimension++;
                if (CurrentDimension > 3) {
                    CurrentDimension = 1;
                    DimensionOne();
                } else if (CurrentDimension == 2) {
                    DimensionTwo();
                } else if (CurrentDimension == 3) {
                    DimensionThree();
                }
            }
        }
    }

    private void DimensionSwitch()
    {
        HourGlassRemaining--;
        if (HourGlassRemaining < 0) {
            gameOver.SetActive(true);
            StopCoroutine("TimerCountdown");
        } else {
            TimeRemaining = 10;
            StopCoroutine("TimerCountdown");
            StartCoroutine("TimerCountdown");
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
    }

    private void AbilitySlowTime()
    {
        if (SlowFlag) {
            SlowFlag = false;
        } else {
            SlowFlag = true;
        }
    }

    private void AbilitySkipDimension()
    {
        CurrentDimension++;
        if (CurrentDimension > 3) {
            CurrentDimension = 1;
        }
        DimensionSwitch();
        SlowFlag = false;
    }

    private void KeyAcquired()
    {
        KeysAcquired++;
        if (KeysAcquired == 1) {
            UIKey0.SetActive(false);
            UIKey1.SetActive(true);
            UIKey2.SetActive(false);
            UIKey3.SetActive(false);
        } else if (KeysAcquired == 2) {
            UIKey0.SetActive(false);
            UIKey1.SetActive(false);
            UIKey2.SetActive(true);
            UIKey3.SetActive(false);
        } else {
            UIKey0.SetActive(false);
            UIKey1.SetActive(false);
            UIKey2.SetActive(false);
            UIKey3.SetActive(true);
        }
    }

    public void Pause()
    {
        // UIDim1.SetActive(false);
        // UIDim2.SetActive(false);
        // UIDim3.SetActive(false);
        UIKey0.SetActive(true);
        UIKey1.SetActive(false);
        UIKey2.SetActive(false);
        UIKey3.SetActive(false);
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
        // if (Input.GetMouseButtonDown(1)) {
        //     Debug.Log("CLICK");
        //     AbilitySkipDimension();
        // }
        // if (Input.GetMouseButtonDown(2)) {
        //     Debug.Log("CLICK");
        //     KeyAcquired();
        // }
        // if (Input.GetMouseButtonDown(3)) {
        //     Debug.Log("CLICK");
        //     AbilitySlowTime();
        // }
    }
}