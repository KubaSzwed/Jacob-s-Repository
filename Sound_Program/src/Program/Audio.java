package Program;

import javax.sound.sampled.*;
import java.io.ByteArrayInputStream;
import java.io.File;
import java.io.IOException;
import java.io.PrintStream;

/**
 * Ta klasa odpowiada za wczytanie pliku .wav i odtworzenie go.
 *
 */
public class Audio {
    private Clip clip = null;
    private float[] right = null, left = null;
    private float sampleRate = AudioSystem.NOT_SPECIFIED; // initially unknown
    private AudioFormat desiredFormat = null; // to use during play

    public void setClip(Clip clip) {
        this.clip = clip;
    }

    /**
     * Tworzy nowy dzwiek. Plik jest odczytany.
     *
     * @param fileName
     *            Nazwa pliku .wav do przeczytania.
     */

    public Audio(String fileName) {
        File fileIn = new File(fileName);
        try {
            AudioInputStream audioInputStream = AudioSystem
                    .getAudioInputStream(fileIn);
            AudioFormat format = audioInputStream.getFormat();
            int bytesPerFrame = format.getFrameSize();
            int bitsPerSample = format.getSampleSizeInBits();
            sampleRate = format.getSampleRate();
            setupDesiredAudioFormat(sampleRate);

            if (format.getChannels() != 2) {
                System.out
                        .println("Error: can only read 2-channel (stereo) audio files");
                System.exit(1);
            }
            if (bitsPerSample != 16 && bitsPerSample != 8) {
                System.out.println("Error: can only read audio files with "
                        + "8 or 16 bits per sample, found " + bitsPerSample);
                System.exit(1);
            }

            long numBytes = audioInputStream.getFrameLength() * bytesPerFrame;
            if (numBytes > Integer.MAX_VALUE) {
                System.out.println("Error: audio file too large. Sorry.");
                System.exit(1);
            }
            byte[] audioBytes = new byte[(int) numBytes];
            int numBytesRead = 0;
            numBytesRead = audioInputStream.read(audioBytes);
            if (numBytesRead != numBytes)
                System.out.println("Warning: Unable to read entire file.  Proceeding with partial file.");
            convertToFloat(audioBytes, format);
            // dumpFloats("floats.csv"); // debug only
            // dumpBytes ("bytes.csv"); // debug only
            audioInputStream.close();
        } catch (Exception e) {
            System.out.println("Error encountered: " + e);
            System.exit(1);
        }
    }

    private void setupDesiredAudioFormat(float sampleRate) {
        desiredFormat = new AudioFormat( // to use during play
                sampleRate, // sampleRate,
                16, // sampleSizeInBits,
                2, // channels,
                true, // signed
                false // bigEndian
        );
    }

    // back to byte stream, 2 channel, 4 bytes/frame, big endian, signed
    // If left, right different sizes, use smaller
    private byte[] convertToBytes() {
        checkMaximum();
        byte[] audioBytes = new byte[left.length * 2 * 2];
        int bytePos = 0;
        if (left.length != right.length) {
            System.out
                    .println("Warning! Left and Right channels are different sizes.");
            System.out.println("Left size: " + left.length + ",  Right size: "
                    + right.length);
        }
        int size = Math.min(left.length, right.length);
        for (int i = 0; i < size; ++i) {
            short leftVal = (short) (left[i] * 32767);
            short rightVal = (short) (right[i] * 32767);
            if (desiredFormat.isBigEndian()) {
                audioBytes[bytePos++] = (byte) (leftVal >> 8); // msb
                audioBytes[bytePos++] = (byte) (leftVal & 0xFF); // lsb
                audioBytes[bytePos++] = (byte) (rightVal >> 8); // msb
                audioBytes[bytePos++] = (byte) (rightVal & 0xFF); // lsb
            } else { // littleEndian
                audioBytes[bytePos++] = (byte) (leftVal & 0xFF); // lsb
                audioBytes[bytePos++] = (byte) (leftVal >> 8); // msb
                audioBytes[bytePos++] = (byte) (rightVal & 0xFF); // lsb
                audioBytes[bytePos++] = (byte) (rightVal >> 8); // msb
            }
        }
        return audioBytes;
    }

    // to excel csv format
    @SuppressWarnings("unused")
    private void dumpFloats(String filename) {
        System.out.println("Writing samples to file " + filename);
        try {
            PrintStream writer = new PrintStream(filename);
            for (int i = 0; i < 65536; ++i)
                writer.println(i + "," + left[i] + "," + right[i]);
            writer.close();
        } catch (IOException e) {
            System.out.println("File writing failed to file: " + filename);
        }
    }

    // to excel csv format
    @SuppressWarnings("unused")
    private void dumpBytes(String filename) {
        System.out.println("Writing samples to file " + filename);
        try {
            PrintStream writer = new PrintStream(filename);
            byte[] bytes = convertToBytes();
            for (int i = 0; i < 65536 * 4; i += 4) {
                short leftSample = (short) (bytes[i] << 8 | bytes[i + 1]);
                short rightSample = (short) (bytes[i + 2] << 8 | bytes[i + 3]);
                writer.println(i / 4 + "," + leftSample + "," + rightSample);
            }
            writer.close();
        } catch (IOException e) {
            System.out.println("File writing failed to file: " + filename);
        }
    }

