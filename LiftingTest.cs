using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LiftingTest : MonoBehaviour
{

    public Text TimerText;
    private float StartTime;
    private bool Finnished = false;
    public int LiftingResult = 0;
    public Text TextLiftResult;
    public string SceneToLoad;
    public float DeadLineTime = 15.00f;
    private float ActualTime;
    private string TimeSec;

    void Start()
    {
        StartTime = Time.time;
    }


    void Update()
    {
        ActualTime = Time.time - StartTime;
        TimeSec = (ActualTime % 60).ToString("f2");
        TimerText.text = TimeSec;
        if (ActualTime >= DeadLineTime)
        {
            Finish();
            NextScene();
        }
    }
    private void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.name == "weight")
        {
            LiftingResult++;
            string lift = LiftingResult.ToString("f0");
            TextLiftResult.text = lift;
        }
    }
    public void Finish()
    {
        Finnished = true;
        TimerText.color = Color.red;
        PlayerPrefs.SetInt("LiftingResult", LiftingResult);
    }
    void NextScene()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
