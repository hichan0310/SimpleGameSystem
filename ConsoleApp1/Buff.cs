namespace Main;

public class PQueue
{
    private class Node
    {
        public Buff Data { get; private set; }
        public int Priority { get; set; } = 0;

        public Node(Buff data, int priority)
        {
            this.Data = data;
            this.Priority = priority;
        }

        public void decrease(int t)
        {
            this.Priority -= t;
        }
    }

    private List<Node> nodes = new List<Node>();

    public int Count => nodes.Count;

    public void Enqueue(Buff data, int priority)
    {
        Node newNode = new Node(data, priority);
        if (nodes.Count == 0)
        {
            nodes.Add(newNode);
        }
        else
        {
            //////////////////////////////
            // 이진 탐색을 시작한다. 'O(logN)'
            int start = 0;
            int end = nodes.Count - 1;
            int harf = 0;
            while (start != end)
            {
                if (end - start == 1)
                {
                    if (nodes[start].Priority < priority)
                    {
                        harf = end;
                    }
                    else
                    {
                        harf = start;
                    }

                    break;
                }
                else
                {
                    harf = start + ((end - start) / 2);
                    if (nodes[harf].Priority > priority)
                    {
                        // Down
                        end = harf;
                    }
                    else
                    {
                        // Up
                        start = harf;
                    }
                }
            }
            //////////////////////////////

            if (nodes[harf].Priority > priority)
                nodes.Insert(harf, newNode);
            else
                nodes.Insert(harf + 1, newNode);
        }
    }

    public Buff Dequeue()
    {
        Node tail = null;

        if (Count > 0)
        {
            tail = nodes[nodes.Count - 1];
            nodes.RemoveAt(nodes.Count - 1);
        }

        if (tail != null)
            return tail.Data;
        return default(Buff);
    }

    public Buff Peek()
    {
        Node tail = null;

        if (Count > 0)
            tail = nodes[nodes.Count - 1];

        if (tail != null)
            return tail.Data;
        return default(Buff);
    }

    public int PeekPriority()
    {
        Node tail = null;

        if (Count > 0)
            tail = nodes[nodes.Count - 1];

        if (tail != null)
            return tail.Priority;
        return Int32.MaxValue;
    }

    public void DecreasePriority(int t)
    {
        for (int i = 0; i < nodes.Count;i++)
            nodes[i].decrease(t);
    }

    public void apply(Charector target)
    {
        for (int i = 0; i < nodes.Count;i++)
            nodes[i].Data.apply(target);
    }

    public override string ToString()
    {
        string result = "";
        foreach (var b in nodes)
        {
            result += b.Data.ToString();
            result += $"{b.Priority}/{b.Data.coolTime}";
            result += "\n \n";
        }

        if (nodes.Count == 0)
            result += "none\n \n";

        return result;
    }
}

public class Buff
{
    public string name;
    public string explaination;
    public bool isDeBuff;
    public Buff(string name, string explaination, int coolTime)
    {
        this.name = name;
        this.explaination = explaination;
        this.coolTime = coolTime;
    }

    public virtual void apply(Charector target)
    {
    }

    public virtual void remove(Charector target)
    {
    }
    
    public virtual void attack(Charector target){}
    
    public virtual void getHit(Charector target){}

    public int coolTime;

    public override string ToString()
    {
        string result= $"name : {name}\n{explaination}\nturn : ";
        return result;
    }
}

