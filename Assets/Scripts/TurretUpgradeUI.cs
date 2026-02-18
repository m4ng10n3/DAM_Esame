using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TurretUpgradeUI : MonoBehaviour
{
    [System.Serializable]
    public class TurretSlot
    {
        public Cannon cannon;
        public Button button;
        public TextMeshProUGUI priceText;

        [HideInInspector] public int level = 0;
    }

    [Header("Torrette")]
    public TurretSlot[] turrets = new TurretSlot[4];

    private const int MAX_LEVEL = 4;
    private static readonly int[] COSTS = { 20, 34, 58, 98 };

    private void Start()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            int index = i;
            if (turrets[i].button != null)
                turrets[i].button.onClick.AddListener(() => TryUpgrade(index));
        }

        RefreshButtons();
    }

    public void RefreshButtons()
    {
        for (int i = 0; i < turrets.Length; i++)
        {
            var t = turrets[i];

            if (t.button == null || t.priceText == null)
                continue;

            if (t.level >= MAX_LEVEL)
            {
                t.priceText.text = "MAX";
                t.button.interactable = false;
                continue;
            }

            int cost = COSTS[t.level];
            t.priceText.text = cost.ToString();

            bool canAfford = GameManager.Instance != null && GameManager.Instance.Money >= cost;
            t.button.interactable = canAfford;
        }
    }

    private void TryUpgrade(int index)
    {
        if (index < 0 || index >= turrets.Length) return;

        var t = turrets[index];

        if (t.cannon == null || t.button == null || t.priceText == null) return;
        if (t.level >= MAX_LEVEL) return;

        int cost = COSTS[t.level];

        if (GameManager.Instance == null) return;
        if (!GameManager.Instance.SpendMoney(cost)) return;

        t.level++;

        t.cannon.DecreaseFireIntervalBy1();

        RefreshButtons();

        if (AllMaxed())
            GameManager.Instance.Win();
    }

    private bool AllMaxed()
    {
        for (int i = 0; i < turrets.Length; i++)
            if (turrets[i].level < MAX_LEVEL)
                return false;

        return true;
    }
}
