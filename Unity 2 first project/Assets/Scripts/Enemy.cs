using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Image healthBar;
    [SerializeField] bool isDead = false;

    public void TakeDamage(int damage)
    {
        if (isDead) return;

        health -= damage;

        healthBar.fillAmount = (float)health / maxHealth;

        Debug.Log("Enemy health: " + health);

        if (health <= 0)
        {
            isDead = true;
            GlobalKillCount.killCount++;
            Destroy(gameObject);
        }
    }
}
