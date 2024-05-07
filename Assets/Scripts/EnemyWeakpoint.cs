// Le Weakpoint est un Proxy pour l'Enemy
public class EnemyWeakpoint : Enemy
{
    // R�f�rence � l'objet original 
    public Enemy original;

    // Renvoyer les requ�tes
    public override void Damage(int value)
    {
        original.Damage(value * 10);
    }
}
