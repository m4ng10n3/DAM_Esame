using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [Header("Settings")]
    public float speed = 3f;
    public int maxHp = 3;
    private int currentHp;

    [Header("Reward")]
    public int coinReward = 5;

    [Header("Components")]
    public SpriteRenderer spriteRenderer;

    private void Start()
    {
        currentHp = maxHp;
    }

    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            Invoke(nameof(ResetColor), 0.1f);
        }

        if (currentHp <= 0)
            Die();
    }

    private void ResetColor()
    {
        if (spriteRenderer != null)
            spriteRenderer.color = Color.white;
    }

    private void Die()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.AddMoney(coinReward);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("GameOverZone"))
        {
            if (GameManager.Instance != null)
                GameManager.Instance.GameOver();
        }
    }
}
