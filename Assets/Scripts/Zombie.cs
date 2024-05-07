using UnityEngine;

public class Zombie : Enemy
{
    [SerializeField] GameObject weakPointPrefab;
    private EnemyWeakpoint weakpoint;
    private LineRenderer lineRenderer;

    private void Start()
    {
        weakpoint = Instantiate(weakPointPrefab, transform.position,
            Quaternion.identity).GetComponent<EnemyWeakpoint>();
        weakpoint.original = this;
        lineRenderer = GetComponent<LineRenderer>();
        UpdateLine();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        UpdateLine();
    }

    private void UpdateLine()
    {
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, weakpoint.transform.position);
    }

    public override void Die()
    {
        weakpoint.Die();
        base.Die();
    }

}
