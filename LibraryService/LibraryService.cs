namespace LibraryService;

public sealed class LibraryService : ILibraryService
{

  private List<IItem> _items = new List<IItem>();

  public LibraryService() { }

  public IItem GetItem(string id)
  {
    foreach (IItem item in _items) {
        if (item.Id == id) {
            return item;
        }
    }
        throw new InvalidOperationException("ID not found.");
  }

  public void AddItem(IItem item)
  {
        foreach (IItem item2 in _items) {
            if (item2.Id == item.Id){
                throw new InvalidOperationException("Duplicate item found.");
            }
        }
        _items.Add(item);
  }

  public void RemoveItem(string id)
  {
    foreach (IItem item in _items) {
        if (item.Id == id) {
            _items.Remove(item);
            return;
        }
    }
    throw new InvalidOperationException("ID not found.");
  }

  public void BorrowItem(string id, Person borrower)
  {
    foreach (IItem item in _items) {
        if (item.Id == id) {
            item.BorrowItem(borrower);
            return;
        }
    }
        throw new InvalidOperationException("ID not found.");
  }

  public void ReturnItem(string id, Person returnee)
  {
        foreach (IItem item in _items) {
            if (item.Id == id) {
                item.ReturnItem(returnee);
                return;
            }
        }
        throw new InvalidOperationException("ID not found.");
  }
}
