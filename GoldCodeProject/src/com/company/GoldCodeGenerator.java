package com.company;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.plot.PlotOrientation;
import org.jfree.data.xy.DefaultXYDataset;
import org.jfree.data.xy.XYDataset;
import org.jfree.ui.RefineryUtilities;

import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.nio.charset.StandardCharsets;
import java.util.*;


public class GoldCodeGenerator {

    private static final int[] A_TAPS = {1, 2};
    private static final int[] B_TAPS = {2, 3};

    private int[] aRegister;
    private int[] bRegister;


    public GoldCodeGenerator(int[] aSequence, int[] bSequence, int aShift, int bShift) {
        aRegister = new int[aSequence.length];
        System.arraycopy(aSequence, 0, aRegister, 0, aSequence.length);
        bRegister = new int[bSequence.length];
        System.arraycopy(bSequence, 0, bRegister, 0, bSequence.length);
        shiftRegisters(aShift, bShift);
    }

    public int[] generate(int length) {
        int[] goldCode = new int[length];
        for (int i = 0; i < length; i++) {
            int aOutput = generateAOutput();
            int bOutput = generateBOutput();
            goldCode[i] = aOutput ^ bOutput;
        }
        return goldCode;
    }

    private int generateAOutput() {
        int feedback = 0;
        for (int tap : A_TAPS) {
            feedback ^= aRegister[aRegister.length - tap];
        }
        int output = aRegister[0];
        System.arraycopy(aRegister, 1, aRegister, 0, aRegister.length - 1);
        aRegister[aRegister.length - 1] = feedback;
        return output;
    }

    private int generateBOutput() {
        int feedback = 0;
        for (int tap : B_TAPS) {
            feedback ^= bRegister[bRegister.length - tap];
        }
        int output = bRegister[0];
        System.arraycopy(bRegister, 1, bRegister, 0, bRegister.length - 1);
        bRegister[bRegister.length - 1] = feedback;
        return output;
    }


    private void shiftRegisters(int aShift, int bShift) {
        int[] aTemp = new int[aRegister.length];
        System.arraycopy(aRegister, aShift, aTemp, 0, aRegister.length - aShift);
        System.arraycopy(aRegister, 0, aTemp, aRegister.length - aShift, aShift);
        aRegister = aTemp;

        int[] bTemp = new int[bRegister.length];
        System.arraycopy(bRegister, bShift, bTemp, 0, bRegister.length - bShift);
        System.arraycopy(bRegister, 0, bTemp, bRegister.length - bShift, bShift);
        bRegister = bTemp;
    }

    private static int[] generateRandomSequence(int length) {
        int[] sequence = new int[length];
        Random random = new Random();
        for (int i = 0; i < length; i++) {
            sequence[i] = random.nextInt(2); // Generowanie losowego bitu (0 lub 1)
        }
        return sequence;
    }


    public static double[] calculateGoldAutocorrelation(int[] goldCode) {
        int codeLength = goldCode.length;
        double[] autocorrelation = new double[codeLength];

        for (int shift = 0; shift < codeLength; shift++) {
            double sum = 0;

            for (int i = 0; i < codeLength; i++) {
                sum += Math.abs(goldCode[i] * goldCode[(i + shift) % codeLength]);
            }

            autocorrelation[shift] = sum / codeLength;
        }

        return autocorrelation;
    }

    private static void generateAutocorrelationChart(int[] goldCode, int length) {
        double[] shifts = new double[length];
        double[] autocorrelation = calculateGoldAutocorrelation(goldCode);

        for (int shift = 0; shift < length; shift++) {
            int[] shiftedCode = new int[length];
            System.arraycopy(goldCode, shift, shiftedCode, 0, length - shift);
            System.arraycopy(goldCode, 0, shiftedCode, length - shift, shift);

            double correlation = Math.abs(calculateCorrelation(goldCode, shiftedCode));
            shifts[shift] = shift;
            autocorrelation[shift] = correlation;
        }

        XYDataset dataset = createDataset(shifts, autocorrelation);
        JFreeChart chart = createChart(dataset, length);

        ChartFrame frame = new ChartFrame("Autokorelacja dla kodu Golda (Długość: " + length + ")", chart);
        frame.pack();
        RefineryUtilities.centerFrameOnScreen(frame);
        frame.setVisible(true);

    }


    private static XYDataset createDataset(double[] xData, double[] yData) {
        DefaultXYDataset dataset = new DefaultXYDataset();
        double[][] seriesData = new double[2][xData.length];

        for (int i = 0; i < xData.length; i++) {
            seriesData[0][i] = xData[i];
            seriesData[1][i] = yData[i];
        }

        dataset.addSeries("Autokorelacja", seriesData);
        return dataset;
    }

    private static JFreeChart createChart(XYDataset dataset, int length) {
        JFreeChart chart = ChartFactory.createXYLineChart(
                "Autokorelacja dla kodu Golda (Długość: " + length + ")",
                "Przesunięcie",
                "Autokorelacja",
                dataset,
                PlotOrientation.VERTICAL,
                true,
                true,
                false
        );

        return chart;
    }



