using UnityEngine;

[CreateAssetMenu(
    fileName = "New Example Ability", 
    menuName = "Abilities/Example Ability"
)]
public class ExampleAbility : Ability
{
   
    [Header("🔧 Настройки примера")]
    [Tooltip("Радиус действия способности")]
    public float radius = 3f;

     public string animationTrigger;
    public Animator animator;

    [Tooltip("Сколько урона наносится в области")]
    public int damage = 10;

    [Tooltip("На каких слоях искать цели")]
    public LayerMask targetLayer;

    public override void Activate(GameObject user)
    {
        Debug.Log("dfdfdfd");
        
        
         var animator = user.GetComponentInChildren<Animator>();
        if (animator != null && !string.IsNullOrEmpty(animationTrigger))
        {
            animator.SetTrigger(animationTrigger);
        }
      
        // 1. Собираем коллайдеры в радиусе
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            user.transform.position,
            radius,
            targetLayer
        );

        // 2. Для каждого наносим урон (если у объекта есть EnemyHealth)
        foreach (var hit in hits)
        {
            var hp = hit.GetComponent<EnemyHealth>();
            
            hp?.TakeDamage(damage);
            hp?.GetFire();
        }

        // 3. (Опционально) Визуальный эффект, звук и т.п.
        //    e.g. Instantiate(particlePrefab, user.transform.position, Quaternion.identity);
    }

    // (Опционально) Для удобства в редакторе можно визуализировать радиус возле игрока:
#if UNITY_EDITOR
    
#endif
}
