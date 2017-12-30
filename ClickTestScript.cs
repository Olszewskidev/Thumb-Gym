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
        if (Clicks == 30)
        {
            CrackedGlass[0].SetActive(true);
        }
        else if (Clicks == 40)
        {
            CrackedGlass[0].GetComponent<Animator>().Play("b1", -1, 0.0f);
        }
        else if (Clicks == 50)
        {
            CrackedGlass[1].SetActive(true);
        }
        else if (Clicks == 60)
        {
            CrackedGlass[1].GetComponent<Animator>().Play("b1", -1, 0.0f);
            BrokenGlassSound.Play();
        }
        else if (Clicks == 70)
        {
            CrackedGlass[2].SetActive(true);
        }
        else if (Clicks == 75)
        {
            CrackedGlass[2].GetComponent<Animator>().Play("b2", -1, 0.0f);
            BrokenGlassSound.Play();
        }
        else if (Clicks == 80)
        {
            CrackedGlass[3].SetActive(true);
        }
        else if (Clicks == 85)
        {
            CrackedGlass[3].GetComponent<Animator>().Play("b2", -1, 0.0f);
            BrokenGlassSound.Play();
        }
        else if (Clicks == 90)
        {
            CrackedGlass[4].SetActive(true);
        }
        else if (Clicks == 95)
        {
            CrackedGlass[4].GetComponent<Animator>().Play("b2", -1, 0.0f);
            BrokenGlassSound.Play();
        }
        else if (Clicks == 100)
        {
            CrackedGlass[5].SetActive(true);
        }
        else if (Clicks == 105)
        {
            CrackedGlass[5].GetComponent<Animator>().Play("b2", -1, 0.0f);
            BrokenGlassSound.Play();
        }
        else if (Clicks == 110)
        {
            CrackedGlass[6].SetActive(true);
        }
        else if (Clicks == 115)
        {
            CrackedGlass[7].GetComponent<Animator>().Play("b2", -1, 0.0f);
        }
        else if (Clicks == 130)
        {
            CrackedGlass[7].SetActive(true);
            BrokenGlassSound2.Play();
        }
    }
}
