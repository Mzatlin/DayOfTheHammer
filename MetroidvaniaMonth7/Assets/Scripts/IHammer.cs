internal interface IHammer
{
    float AttackRange { get; set; }
    void Initialize();
    void HammerAttackTick();
}