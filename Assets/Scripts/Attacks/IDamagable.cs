public interface IDamagable
{
    /// <summary>
    /// Damage the object it is attached to
    /// </summary>
    /// <param name="damage">the damage value passed by the opposite solder</param>
    public void OnDamage(int damage);
}
