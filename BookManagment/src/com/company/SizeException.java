package com.company;

public class SizeException extends Exception {
    public SizeException() {
        System.out.println("Brak książek do wyświetlenia. Lista jest pusta.");
    }

    public SizeException(String information) {
        super(information);
    }
}
