using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Valuta")]
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private int money = 0;

    [Header("Upgrade Torrette")]
    [SerializeField] private TurretUpgradeUI turretUpgradeUI;

    [Header("Schermate Fine Partita")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;

    private bool gameEnded = false;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        UpdateMoneyUI();
        RefreshUpgradeButtons();
    }

    public int Money => money;

    public void AddMoney(int amount)
    {
        money += amount;
        UpdateMoneyUI();
        RefreshUpgradeButtons();
    }

    public bool SpendMoney(int amount)
    {
        if (money < amount) return false;

        money -= amount;
        UpdateMoneyUI();
        RefreshUpgradeButtons();
        return true;
    }

    private void UpdateMoneyUI()
    {
        if (moneyText != null)
            moneyText.text = money.ToString();
    }

    private void RefreshUpgradeButtons()
    {
        if (turretUpgradeUI != null)
            turretUpgradeUI.RefreshButtons();
    }

    public void Win()
    {
        if (gameEnded) return;
        gameEnded = true;

        if (winPanel != null) winPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        if (gameEnded) return;
        gameEnded = true;

        if (gameOverPanel != null) gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
