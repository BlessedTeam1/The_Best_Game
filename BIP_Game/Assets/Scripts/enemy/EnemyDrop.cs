using UnityEngine;

public class LootDropper : MonoBehaviour
{
    [System.Serializable]
    public class LootItem
    {
        public GameObject itemPrefab;
        [Range(0f, 1f)] public float dropChance = 1.0f; // Вероятность дропа (0.0–1.0)
    }

    [Header("Настройки дропа")]
    public LootItem[] lootTable; // Таблица предметов

    [Header("Настройки позиции дропа")]
    public float dropRadius = 0.5f;

    public void DropLoot()
    {
        foreach (var loot in lootTable)
        {
            if (loot.itemPrefab == null)
            {
                Debug.LogWarning("LootDropper: Пустой itemPrefab в таблице лута");
                continue;
            }

            float roll = Random.value; // Число от 0 до 1
            if (roll <= loot.dropChance)
            {
                Vector3 dropPosition = transform.position + (Vector3)(Random.insideUnitCircle * dropRadius);
                Instantiate(loot.itemPrefab, dropPosition, Quaternion.identity);
            }
        }
    }
}
