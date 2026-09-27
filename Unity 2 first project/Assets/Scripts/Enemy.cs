using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    [SerializeField] int maxHealth = 100;
    [SerializeField] Image healthBar;
    public void TakeDamage(int damage)
    {
        health -= damage;

        healthBar.fillAmount = (float)health / maxHealth;

        Debug.Log("Enemy health: " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
