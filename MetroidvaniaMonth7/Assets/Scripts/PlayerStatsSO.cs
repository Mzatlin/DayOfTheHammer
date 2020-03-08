using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerStats")]
public class PlayerStatsSO : ScriptableObject
{
    public int playerHealth = 3;
    public int playerAttackPower = 3;
    public int playerAttackSpeed = 3;
}
