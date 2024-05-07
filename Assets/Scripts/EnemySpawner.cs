using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Une coroutine est une méthode qui peut inclure des délais de temps
    public IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                // new Merman ...
                // Instantiate(Merman) ...
                EnemyFactory.GetInstance().CreateWeakEnemy(PickPointAroundPlayer(), Quaternion.identity);
            }
            EnemyFactory.GetInstance().CreateStrongEnemy(PickPointAroundPlayer(), Quaternion.identity);
            yield return new WaitForSeconds(15);
        }
    }

    Vector3 PickPointAroundPlayer()
    {
        Vector3 resultat = Player.GetInstance().transform.position;

        Vector2 randomPoint = Random.insideUnitCircle.normalized * 6f;
        resultat.x += randomPoint.x;
        resultat.y += randomPoint.y;

        return resultat;
    }
}
