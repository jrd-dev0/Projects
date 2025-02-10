package entities;

import java.util.ArrayList;
import java.util.List;

public class User {
	
	private int id;
	private String name;
	
	List<Book> borrowedBooks = new ArrayList<Book>();
	
	public User(int id, String name) {
        this.id = id;
        this.name = name;
    }
	
	public int getId() {
        return id;
    }
	
	public String getName() {
        return name;
    }
	
	public void setName(String name) {
		this.name = name;
	}
	 	
	public void borrowBook(Book book) {
        book.loan();
        borrowedBooks.add(book);
    }
	
	public void returnBook(Book book) {
        book.returnBook();
        borrowedBooks.remove(book);
    }
	
	public List<Book> getBorrowedBooks() {
        
		return borrowedBooks;
    }
	
	@Override
    public String toString() {
        return String.format("Id: %d%nName: %s", getId(), getName());
    }

}
