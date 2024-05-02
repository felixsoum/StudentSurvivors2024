using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Une coroutine est une m�thode qui peut inclure des d�lais de temps
    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(enemyPrefab, new Vector3(3f, 3f, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(5);
        }
    }
}
