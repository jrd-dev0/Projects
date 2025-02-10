### Biblioteca Virtual

Este é um projeto de Biblioteca Virtual desenvolvido em Java, que permite a gestão de livros, usuários e empréstimos de forma simples e eficiente. O projeto inclui as classes `Book`, `Library` e `User`, cada uma com suas responsabilidades específicas.

#### Funcionalidades Principais

- **Cadastro de Livros:** Adicionar e remover livros da biblioteca.
- **Cadastro de Usuários:** Adicionar e remover usuários da biblioteca.
- **Empréstimo de Livros:** Empréstimo e devolução de livros para usuários cadastrados.
- **Histórico de Empréstimos:** Visualização do histórico de empréstimos de cada usuário.

#### Estrutura do Projeto

- **application**
  - `Program.java`: Classe principal que executa o programa e demonstra as funcionalidades da biblioteca.

- **entities**
  - `Book.java`: Classe que representa um livro na biblioteca.
  - `Library.java`: Classe que gerencia os livros e usuários da biblioteca.
  - `User.java`: Classe que representa um usuário da biblioteca.

#### Exemplo de Uso

Abaixo está um exemplo de uso das funcionalidades da biblioteca:

```java
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
        Book book2 = new Book("Java for Medium", "John Doe", "1234567890123");
        Book book3 = new Book("Java for Advanced", "John Doe", "1234567890123");
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
```

#### Classes Principais

##### Book

A classe `Book` representa um livro na biblioteca com os seguintes atributos e métodos:

- **Atributos:**
  - `title`: Título do livro.
  - `author`: Autor do livro.
  - `isbn`: Código ISBN do livro.
  - `isAvailable`: Indica se o livro está disponível para empréstimo.

- **Métodos:**
  - `loan()`: Marca o livro como não disponível.
  - `returnBook()`: Marca o livro como disponível.
  - `getIsbnFormatted()`: Retorna o ISBN formatado.

##### Library

A classe `Library` gerencia os livros e usuários da biblioteca com os seguintes métodos:

- `registerBook(Book book)`: Registra um novo livro na biblioteca.
- `removeBook(Book book)`: Remove um livro da biblioteca.
- `registerUser(User user)`: Registra um novo usuário na biblioteca.
- `removeUser(User user)`: Remove um usuário da biblioteca.
- `loanBook(Book book, User user)`: Realiza o empréstimo de um livro para um usuário.
- `returnBook(Book book, User user)`: Realiza a devolução de um livro por um usuário.
- `loanHistory(User user)`: Exibe o histórico de empréstimos de um usuário.

##### User

A classe `User` representa um usuário da biblioteca com os seguintes atributos e métodos:

- **Atributos:**
  - `id`: ID do usuário.
  - `name`: Nome do usuário.
  - `borrowedBooks`: Lista de livros emprestados pelo usuário.

- **Métodos:**
  - `borrowBook(Book book)`: Adiciona um livro à lista de livros emprestados pelo usuário.
  - `returnBook(Book book)`: Remove um livro da lista de livros emprestados pelo usuário.