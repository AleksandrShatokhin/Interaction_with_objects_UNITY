using UnityEngine;

public interface IPickableArmor
{
    void SetParametersArmor(int speed, int health, int armor);
}

public interface IPickableWeapon
{
    void PickableWeapon(GameObject weapon);
}

public interface IShooting
{
    void Shooting();
}

public interface IPickableItem
{
    void PickableItem(PickableItem item);
}

public interface IHealthable
{
    void TakeDamage(int damage);
    void SetHealthParameters(int health, int armor);
}

public interface IDeathable
{
    void Death();
}