    public static int[] convertFileToBinary(String filePath) {
        List<Integer> binaryList = new ArrayList<>();

        try (BufferedReader reader = new BufferedReader(new InputStreamReader(new FileInputStream(filePath), StandardCharsets.UTF_8))) {
            int character;
            while ((character = reader.read()) != -1) {
                String binaryValue = Integer.toBinaryString(character);

                // Dodaj wiodące zera, jeśli liczba binarna ma mniej niż 8 bitów
                while (binaryValue.length() < 8) {
                    binaryValue = "0" + binaryValue;
                }

                for (char bitChar : binaryValue.toCharArray()) {
                    int bit = Character.getNumericValue(bitChar);
                    binaryList.add(bit);
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }

        int[] binaryArray = new int[binaryList.size()];
        for (int i = 0; i < binaryList.size(); i++) {
            binaryArray[i] = binaryList.get(i);
        }

        return binaryArray;
    }

    public static int[] encodeWithGoldCodeXOR(int[] goldCode, int[] inputSequence) {
        int[] encodedSequence = new int[inputSequence.length];
        int goldCodeLength = goldCode.length;

        for (int i = 0; i < inputSequence.length; i++) {
            int goldCodeBit = goldCode[i % goldCodeLength];
            int inputBit = inputSequence[i];

            int encodedBit = inputBit ^ goldCodeBit;
            encodedSequence[i] = encodedBit;
        }

        return encodedSequence;
    }


    public static double calculateCorrelation(int[] sequence1, int[] sequence2) {
        if (sequence1.length != sequence2.length) {
            throw new IllegalArgumentException("Sequences must have the same length");
        }

        int n = sequence1.length;
        double sumX = 0.0;
        double sumY = 0.0;
        double sumXY = 0.0;
        double sumX2 = 0.0;
        double sumY2 = 0.0;

        for (int i = 0; i < n; i++) {
            int x = sequence1[i];
            int y = sequence2[i];

            sumX += x;
            sumY += y;
            sumXY += x * y;
            sumX2 += x * x;
            sumY2 += y * y;
        }

        double numerator = n * sumXY - sumX * sumY;
        double denominator = Math.sqrt((n * sumX2 - sumX * sumX) * (n * sumY2 - sumY * sumY));

        if (denominator == 0) {
            return 0;  // Avoid division by zero
        }

        double correlation = numerator / denominator;
        return (correlation);
    }




    public static void main(String[] args) {


        String filePath = "file.txt";
        int[] readSequence = convertFileToBinary(filePath);
        System.out.println("Original Text: " + Arrays.toString(readSequence));
        System.out.println();

        int[] codeLengths = {31, 63, 127, 255, 511};


        int a = 1;
        while (a == 1) {
            System.out.println("Give number:");
            System.out.println("1: Generate Gold Code");
            System.out.println("2: Exit");

            Scanner scanner = new Scanner(System.in);
            int choice1 = scanner.nextInt();

            switch (choice1) {
                case 1:
                    int length = 31;
                    boolean validChoice = false;

                    while (!validChoice) {
                        System.out.println("Select code length:");
                        System.out.println("1. 31");
                        System.out.println("2. 63");
                        System.out.println("3. 127");
                        System.out.println("4. 255");
                        System.out.println("5. 511");

                        int choice2 = scanner.nextInt();

                        switch (choice2) {
                            case 1:
                                length = 31;
                                validChoice = true;
                                break;
                            case 2:
                                length = 63;
                                validChoice = true;
                                break;
                            case 3:
                                length = 127;
                                validChoice = true;
                                break;
                            case 4:
                                length = 255;
                                validChoice = true;
                                break;
                            case 5:
                                length = 511;
                                validChoice = true;
                                break;
                            default:
                                System.out.println("Invalid choice. Please try again.");
                                break;
                        }
                    }

                    System.out.println("Original Text: " + Arrays.toString(readSequence));
                    System.out.println();


                    int shift = new Random().nextInt(length - 0 + 1) + 0;

                    // Generowanie losowej sekwencji bitów dla rejestru A
                    int[] aSequence = generateRandomSequence(length);

                    // Generowanie losowej sekwencji bitów dla rejestru B
                    int[] bSequence = generateRandomSequence(length);

                    GoldCodeGenerator generator = new GoldCodeGenerator(aSequence, bSequence, shift, shift);
                    int[] goldCode = generator.generate(length);

                    System.out.println("Gold Code's length: " + length);
                    System.out.println("Gold Code: " + Arrays.toString(goldCode));

                    generateAutocorrelationChart(goldCode, length);

                    int[] encodedSequence = encodeWithGoldCodeXOR(goldCode, readSequence);
                    System.out.println("Encoded sequence: " + Arrays.toString(encodedSequence));

                    double autocorrelation1 = Math.abs(calculateCorrelation(readSequence, encodedSequence));
                    System.out.println("Autocorrelation of encoded sequence and Gold Code: " + autocorrelation1);
                    System.out.println();

                    System.out.println("CHANGE");

                    int[] decodedSequence = encodeWithGoldCodeXOR(goldCode, encodedSequence);

                    System.out.print("Decoded Sequence: ");
                    System.out.println("Gold Code: " + Arrays.toString(decodedSequence));

                    double autocorrelation2 = calculateCorrelation(readSequence, decodedSequence);
                    System.out.println("Autocorrelation of original text and decoded text: " + autocorrelation2);

                    System.out.println();
                    System.out.println("----------------------------------------------------------------------");
                    break;

                case 2:
                    a = 0;
                    System.out.println("THE END");
                    break;

                default:
                    System.out.println("Invalid choice. Please try again.");
                    break;
            }




            }




        }

    }
