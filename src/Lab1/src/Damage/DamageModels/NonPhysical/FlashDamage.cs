namespace Itmo.ObjectOrientedProgramming.Lab1.Damage.DamageModels.NonPhysical;

public class FlashDamage : NonPhysicalDamage
{
    private const int FlashDamageValue = 100;
    public FlashDamage()
        : base(
            FlashDamageValue)
    {
    }
}