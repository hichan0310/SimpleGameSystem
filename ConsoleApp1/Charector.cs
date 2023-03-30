namespace Main;


public class Charector
{
    public string name;
    public int hp;
    public int atk;
    public int def;
    public PQueue buffs = new PQueue();

    public Charector(string name, int hp, int atk, int def)
    {
        this.name = name;
        this.hp = hp;
        this.atk = atk;
        this.def = def;
    }

    public void addBuffs(Buff b)
    {
        b.apply(this);
        buffs.Enqueue(b, b.coolTime);
    }

    public void turnover(int t, bool mode = true)  // mode에 true 있으면 1회 적용되고 false 있으면 그냥 감소만 됨
    {
        this.buffs.DecreasePriority(t);
        if(mode) this.buffs.apply(this);
        this.check();
    }

    public void check()
    {
        while (buffs.PeekPriority() <= 0)
            buffs.Dequeue().remove(this);
    }

    public void damage(Charector caster, int dmg)
    {
        this.hp -= (int)((Math.Log10(caster.atk) - Math.Log10(this.def) + 1) * dmg);
    }

    public override string ToString()
    {
        string result =
            $"{name}\n====================================================\nhp : {hp}\natk : {atk}\ndef : {def}\n----------------------------------------------------\nBuffs\n";
        result += buffs.ToString();
        return result;
    }
}