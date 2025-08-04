using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    // Health UI
    [SerializeField]
    public Sprite[] heartSprites;
    [SerializeField]
    public Image heartImage;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
    }

    void Update()
    {
        UpdateHealth();
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " dead");
        Destroy(gameObject);
        SceneManager.LoadSceneAsync("Menu");
    }

    void UpdateHealth()
    {
        float healthPercent = Mathf.Clamp01((float)currentHealth / maxHealth);
        int spriteIndex = Mathf.RoundToInt(healthPercent * (heartSprites.Length - 1));
        spriteIndex = Mathf.Clamp(spriteIndex, 0, heartSprites.Length - 1);

        heartImage.sprite = heartSprites[spriteIndex];
    }
}
