using UnityEngine;
using System;

[CreateAssetMenu(menuName = "PlayerHP")]
public class PlayerHealthSO : ScriptableObject
{
    public event Action OnHealthAdded = delegate { };

    public int currentHealth;
    public int maxHealth = 3;

    public void AddHealth(int amount)
    {
        if (currentHealth == maxHealth)
            return;

        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }
        OnHealthAdded();
        
    }
}
