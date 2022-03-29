public interface IPlayer
{
    PowerUp currentPowerUp { get; set; }

    void ApplyPowerEffect(PowerUp powerUp);

    void UseEffect();
}