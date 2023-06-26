package com.company;
import java.io.*;


public class FileManager {

    /**
     * Zapisuje listę książek do pliku tekstowego
     * @param bookList lista książek
     * @param fileName nazwa pliku
     * @throws IOException błąd podczas zapisu do pliku
     */
    public void saveBookListToFile(BookList bookList, String fileName) throws IOException {
        try (PrintWriter writer = new PrintWriter(new FileWriter(fileName))) {
            for (Book book : bookList.getBooks()) {
                writer.println(book.getTitle());
                writer.println(book.getAuthor());
                writer.println(book.getYear());
                writer.println(book.getIsbn());
            }
        }
    }

    /**
     * Wczytuje listę książek z pliku tekstowego
     * @param bookList lista książek
     * @param fileName nazwa pliku
     * @throws IOException błąd podczas wczytywania z pliku
     */
    public void loadBookListFromFile(BookList bookList, String fileName) throws IOException {
        try (BufferedReader reader = new BufferedReader(new FileReader(fileName))) {
            String line;
            while ((line = reader.readLine()) != null) {
                String title = line;
                String author = reader.readLine();
                int year = Integer.parseInt(reader.readLine());
                String isbn = reader.readLine();
                bookList.add(title, author, year, isbn);
            }
        }
    }
}

