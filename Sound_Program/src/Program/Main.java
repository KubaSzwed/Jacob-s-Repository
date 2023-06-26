package Program;

import javax.swing.*;
import java.awt.*;
import java.io.File;

public class Main {
    /**
     *
     *  Fukcja pozwalajaca na wybranie sciezki do pliku recznie
     *
     */
    public static String getFile() {
        String pathname = null;
        FileDialog fd = new FileDialog(new JFrame("Wybierz plik .wav"));
        fd.setVisible(true);
        File[] f = fd.getFiles();
        if (f.length > 0) {
            pathname = (fd.getFiles()[0].getAbsolutePath());
        }
        if (pathname != null && pathname.endsWith(".wav")) {
        }
        if (pathname!=null) {
            return pathname;
        }else{return "zły plik";}
    }


    public static void main(String[] args) {
        String filename;
        while(true) {
            filename = getFile();

            if(filename.endsWith(".wav")){break;}
            System.out.println("Wybierz plik z rozszerzeniem .wav");
        }
        musicStaff musicObject;
        musicObject = new musicStaff();
        musicObject.setSoundFile(filename);
        musicObject.playMusic();

    }

}

