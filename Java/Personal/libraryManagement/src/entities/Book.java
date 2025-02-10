package entities;

public class Book {
	
	private String title;		
	private String author;
	private String isbn;
	private Boolean isAvailable;
	
	public Book(String title, String author, String isbn) {
		this.title = title;
		this.author = author;
		this.isbn = isbn;
		this.isAvailable = setAvailableWhenRegistred();;
	}
	
	public String getTitle() {
		return title;
	}
	public String getAuthor() {
		return author;
	}
	public String getIsbn() {
		return isbn;
	}
	public String getIsbnFormatted() {
		String isbnStr = isbn.toString();
		return String.format("%s-%s-%s-%s-%s",isbnStr.substring(0, 3),isbnStr.substring(3, 4),isbnStr.substring(4, 6),isbnStr.substring(6, 12),isbnStr.substring(12));
	}
	public Boolean getIsAvailable() {
		return isAvailable;
	}
	
	public boolean setAvailableWhenRegistred() {
        return true;
    }
	
	public void loan() {
		this.isAvailable = false;
	}
	
	public void returnBook() {
		this.isAvailable = true;
	}
	
	@Override
    public String toString() {
        return String.format("Title: %s%nAuthor: %s%nISBN: %s%nAvailable: %b", title, author, getIsbnFormatted(), isAvailable);
    }
}