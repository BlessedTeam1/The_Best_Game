using UnityEngine;

public class LootDropper : MonoBehaviour
{
    [System.Serializable]
    public class LootItem
    {
        public GameObject itemPrefab;
        public float dropChance = 1.0f; // от 0.0 до 1.0
    }

    public LootItem[] lootTable; // таблица возможных предметов

    public void DropLoot()
    {
        foreach (var loot in lootTable)
        {
            float roll = Random.value; // случайное число от 0 до 1
            if (roll <= loot.dropChance)
            {
                Vector3 dropPosition = transform.position + Random.insideUnitSphere * 0.5f;
                dropPosition.y = transform.position.y; // Не уходит под землю
                Instantiate(loot.itemPrefab, dropPosition, Quaternion.identity);
            }
        }
    }
}
