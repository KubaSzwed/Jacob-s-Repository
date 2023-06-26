package com.company;

import java.io.IOException;

public class Main {

    public static void main(String[] args) {
        runTests();
    }

    public static void runTests() {
        testBook();
        testBookList();
        testFileManager();
    }

    public static void testBook() {
        System.out.println("=== Testowanie klasy Book ===");

        // Tworzenie i wyświetlanie informacji o książce
        Book book1 = new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997, "9780590353403");
        System.out.println("Informacje o książce:");
        System.out.println(book1);

        // Zmiana informacji o książce i wyświetlanie ponownie
        book1.setTitle("Harry Potter and the Chamber of Secrets");
        book1.setAuthor("J.K. Rowling");
        book1.setYear(1998);
        book1.setIsbn("9780439064873");
        System.out.println("Zmienione informacje o książce:");
        System.out.println(book1);
    }

    public static void testBookList() {
        System.out.println("=== Testowanie klasy BookList ===");

        // Tworzenie listy książek
        BookList bookList = new BookList();

        // Dodawanie książek do listy
        bookList.add("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997, "9780590353403");
        bookList.add("To Kill a Mockingbird", "Harper Lee", 1960, "9780061120084");
        bookList.add("The Great Gatsby", "F. Scott Fitzgerald", 1925, "9780743273565");

        // Wyświetlanie listy książek
        System.out.println("Lista książek:");
        System.out.println(bookList);

        // Usuwanie książki z listy
        bookList.remove("9780590353403");
        System.out.println("Po usunięciu książki:");
        System.out.println(bookList);

        // Wyszukiwanie książki
        Book book = bookList.getBook("9780061120084");
        System.out.println("Wyszukana książka:");
        System.out.println(book);
    }

    public static void testFileManager() {
        System.out.println("=== Testowanie klasy FileManager ===");

        // Tworzenie listy książek
        BookList bookList = new BookList();
        bookList.add("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997, "9780590353403");
        bookList.add("To Kill a Mockingbird", "Harper Lee", 1960, "9780061120084");
        bookList.add("The Great Gatsby", "F. Scott Fitzgerald", 1925, "9780743273565");

        // Zapisywanie listy książek do pliku
        FileManager fileManager = new FileManager();
        try {
            fileManager.saveBookListToFile(bookList, "booklist.txt");
            System.out.println("Lista książek została zapisana do pliku.");
        } catch (IOException e) {
            System.out.println("Wystąpił błąd podczas zapisu listy książek do pliku.");
            e.printStackTrace();
        }

        // Wczytywanie listy książek z pliku
        BookList loadedBookList = new BookList();
        try {
            fileManager.loadBookListFromFile(loadedBookList, "booklist.txt");
            System.out.println("Wczytana lista książek:");
            System.out.println(loadedBookList);
        } catch (IOException e) {
            System.out.println("Wystąpił błąd podczas wczytywania listy książek z pliku.");
            e.printStackTrace();
        }
    }
}

