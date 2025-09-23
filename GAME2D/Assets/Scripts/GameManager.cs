    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text appleText;
    public TMP_Text bananaText;

    public static GameManager Instance;

    private float globalTime;
    public int scoreApple;
    public int scoreBanana;

    private AudioSource audioSource;
    public AudioClip musicClip;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameOver")
        {
            // Buscar los textos específicos de la escena final
            TMP_Text finalApple = GameObject.Find("FinalAppleText")?.GetComponent<TextMeshProUGUI>();
            TMP_Text finalBanana = GameObject.Find("FinalBananaText")?.GetComponent<TextMeshProUGUI>();
            TMP_Text finalTotal = GameObject.Find("FinalTotalText")?.GetComponent<TextMeshProUGUI>();
            TMP_Text finalTime = GameObject.Find("FinalTimeText")?.GetComponent<TextMeshProUGUI>();

            if (finalApple != null) finalApple.text = scoreApple.ToString();
            if (finalBanana != null) finalBanana.text = scoreBanana.ToString();
            if (finalTotal != null) finalTotal.text = (scoreApple + scoreBanana).ToString();
            if (finalTime != null)
            {
                finalTime.text = Timer.FormatTime(GlobalTime);
            }

            Time.timeScale = 0f; // congelar el juego en la escena final
        }
        else
        {
            // Escenas normales → HUD
            appleText = GameObject.Find("AppleText")?.GetComponent<TextMeshProUGUI>();
            bananaText = GameObject.Find("BananaText")?.GetComponent<TextMeshProUGUI>();
            UpdateScoreUI();
        }
    }

    void Start()
    {
        globalTime = 0;
        UpdateScoreUI();
    }


    public void TotalTime(float timeScene)
    {
        globalTime += timeScene;
    }

    public void TotalApple(int Apple)
    {
        scoreApple += Apple;
        UpdateScoreUI();
    }

    public void TotalBanana(int Banana)
    {
        scoreBanana += Banana;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (appleText != null)
        {
            appleText.text = scoreApple.ToString();
        }

        if (bananaText != null)
        {
            bananaText.text = scoreBanana.ToString();
        }
    }

    public float GlobalTime { get => globalTime; set => globalTime = value; }

}
