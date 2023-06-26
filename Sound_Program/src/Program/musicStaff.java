package Program;

import com.sun.jdi.IntegerValue;

import javax.sound.sampled.*;
import javax.swing.*;
import java.io.File;
import java.util.ArrayList;
import java.util.InputMismatchException;
import java.util.Scanner;
import java.util.Stack;

/**
 * W tej klasie zawarte sa metody, ktore odpowiadaja za edycje dzwieku, takie jak:
 * zmiana glosnosci, pauza, efekt echa, wczytanie pliku do edycji, cofniecie zmiany i
 * puszczenie dzwieku od tylu. Uzywanym przez nas typem danych jest Stack.
 *
 */
public class musicStaff {
    String soundFile = "";
    Audio audio;
    Stack<float[]> stackLeft = new Stack<float[]>();
    Stack<float[]> stackRight = new Stack<float[]>();
    ArrayList<String> historia = new ArrayList<String>();


    public void setSoundFile(String soundFile) {
        this.soundFile = soundFile;
        this.audio = new Audio(this.soundFile);
    }

    /**
     * Metoda wczytujaca wywolane, modyfikujace funkcje.
     *
     */
    public void wczytaj(){
        if(!stackRight.isEmpty()){
            float[] tempLeft = stackLeft.pop();
            float[] tempRight = stackRight.pop();
            audio.setLeftChannel(tempLeft);
            audio.setRightChannel(tempRight);
            historia.remove(historia.size()-1);
        } else {System.out.println("Nie ma elementow do wczytania");}

    }

    public void addStack(Audio audio){

        stackLeft.push(audio.getLeftChannel());
        stackRight.push(audio.getRightChannel());
    }

    /**
     * Metoda przyspieszajaca odtworzona sciezke dzwiekowa.
     *
     */

    public void fasterNH() {
        float[] left = audio.getLeftChannel();
        float[] right = audio.getRightChannel();
        float[] tempLeft = new float[(left.length/2)];
        float[] tempRight = new float[(right.length/2)];
        int nL = 0;
        int nR = 0;

        for(int i=0; i < tempLeft.length; i++) {
            tempLeft[i] = left[nL];
            if (nL != 0 && nL%1000 == 0) nL += 1000;
            nL++;
        }
        for(int i=0; i < tempRight.length; i++) {
            tempRight[i] = right[nR];
            if (nR != 0 && nR%1000 == 0) nR += 1000;
            nR++;
        }
        addStack(audio);
        audio.setLeftChannel(tempLeft);
        audio.setRightChannel(tempRight);
        historia.add("przyśpieszenie");


    }

    /**
     * Metoda odtwarzajaca wczytana sciezke dzwiekowa od tylu.
     *
     */
    public void reverse() {
        float[] left = audio.getLeftChannel();
        float[] right = audio.getRightChannel();
        float[] tempLeft	= audio.getLeftChannel();
        float[] tempRight	= audio.getRightChannel();
        int sizeLeft = left.length-1;
        int sizeRight = right.length-1;

        //USED FOR OFF BY ONE DEBUG
        //System.out.println(sizeLeft + "\n" + sizeRight);
        //System.out.println(tempLeft.length + "\n" + tempRight.length);

        //SWEEP IN REVERSE AND STORE INTO TEMP ARRAYS
        for (int i = 0; i <= sizeLeft; i++)
            tempLeft[i] = left[sizeLeft - i];
        for (int i = 1; i <= sizeRight; i++)
            tempRight[i] = right[sizeRight - i];

        //SET CHANNELS AS TEMP ARRAYS
        audio.setLeftChannel(tempLeft);
        audio.setRightChannel(tempRight);
        historia.add("odwrócenie");
    }

    /**
     * Metoda odpowiedzialna za podglosnienie danej sciezki dzwiekowej.
     *
     */

    public void louder() {
        float[] left = audio.getLeftChannel();
        float[] right = audio.getRightChannel();

        for(int i=0; i < left.length; i++) {
            if (left[i] >= 0) left[i] = (float)(Math.pow(left[i], .8));
            else left[i] = (float)(-1*(Math.pow(Math.abs(left[i]), .8)));
        }
        for(int i=0; i < right.length; i++) {
            if (right[i] >= 0) right[i] = (float)(Math.pow(right[i], .8));
            else right[i] = (float)(-1*(Math.pow(Math.abs(right[i]), .8)));
        }

        audio.setLeftChannel(left);
        audio.setRightChannel(right);

        historia.add("podgłośnienie");
    }

