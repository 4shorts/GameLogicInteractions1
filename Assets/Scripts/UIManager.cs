using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _AICountText;
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private Text _winnerText;
    [SerializeField]
    private Text _playAgainText;
    [SerializeField]
    private Text _loserText;
    [SerializeField]
    private Text _tryAgainText;
    private bool _playing;
    private float _timer;
    [SerializeField]
    private GameObject _WinnerParticles;
    
    

    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is NULL");
            }
            return _instance;
        }
    }

    public void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _WinnerParticles.SetActive(false);
        _scoreText.text = "Score: 0";
        _AICountText.text = ": 20";
        _timerText.text = "00:00:00";
        _winnerText.gameObject.SetActive(false);
        _playAgainText.gameObject.SetActive(false);
        _loserText.gameObject.SetActive(false);
        _tryAgainText.gameObject.SetActive(false);
        _playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( _playing == true)
        {
            _timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(_timer / 60f);
            int seconds = Mathf.FloorToInt(_timer % 60f);
            int milliseconds = Mathf.FloorToInt((_timer * 100f) % 100f);
            _timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00") + ":" + milliseconds.ToString("00");
        }
    }

    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Score: " + playerScore;
    }

    public void UpdateAICount(int AICount)
    {
        _AICountText.text = ": " + AICount;
    }

    public void WinConditionSequence()
    {
        GameManager.Instance.GameOver();
        _winnerText.gameObject.SetActive(true);
        _playAgainText.gameObject.SetActive(true);
        _WinnerParticles.SetActive(true);
    }

    public void LoseConditonSequence()
    {
        GameManager.Instance.GameOver();
        _loserText.gameObject.SetActive(true);
        _tryAgainText.gameObject.SetActive(true);
    }

}
