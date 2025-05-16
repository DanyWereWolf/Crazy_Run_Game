using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PauseButton;
    public GameObject PausePannel;
    public GameObject LosePannel;
    public Text timerText;
    public float timeRemaining = 60f;

    private EventInstance musicEventOnClick;

    public void Start()
    {
        musicEventOnClick = RuntimeManager.CreateInstance("event:/Click");
        Vector3 position = transform.position;
        musicEventOnClick.set3DAttributes(RuntimeUtils.To3DAttributes(position));
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            LosePannel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void UpdateTimerText()
    {
        timerText.text = Mathf.Ceil(timeRemaining).ToString();
    }

    public void Pause()
    {
        PauseButton.SetActive(false);
        PausePannel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void repeatGame()
    {
        PausePannel.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1f;
    }
    public void OnClick()
    {
        musicEventOnClick.start();
    }
}