    /**
     * Metoda ktorej zadaniem jest dodanie efektu echo w wczytanym pliku dzwiekowym.
     *
     */
    public void addEcho() {
        float[] left = audio.getLeftChannel();
        float[] right = audio.getRightChannel();

        for(int i = 44100/8; i < left.length; i++)
            left[i] = (float).25*left[i] + (float).75*left[i-44100/8];
        for(int i = 44100/8; i < right.length; i++)
            right[i] = (float).25*right[i] + (float).75*right[i-44100/8];

        audio.setLeftChannel(left);
        audio.setRightChannel(right);
        historia.add("echo");
    }
    /**
     * Metoda przyciszajaca glosnosc danego pliku dzwiekowego.
     *
     */

    public void quiet() {
        float[] left = audio.getLeftChannel();
        float[] right = audio.getRightChannel();

        for(int i=0; i < left.length; i++) left[i] = left[i]/2;
        for(int i=0; i < right.length; i++) right[i] = right[i]/2;

        audio.setLeftChannel(left);
        audio.setRightChannel(right);

        historia.add("przyciszenie");
    }
    /**
     * Metoda ktora znieksztalca sciezke dzwiekowa.
     *
     */
    public void distort() {
        float[] left = audio.getLeftChannel();
        float[] right = audio.getRightChannel();

        for(int i=0; i < left.length; i++) left[i] = Math.abs(left[i]);
        for(int i=0; i < left.length; i++) right[i] = Math.abs(right[i]);

        audio.setLeftChannel(left);
        audio.setRightChannel(right);
        historia.add("zniekształcenie");
    }


    /**
     * Metoda, w ktorej za pomoca konstrukcji switch wywolywane sa metody odpowiedzialne za
     * modyfikacje, zatrzymanie ale rowniez odtworzenie oraz zapis wczytanego pliku dzwiekowego.
     *
     */
    public void playMusic() {
         this.audio = new Audio(soundFile);
        final int play = 1, louder = 2, quiet = 3, stop = 4, playTimeStamp = 5, distord = 6, faster = 7, reverse = 8, saveFile = 9, addEcho = 10, undo = 11, exit = 12;
        Scanner myObj = new Scanner(System.in);


        try {

                while (true) {

                    System.out.println("Wybierz opcje: ");
                    System.out.println("1 - Puść,  " + "2 -  Glosniej,  " + "3 - Ciszej,  " + "4 -  Zatrzymaj,  " + "5 - Puść od momentu");
                    System.out.println("6 - Zniekształcenie,  " + "7 - Szybciej,  " + "8 - Odwróć,  " + "9 - Zapisz,  " + "10 - Dodaj echo,  " + "11 - Cofnij zmiane,  " + "12 - Wyjdz");

                    String lista = String.join(" -> ",  historia);
                    if(historia.size()!=0) {
                        System.out.append("Historia modyfikacji: " + lista + "\n");
                    }
                    try {
                        int option = myObj.nextInt();
                        if (option < 13 && option > 0) {
                            switch (option) {
                                case play:
                                    audio.play();

                                    break;

                                case louder:
                                    audio.stop();
                                    addStack(audio);
                                    louder();

                                    break;

                                case quiet:
                                    audio.stop();
                                    addStack(audio);
                                    quiet();

                                    break;

                                case stop:
                                    audio.stop();
                                    break;
                                case playTimeStamp:
                                    System.out.println("Podaj wartosc");
                                    audio.stop();
                                    long moment = myObj.nextLong();
                                    try {
                                        audio.playTime(moment);
                                    } catch (InputMismatchException e) {
                                        System.out.println(e);
                                        System.out.println("Nie wpisano cyfry, sprobuj ponownie");
                                    }
                                    break;

                                case distord:
                                    audio.stop();
                                    addStack(audio);
                                    distort();

                                    break;

                                case faster:
                                    audio.stop();
                                    addStack(audio);
                                    fasterNH();


                                    break;

                                case reverse:
                                    audio.stop();
                                    addStack(audio);
                                    reverse();

                                    break;
                                case saveFile:
                                    System.out.println("Podaj nazwe");
                                    String a = myObj.next();

                                    audio.save(a);
                                    break;

                                case addEcho:
                                    audio.stop();
                                    addStack(audio);
                                    addEcho();
                                    break;

                                case undo:
                                    audio.stop();
                                    wczytaj();
                                    break;

                                case exit:
                                    audio.stop();
                                    System.out.println("Ending");
                                    System.exit(0);
                                    break;
                            }

                        } else {
                            System.out.println("Podaj liczbe od 1 do 12");
                        }
                    } catch (InputMismatchException e) {
                        System.out.println(e);
                        System.out.println("Nie wpisano liczby" + " \nProsze sprobowac ponownie");
                        System.exit(0);
                    }
                }



        } catch (Exception ex) {

            ex.printStackTrace();

        }
    }
}
