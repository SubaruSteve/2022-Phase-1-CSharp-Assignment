using System.Collections;
namespace LibraryService;

public class Video : IItem
{
  public string Id { get; }
  private string Title;
  private string Producer;
  private int Copies;
  private List<Person> Borrowers = new List<Person>();

  public Video(string barcode, string title, string producer, int copies)
  {
    Id = barcode;
    Title = title;
    Producer = producer;
    Copies = copies;
  }

  public void BorrowItem(Person borrower)
  {
    if (IsAvailable()) {
        foreach (Person person in Borrowers) {
            if (person == borrower) {
                    throw new InvalidOperationException("Duplicate borrower.");
            }
        }
        Borrowers.Add(borrower);
    }
    else {
        throw new InvalidOperationException("This book is not available.");
    }
  }

  public void ReturnItem(Person returnee)
  {
    foreach (Person borrower in Borrowers) {
        if (borrower == returnee) {
                Borrowers.Remove(borrower);
                return;
        }
    }
    throw new InvalidOperationException();
  }

  public override string ToString()
  {
    return $"VIDEO - {Title} by {Producer}";
  }

  public bool IsAvailable()
  {
    return Borrowers.Count < Copies;
  }
}
