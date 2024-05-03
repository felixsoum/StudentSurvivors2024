using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    protected int level;

    public virtual void LevelUp()
    {
        level++;
        gameObject.SetActive(true);
    }
}
