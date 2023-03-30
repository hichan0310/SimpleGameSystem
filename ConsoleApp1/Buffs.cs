namespace Main;

public class Burn : Buff
{
    public Burn(int coolTime) : base("화상", "화상 효과를 적용합니다. 남은 체력의 2%의 데미지를 줍니다. 이 효과는 방어력을 무시합니다. ", coolTime)
    {
    }

    public override void apply(Charector target)
    {
        target.hp -= target.hp / 50;
    }
}