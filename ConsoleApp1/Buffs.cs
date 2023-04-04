namespace Main;

public class Burn : Buff
{
    public Burn(int coolTime) : base(
        "화상",
        "화상 효과를 적용합니다. 남은 체력의 2%의 데미지를 줍니다. ",
        coolTime)
    {
        this.isDeBuff = true;
    }

    public override void apply(Charector target)
    {
        target.dmg += target.hp / 50;
    }
}

public class PowerUp : Buff
{
    private bool buffed;
    public PowerUp(int coolTime) : base(
        "파워업",
        "공격력이 10% 증가합니다. ",
        coolTime)
    {
        this.isDeBuff = false;
        this.buffed = false;
    }

    public override void apply(Charector target)
    {
        if(buffed)return;
        base.apply(target);
        target.atkRate += 10;
        buffed = true;
    }

    public override void remove(Charector target)
    {
        base.remove(target);
        target.atkRate -= 10;
    }
}



public class LightfallSword : Buff
{
    private int energy;
    public LightfallSword(int coolTime) : base(
        "빛의 검",
        "캐릭터가 공격하면 에너지가 1스택이 쌓이고 일정 턴 수 이후에 스택 수와 공격력에 기반하여 피해를 입힌다. ",
        coolTime)
    {
        this.isDeBuff = false;
    }

    public override void attack(Charector target)
    {
        base.getHit(target);
        energy += 1;
    }
}