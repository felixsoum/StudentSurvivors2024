using System.Collections;
using UnityEngine;

public class ScytheWeapon : BaseWeapon
{
    private void Start()
    {
        StartCoroutine(SpawnScythe());
    }

    public IEnumerator SpawnScythe()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            //Spawn le scythe
            for (int i = 0; i < level; i++)
            {
                GameObject scythe = ObjectPool.GetInstance().GetPooledObject();
                scythe.transform.position = transform.position;
                scythe.transform.right = Vector3.right * Player.GetInstance().transform.localScale.x;
                scythe.SetActive(true);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
