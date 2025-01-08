using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f , 1f)]
        public float SpawnChance;
    }
    public SpawnableObject[] objects;
    public float MinSpawnRange = 1f;
    public float MaxSpawnRange = 2f;
    private void OnEnable()
    {
        Invoke(nameof(Spwan) , Random.Range(MinSpawnRange,MaxSpawnRange));
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    private void Spwan()
    {
        float SpawnChance = Random.value;
        foreach (var obj in objects)
        {
            if(SpawnChance < obj.SpawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }
            SpawnChance -= obj.SpawnChance;
        }
        Invoke(nameof(Spwan) , Random.Range(MinSpawnRange,MaxSpawnRange));
    }
}

