package application;

import java.util.Locale;
import entities.Book;
import entities.Library;
import entities.User;

public class Program {
	
	public static void main(String[] args) {
		
		Locale.setDefault(Locale.US);
		
		Library library = new Library();
		Book book1 = new Book("Java for Beginners", "John Doe", "1234567890123");
		Book book2= new Book("Java for Medium", "John Doe", "1234567890123");
		Book book3= new Book("Java for Advanced", "John Doe", "1234567890123");
		User user1 = new User(1, "Maria");
		User user2 = new User(2, "Joao");
		
		library.registerBook(book1);
		library.registerUser(user1);
		
		library.loanBook(book1, user1);
		library.loanBook(book2, user1);	
		library.loanHistory(user1);
		System.out.println("----------------------------------");
		library.loanBook(book1, user2);
		library.loanBook(book3, user2);
		System.out.println("----------------------------------");
		library.loanHistory(user2);
		System.out.println("----------------------------------");
		library.returnBook(book1, user1);
		System.out.println("----------------------------------");
		library.loanBook(book1, user2);
		library.loanBook(book2, user2);
		System.out.println("----------------------------------");
		library.loanHistory(user2);
	}
}