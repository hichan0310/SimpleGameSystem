namespace Main;

public class SearingOnslaught : ActiveSkill
{
    public SearingOnslaught(int level) : base(
        "역날의 화염",
        "공격력에 기반하여 1회 광역 데미지를 주고 화상 효과를 3턴 부여합니다. ",
        level)
    {
    }

    private int coefficient
    {
        get { return 40 + level * 10; }
    }

    public override void execute(Charector caster, List<Charector> targets)
    {
        base.execute(caster, targets);
        foreach (var atkObserver in caster.attackObserver)
            atkObserver.attack(caster);
        foreach (Charector target in targets)
        {
            target.damage(caster, this.coefficient);
            foreach (var hitObserver in target.getHitObserver)
                hitObserver.getHit(caster);
            target.addBuffs(new Burn(3));
        }
    }
}

public class GlacialIllumination : ActiveSkill
{
    public GlacialIllumination(int level) : base(
        "파도를 얼리는 광검",
        "캐릭터에게 빛의 검 상태를 부여한다. 데미지를 줄 때마다 에너지가 쌓이고 5턴 뒤에 폭발하여 캐릭터의 공격력과 스택 수에 기반하여 광역 피해를 입힌다. ",
        level)
    {
    }

    private int coefficient
    {
        get { return 100 + level * 20; }
    }

    public override void execute(Charector caster, List<Charector> targets)
    {
        base.execute(caster, targets);
        foreach (var atkObserver in caster.attackObserver)
            atkObserver.attack(caster);
        caster.addBuffs(new LightfallSword(5));
        foreach (Charector target in targets)
        {
            target.damage(caster, this.coefficient);
            foreach (var hitObserver in target.getHitObserver)
                hitObserver.getHit(caster);
        }
    }
}