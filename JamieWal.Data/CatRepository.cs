
public class CatRepository
{
    private readonly List<Cat> _catDb = new List<Cat>();
    private int _count;

    public bool AddCat(Cat cat)
    {
        if (cat is null)
            return false;
        else
        {
            return AddToDatabase(cat);
        }
    }

    private bool AddToDatabase(Cat cat)
    {
        _count++;
        cat.Id = _count;
        _catDb.Add(cat);
        return true;
    }

    public List<Cat> GetCats()
    {
        return _catDb;
    }
    public Cat GetCat(int id)
    {
        return _catDb.FirstOrDefault(x => x.Id == id);
    }

    public bool UpdateCat(int id, Cat cat)
    {
        if (cat != null)
        {
            var catInDb = GetCat(id);
            if (catInDb != null)
            {
                catInDb.Name = cat.Name;
                catInDb.Price = cat.Price;
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }
    public bool DeleteCat(int id)
    {
        var catInDb = GetCat(id);
        return _catDb.Remove(catInDb);
    }
}
