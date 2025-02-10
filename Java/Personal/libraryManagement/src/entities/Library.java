package entities;

import java.util.ArrayList;
import java.util.List;

public class Library {
	
	private List<Book> books = new ArrayList<>();
	private List<User> users = new ArrayList<>();
	
	public Library() {
	}

	public List<Book> getBooks() {
		return books;
	}

	public List<User> getUsers() {
		return users;
	}
	
	public void registerBook(Book book) {
        books.add(book);
    }
	
	public void removeBook(Book book) {
        books.remove(book);
    }
	
	public void registerUser(User user) {
        users.add(user);
    }
	
	public void removeUser(User user) {
        users.remove(user);
    }
	
	public void loanBook(Book book, User user) {
		if(book.getIsAvailable()) {
            book.loan();
            user.borrowBook(book);
            System.out.println("Livro emprestado com sucesso!");
        } else {
            System.out.println("Livro indisponível.");
        }
	}
	
	public void returnBook(Book book, User user) {
		
		if(user.getBorrowedBooks().contains(book)) {
            book.returnBook();
            user.returnBook(book);
            System.out.println("Livro devolvido com sucesso!");
        } else {
            System.out.println("Livro não está emprestado.");
        }
	}
	
	public void loanHistory(User user) {
		
        for(Book book : user.getBorrowedBooks()) {
            System.out.println(book);
        }
	}
}