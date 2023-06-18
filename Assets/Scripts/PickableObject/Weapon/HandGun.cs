public class HandGun : WeaponManager
{
    public override void Shooting()
    {
        Instantiate(weaponSO.bulletPrefab, bulletStartPosition.position, bulletStartPosition.rotation);
    }
}
