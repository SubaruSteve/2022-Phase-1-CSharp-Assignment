namespace LibraryService;

public class Book : IItem
{
  public string Id { get; }
  private string Title;
  private string Author;
  private Person? Borrower;

  public Book(string isbn, string title, string author)
  {
    Id = isbn;
    Title = title;
    Author = author;
  }

  public override string ToString()
  {
    return $"BOOK - {Title} by {Author}";
  }

  public void BorrowItem(Person borrower)
  {
    if(IsAvailable()){
        Borrower = borrower;
    }
    else{
        throw new InvalidOperationException("This book is not available.");
    }
  }

  public void ReturnItem(Person returnee)
  {
    if(returnee == Borrower){
        Borrower = null;
    }
    else{
        throw new InvalidOperationException("Returnee is not the same as Borrower.");
    }
  }

  public bool IsAvailable()
  {
    return Borrower == null;
  }
}
