namespace Main;

public class FireBall : RangeSkill
{
    public FireBall(int level) : base("파이어볼", "공격력에 기반하여 1회 광역 데미지를 주고 화상 효과를 3턴 부여합니다. ", level)
    {
    }

    private int coefficient
    {
        get { return 40 + level * 10; }
    }

    public override void execute(Charector caster, List<Charector> targets)
    {
        base.execute(caster, targets);
        foreach (Charector target in targets)
        {
            target.damage(caster, this.coefficient);
            target.addBuffs(new Burn(3));
        }
    }
}

public class Javelin : OneTargetSkill
{
    public Javelin(int level) : base("창 던지기", "창을 던져 공격력에 기반한 물리 피해를 줍니다. ", level)
    {
    }
    
    private int coefficient
    {
        get { return 100 + level * 20; }
    }
    
    public override void execute(Charector caster, Charector target)
    {
        base.execute(caster, target);
        target.damage(caster, this.coefficient);
    }
}