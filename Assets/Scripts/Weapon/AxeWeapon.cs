using UnityEngine;

public class AxeWeapon : BaseWeapon
{
    [SerializeField] GameObject axe;

    public override void LevelUp()
    {
        base.LevelUp();
        axe.transform.localScale = Vector3.one * (1f + 0.1f * level);
    }

    private void Update()
    {
        transform.Rotate(0, 0, 180f * Time.deltaTime);
    }
}
