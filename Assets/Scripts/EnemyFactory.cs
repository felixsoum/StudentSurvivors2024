using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] GameObject weakEnemy;
    [SerializeField] GameObject strongEnemy;

    private static EnemyFactory instance;
    public static EnemyFactory GetInstance() => instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject CreateWeakEnemy(Vector3 position, Quaternion rotation)
    {
        // Remplacer par Object Pool
        return Instantiate(weakEnemy, position, rotation);
    }

    public GameObject CreateStrongEnemy(Vector3 position, Quaternion rotation)
    {
        // Remplacer par Object Pool
        return Instantiate(strongEnemy, position, rotation);
    }
}
