using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClickTestScript : MonoBehaviour
{
    public string SceneToLoad;
    public Text TimerText;
    private int Clicks = 0;
    private float StartTime;
    private bool Finnished = false;
    public Button ButtonClick;
    private float Deadline = 15.00f;
    public GameObject[] CrackedGlass;
    public AudioSource BrokenGlassSound;
    public AudioSource BrokenGlassSound2;

    void Start()
    {
        StartTime = Time.time;
        foreach (var element in CrackedGlass)
        {
            element.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        float ActualTime = Time.time - StartTime;
        string Seconds = (ActualTime % 60).ToString("f2");
        TimerText.text = Seconds;
        if (ActualTime >= Deadline)
        {
            Finish();
            NextScene();
        }
        BrokenGlassEffect();

    }
    public void OnClick()
    {
        Clicks++;
        string ClicksToString = Clicks.ToString("f0");
        ButtonClick.GetComponentInChildren<Text>().text = ClicksToString;

    }
    public void Finish()
    {
        Finnished = true;
        TimerText.color = Color.red;
        PlayerPrefs.SetInt("LevelResult", Clicks);
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void BrokenGlassEffect()
    {
        int SwitchNumb = 0;
        switch (SwitchNumb)
        {
            case 30:
                ImageGlass[0].SetActive(true);
                break;
            case 40:
                ImageGlass[0].GetComponent<Animator>().Play("b1", -1, 0.0f);
                break;
            case 50:
                ImageGlass[1].SetActive(true);
                break;
            case 60:
                ImageGlass[1].SetActive(true); ImageGlass[1].GetComponent<Animator>().Play("b1", -1, 0.0f);
                glass1.Play();
                break;
            case 70:
                ImageGlass[2].SetActive(true);
                break;
            case 75:
                ImageGlass[2].GetComponent<Animator>().Play("b2", -1, 0.0f);
                glass1.Play();
                break;
            case 80:
                ImageGlass[3].SetActive(true);
                break;
            case 85:
                ImageGlass[3].GetComponent<Animator>().Play("b2", -1, 0.0f);
                glass1.Play();
                break;
            case 90:
                ImageGlass[4].SetActive(true);
                break;
            case 95:
                ImageGlass[4].GetComponent<Animator>().Play("b2", -1, 0.0f);
                glass1.Play();
                break;
            case 100:
                ImageGlass[5].SetActive(true);
                break;
            case 105:
                ImageGlass[5].GetComponent<Animator>().Play("b2", -1, 0.0f);
                glass1.Play();
                break;
            case 110:
                ImageGlass[6].SetActive(true);
                break;
            case 115:
                ImageGlass[6].GetComponent<Animator>().Play("b2", -1, 0.0f);
                break;
            case 130:
                ImageGlass[7].SetActive(true);
                galss2.Play();
                break;
        }      
    }
}
