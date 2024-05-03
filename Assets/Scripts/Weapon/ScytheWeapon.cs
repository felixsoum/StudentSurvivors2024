using UnityEngine;

public class ScytheWeapon : BaseWeapon
{
    [SerializeField] float scytheTimer = 2;
    float currentScytheTimer;

    private void Update()
    {
        currentScytheTimer -= Time.deltaTime;
        if (currentScytheTimer <= 0)
        {
            //Spawn le scythe
            for (int i = 0; i < level; i++)
            {
                Quaternion rot = Quaternion.Euler(0, 0, Random.Range(0, 360f));

                //Instantiate(scythePrefab, transform.position, rot);
                GameObject scythe = ObjectPool.GetInstance().GetPooledObject();
                scythe.transform.SetPositionAndRotation(transform.position, rot);
                scythe.SetActive(true);
            }
            currentScytheTimer += scytheTimer;
        }
    }
}
