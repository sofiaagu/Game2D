using System.IO;
using TMPro;
using UnityEngine;

public class FinalPanelController : MonoBehaviour
{
    [Header("Referencias a los textos del panel")]
    public TMP_Text finalApple;
    public TMP_Text finalBanana;
    public TMP_Text finalTotal;
    public TMP_Text finalTime;

    void Start()
    {
        // Aseguramos que el panel arranque desactivado
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Activa el panel y actualiza los textos con la info del GameManager.
    /// </summary>
    public void ShowFinalPanel()
    {
        gameObject.SetActive(true);

        if (finalApple != null)
            finalApple.text = GameManager.Instance.scoreApple.ToString();
        if (finalBanana != null)
            finalBanana.text = GameManager.Instance.scoreBanana.ToString();
        if (finalTotal != null)
            finalTotal.text = (GameManager.Instance.scoreApple + GameManager.Instance.scoreBanana).ToString();
        if (finalTime != null)
            finalTime.text = Timer.FormatTime(GameManager.Instance.GlobalTime);

        // Pausar el juego
        Time.timeScale = 0f;
    }
    public void GuardarJson()
    {
        FinalStats stats = new FinalStats
        {
            apples = GameManager.Instance.scoreApple,
            bananas = GameManager.Instance.scoreBanana,
            total = GameManager.Instance.scoreApple + GameManager.Instance.scoreBanana,
            time = Timer.FormatTime(GameManager.Instance.GlobalTime)
        };

        string json = JsonUtility.ToJson(stats, true);

        // Ruta en StreamingAssets
        string folderPath = Path.Combine(Application.dataPath, "StreamingAssets");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath); // Crear la carpeta si no existe
        }

        string path = Path.Combine(folderPath, "finalStats.json");
        File.WriteAllText(path, json);

        Debug.Log("Datos guardados en: " + path);
    }
}

[System.Serializable]
public class FinalStats
{
    public int apples;
    public int bananas;
    public int total;
    public string time;
}

