using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ClickingLevel1Sc : MonoBehaviour
{

    public GameObject[] Buttons;
    public string SceneToLoad;
    public Text TimerText;
    private int ControllInt = 5;
    private float StartTime;
    private bool Finnished = false;
    private int ButtonNumer;

    void Start()
    {
        StartTime = Time.time;
        int RandomXValue = Random.Range(-201, 201);
        int RandomYValue = Random.Range(0, 101);
        Buttons[0].transform.localPosition = new Vector2(-250 + RandomXValue, 520 - RandomYValue);// Setting a little random position for GameObject.
        Buttons[1].transform.localPosition = new Vector2(216 - RandomXValue, -640);
        Buttons[2].transform.localPosition = new Vector2(-310, 0 + RandomXValue);
        Buttons[3].transform.localPosition = new Vector2(332, -100 - RandomYValue);
        Buttons[4].transform.localPosition = new Vector2(0, 0);

    }
    IEnumerator DestroyCouroutine()
    {
        yield return new WaitForSeconds(0.05f);//Waiting for playing BrokenButton animation only 0.05f sec
        if (ButtonNumer == 1)
        {
            Destroy(Buttons[ButtonNumer - 1]);
        }
        else if (ButtonNumer == 2) { Destroy(Buttons[ButtonNumer - 1]); }
        else if (ButtonNumer == 3) { Destroy(Buttons[ButtonNumer - 1]); }
        else if (ButtonNumer == 4) { Destroy(Buttons[ButtonNumer - 1]); }
        else if (ButtonNumer == 5) { Destroy(Buttons[ButtonNumer - 1]); }

    }

    void Update()
    {
        if (Finnished)
            return;
        float t = Time.time - StartTime;
        string seconds = (t % 60).ToString("f2");
        TimerText.text = seconds;
        PlayerPrefs.SetFloat("Level1Result", t);//Saving Level result after all buttons clicked.
        if (ControllInt == 0)
        {
            Finish();
            NextScene();
        }
    }
    public void Click()
    {
        Buttons[0].GetComponent<Image>().sprite = Resources.Load<Sprite>("BrokenButton");
        ControllInt--;
        ButtonNumer = 1;
        StartCoroutine("DestroyCouroutine");

    }
    public void Click2()
    {
        Buttons[1].GetComponent<Image>().sprite = Resources.Load<Sprite>("BrokenButton");
        ControllInt--;
        ButtonNumer = 2;
        StartCoroutine("DestroyCouroutine");
    }
    public void Click3()
    {
        Buttons[2].GetComponent<Image>().sprite = Resources.Load<Sprite>("BrokenButton");
        ControllInt--;
        ButtonNumer = 3;
        StartCoroutine("DestroyCouroutine");
    }
    public void Click4()
    {
        Buttons[3].GetComponent<Image>().sprite = Resources.Load<Sprite>("BrokenButton");
        ControllInt--;
        ButtonNumer = 4;
        StartCoroutine("DestroyCouroutine");
    }
    public void Click5()
    {
        Buttons[4].GetComponent<Image>().sprite = Resources.Load<Sprite>("BrokenButton");
        ControllInt--;
        ButtonNumer = 5;
        StartCoroutine("DestroyCouroutine");
    }
    public void Finish()
    {
        Finnished = true;
        TimerText.color = Color.red;
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}

