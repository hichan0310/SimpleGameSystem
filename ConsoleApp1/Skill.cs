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




public class ActiveSkill : Skill
{
    public ActiveSkill(string name, string explaination, int level = 0) : base(name, explaination, level)
    {
    }

    public virtual void execute(Charector caster, List<Charector> targets)  // 여기에는 스킬 사용 여부만 표시
    {
        string result = $"{name} : {caster.name} -> ";
        foreach (Charector c in targets)
            result += $"{c.name} ";
    }
}

// 이제 어떤 식으로 돌아갈지 대충 구상 완료
// 유니티로 넘어가자
// 게임판, 맵은 좀 더 만들어야 할 듯