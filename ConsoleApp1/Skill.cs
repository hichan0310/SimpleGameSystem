namespace Main;


public class Skill
{
    public int level;
    public string name;
    public string explaination;

    public Skill(string name, string explaination, int level)
    {
        this.level = level;
        this.name = name;
        this.explaination = explaination;
    }

    public void upgrade(int lvl)
    {
        this.level += lvl;
    }
}







public class RangeSkill : Skill
{
    public RangeSkill(string name, string explaination, int level = 0) : base(name, explaination, level)
    {
    }

    public virtual void execute(Charector caster, List<Charector> targets)  // 여기에는 스킬 사용 여부만 표시
    {
        string result = $"{name} : {caster.name} -> ";
        foreach (Charector c in targets)
            result += $"{c.name} ";
    }
}

public class OneTargetSkill : Skill
{
    public OneTargetSkill(string name, string explaination, int level = 0) : base(name, explaination, level)
    {
    }

    public virtual void execute(Charector caster, Charector target) // 여기에는 스킬 사용 여부만 표시
    {
        string result = $"{name} : {caster.name} -> ";
        result += $"{target.name} ";
    }
}





public class PassiveSkill : Skill
{
    public PassiveSkill(string name, string explaination, int level = 0) : base(name, explaination, level)
    {
    }

    public virtual void apply(Charector caster)
    {
    }
}
