namespace Main;

public class Charector
{
    public string name;
    public int hpBasic, atkBasic, defBasic;
    public int hpAdd=0, atkAdd=0, defAdd=0;
    public int hpRate=100, atkRate=100, defRate=100;
    public PQueue buffs = new PQueue();
    public int dmg;
    

    public List<Buff> getHitObserver = new List<Buff>();
    public List<Buff> attackObserver = new List<Buff>();

    public int hp
    {
        get { return Math.Max(hpBasic * hpRate / 100 + hpAdd - dmg, 0); }
    }
    public int atk
    {
        get { return atkBasic * atkRate / 100 + atkAdd; }
    }
    public int def
    {
        get { return defBasic * defRate / 100 + defAdd; }
    }

    public Charector(string name, int hp, int atk, int def)
    {
        this.name = name;
        this.hpBasic = hp;
        this.atkBasic = atk;
        this.defBasic = def;
    }

    public void addBuffs(Buff b)
    {
        b.apply(this);
        buffs.Enqueue(b, b.coolTime);
    }

    public void turnover(int t, bool mode = true) // mode에 true 있으면 1회 적용되고 false 있으면 그냥 감소만 됨
    {
        this.buffs.DecreasePriority(t);
        if (mode) this.buffs.apply(this);
        this.check();
    }

    public void check()
    {
        while (buffs.PeekPriority() <= 0)
            buffs.Dequeue().remove(this);
    }

    public void damage(Charector caster, int dmg)
    {
        this.dmg += (int)((Math.Log10(caster.atk) - Math.Log10(this.def) + 1) * dmg);
        this.dmg = Math.Max(this.dmg, 0);
    }

    public override string ToString()
    {
        string result =
            $"{name}\n====================================================\nhp : {hp}\natk : {atk}\ndef : {def}\n----------------------------------------------------\nBuffs\n";
        result += buffs.ToString();
        return result;
    }
}