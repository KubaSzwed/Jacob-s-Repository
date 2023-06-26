package com.company;

import java.util.ArrayList;
import java.util.List;

public class BookList {
    private List<Book> books;

    public BookList() {
        this.books = new ArrayList<>();
    }

    public void add(String title, String author, int year, String isbn) {
        Book book = new Book(title, author, year, isbn);
        books.add(book);
    }

    public void remove(String isbn) {
        Book bookToRemove = null;
        for (Book book : books) {
            if (book.getIsbn().equals(isbn)) {
                bookToRemove = book;
                break;
            }
        }
        if (bookToRemove != null) {
            books.remove(bookToRemove);
        }
    }

    public List<Book> getBooks() {
        return books;
    }

    public Book getBook(String isbn) {
        for (Book book : books) {
            if (book.getIsbn().equals(isbn)) {
                return book;
            }
        }
        return null;
    }
    /**
     * Zwraca rozmiar listy książek
     * @return liczba książek w liście
     * @throws SizeException jeśli lista jest pusta
     */
    public int size() throws SizeException {
        if (books.size() == 0) {
            throw new SizeException();
        }
        return books.size();
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        for (Book book : books) {
            sb.append(book.toString());
        }
        return sb.toString();
    }
}