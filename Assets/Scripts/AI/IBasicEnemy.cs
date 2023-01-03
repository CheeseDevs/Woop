public interface IBasicEnemy: IDamagable
{
    void Move();
    void DealDamage(float damage);
    void Die();
}
