using System.Collections;
namespace LAB9;

public class GameCollection : IEnumerable<Game>, IEnumerator<Game>
{
    List<Game> game = new List<Game>();
    public IEnumerator<Game> GetEnumerator()
    {
        return this;
    }
    int index = -1;
    public bool MoveNext()
    {
        if (index == game.Count - 1)
        {
            Reset();
            return false;
        }

        index++;
        return true;
    }
    public void Reset()
    {
        index = -1;
    }
    public Game Current
    {
        get
        {
            return game[index];
        }
    }
    object IEnumerator.Current => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
    public void Dispose() { }
    public void Add(Game obj)
    {
        if(obj!= null)
        {
            game.Add(obj);
        }
    }
    public void Delete(Game obj)
    {
        if(obj!=null)
        {
            game.Remove(obj);
        }
    }
    public void Delete(string name)
    {
        if (name != null)
        {
            game.Remove(game.Find(item => item.Name == name));
        }
    }
    public Game Find(Predicate<Game> match)
    {
        foreach(Game item in game)
        {
            if(match.Invoke(item))
            {
                return item;
            }
        }
        return null;
    }

    public void Print()
    {
        foreach(var item in game)
        {
            Console.WriteLine(item.ToString());
        }
    }

}
