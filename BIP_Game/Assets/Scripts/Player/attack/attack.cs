using UnityEngine;
using System.Collections;

public class AutoAttack : MonoBehaviour
{
    private AttackZoneDamage attackZoneDamage;
    public float attackCooldown = 0.3f; // было 0.5 — стало быстрее
    private float lastAttackTime = 0f;

    public GameObject attackZonePrefab;  // Префаб зоны атаки
    public float activeTime = 0.2f;       // чуть короче время действия

    void Start()
    {
        attackZoneDamage = GetComponentInChildren<AttackZoneDamage>(); 
    }

    void Update()
    {
        if (Time.time >= lastAttackTime + attackCooldown)
        {
            attackZoneDamage.PerformAttack();

            lastAttackTime = Time.time;
        }
        
    }
}
