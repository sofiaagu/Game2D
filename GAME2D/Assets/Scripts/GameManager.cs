    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TMP_Text appleText;
    public TMP_Text bananaText;

    public static GameManager Instance;

    private float globalTime;
    private int scoreApple;
    private int scoreBanana;



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
        appleText = GameObject.Find("AppleText")?.GetComponent<TextMeshProUGUI>();
        bananaText = GameObject.Find("BananaText")?.GetComponent<TextMeshProUGUI>();

        UpdateScoreUI();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        globalTime = 0;
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {

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