    /**
     * Zapisuje aktualny stan dzwieku do pliku. T
     * Zapisany plik bedzie mial dalej rozszerzenie .wav
     */
    public void save(String fileName) {

        File fileOut = new File(fileName +".wav");
        byte[] bytes = convertToBytes();
        ByteArrayInputStream byteStream = new ByteArrayInputStream(bytes);
        AudioFormat format = desiredFormat;
        AudioInputStream stream = new AudioInputStream(byteStream, format,
                bytes.length / 2 / 2);
        try {
            @SuppressWarnings("unused")
            int bytesWritten = AudioSystem.write(stream, AudioFileFormat.Type.WAVE, fileOut);
        } catch (IOException e) {
            System.out.println("Unable to write to output file " + fileName
                    + ", " + e);
        }
    }

    //Plays the current sound.
    public void play() {
        stop();
        try {
            clip = AudioSystem.getClip();
            System.gc();
            byte[] bytes = convertToBytes();
            clip.open(desiredFormat, bytes, 0, bytes.length);
            clip.start();
        } catch (LineUnavailableException e) {
            System.out.println("Cannot play: " + e);
            return;
        }
    }
    public void playTime(long Czas) {
        stop();
        try {
            clip = AudioSystem.getClip();
            System.gc();
            byte[] bytes = convertToBytes();
            clip.open(desiredFormat, bytes, 0, bytes.length);
            clip.start();
            clip.setMicrosecondPosition(Czas*1000000);
        } catch (LineUnavailableException e) {
            System.out.println("Cannot play: " + e);
            return;
        }
    }


    // Stops playing the current sound. If no sound is playing, the stop()
    // method returns without doing anything.
    public void stop() {
        if (clip != null) {
            clip.stop();
            clip.flush();
            clip.close();
            clip = null;
        }
    }






    /**
     * Pobiera lewy kanal z aktualnego dzwieku. Sample sa w
     * zakresie[-1f ... 1f]
     */
    public float[] getLeftChannel() {
        return left.clone();
    }

    /**
     * Pobiera prawy kanal z aktualnego dzwieku. Sample sa w
     * zakresie[-1f ... 1f]
     */
    public float[] getRightChannel() {
        return right.clone();
    }

    /**
     * Ustawia lewy kanal.
     *
     * @param left
     *            kolekcja sampli do uzycia w lewym kanale. Kazdy sample
     *            powinien byc z przedzialu [-1,1]
     */
    public void setLeftChannel(float[] left) {
        this.left = null; // allow garbage collection before clone is finished
        this.left = left.clone();
    }

    /**
     * Ustawia prawy kanal.
     *
     * @param right
     *            kolekcja sampli do uzycia w prawym kanale. Kazdy sample
     *            powinien byc z przedzialu [-1,1]
     */
    public void setRightChannel(float[] right) {
        this.right = null; // allow garbage collection before clone is finished
        this.right = right.clone();
    }

    // make sure both left and right are in the range of [-1..1]
    private void checkMaximum() {
        for (int i = 0; i < left.length; ++i)
            if (left[i] > 1.0f || left[i] < -1.0f) {
                System.out.println("Error: left channel element " + i
                        + " contains value " + left[i]
                        + " which is outside of the range [-1 .. 1]");
                System.exit(1);
            }
        for (int i = 0; i < right.length; ++i)
            if (right[i] > 1.0f || right[i] < -1.0f) {
                System.out.println("Error: left channel element " + i
                        + " contains value " + right[i]
                        + " which is outside of the range [-1 .. 1]");
                System.exit(1);
            }
    }

    private void convertToFloat(byte[] raw, AudioFormat format) {
        int bitsPerSample = format.getSampleSizeInBits();
        if (bitsPerSample != 8 && bitsPerSample != 16) {
            System.out
                    .println("Can only handle 8 or 16 bits per sample.  Found "
                            + bitsPerSample + ", sorry.");
            System.exit(1);
        }
        int bytesPerSample = bitsPerSample / 8;
        left = new float[raw.length / 2 / bytesPerSample]; // /2 is for 2
        // channels
        right = new float[raw.length / 2 / bytesPerSample];

        for (int i = 0, next = 0; i < raw.length; ++next) {
            byte left1, right1, left2 = 0, right2 = 0;
            left1 = raw[i++];
            if (bytesPerSample == 2)
                left2 = raw[i++];
            right1 = raw[i++];
            if (bytesPerSample == 2)
                right2 = raw[i++];
            if (bytesPerSample == 2 && !format.isBigEndian()) {
                byte temp = left1; // want left1 most significant, left2 least
                // significant
                left1 = left2;
                left2 = temp;
                temp = right1;
                right1 = right2;
                right2 = temp;
            }
            if (format.getEncoding() == AudioFormat.Encoding.PCM_SIGNED) {
                left[next] = signedByteToInt(left1, left2);
                right[next] = signedByteToInt(right1, right2);
            } else { // PCM_UNSIGNED
                left[next] = unsignedByteToInt(left1, left2);
                right[next] = unsignedByteToInt(right1, right2);
            }
        }
    }

    private static float signedByteToInt(byte b1, byte b2) {
        int sample = (b1 << 8) | (b2 & 0xFF);
        float result = sample / 32768.f;
        return result;
    }

    private static float unsignedByteToInt(byte b1, byte b2) {
        int sample = (b1 & 0xff) << 8 | (b2 & 0xff);
        float result = sample / 65535.f * 2 - 1;
        return result;
    }





}
