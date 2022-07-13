using UnityEngine;

public interface ITakenDamage
{
    bool isAttack { get; set; }
    void TakenDamage(float _amount);
}
