internal interface IHammer
{
    float AttackRange { get; set; }
    float SwingSpeed { get; set; }
    void Initialize();
    void HammerAttackTick();
}