package com.company;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

public class BookListTest {

    @Test
    public void testAddBook() {
        // Arrange
        BookList bookList = new BookList();

        // Act
        bookList.add("Book 1", "Author 1", 2021, "ISBN-1");

        // Assert
        Assertions.assertEquals(1, bookList.getBooks().size());
    }

    @Test
    public void testRemoveBook() {
        // Arrange
        BookList bookList = new BookList();
        bookList.add("Book 1", "Author 1", 2021, "ISBN-1");
        bookList.add("Book 2", "Author 2", 2022, "ISBN-2");

        // Act
        bookList.remove("ISBN-1");

        // Assert
        Assertions.assertEquals(1, bookList.getBooks().size());
        Assertions.assertNull(bookList.getBook("ISBN-1"));
    }
}