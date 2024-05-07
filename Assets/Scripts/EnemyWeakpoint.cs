// Le Weakpoint est un Proxy pour l'Enemy
public class EnemyWeakpoint : Enemy
{
    // Référence à l'objet original 
    public Enemy original;

    // Renvoyer les requêtes
    public override void Damage(int value)
    {
        original.Damage(value * 10);
    }
}
