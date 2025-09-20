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

       
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = musicClip;   
        audioSource.loop = true;       
        audioSource.playOnAwake = true; 
        audioSource.volume = 0.5f;      
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        appleText = GameObject.Find("AppleText")?.GetComponent<TextMeshProUGUI>();
        bananaText = GameObject.Find("BananaText")?.GetComponent<TextMeshProUGUI>();

        UpdateScoreUI();
    }

    void Start()
    {
        globalTime = 0;
        UpdateScoreUI();
      
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

   
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
