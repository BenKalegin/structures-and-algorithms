package algo.general;

import java.util.BitSet;
import java.util.HashSet;

/*
    Remove Alternate Duplicate characters from a char array you have to do it in Place.Like keeping only the odd occurences of each character.
 */
public class RemoveAlternateDuplicateChars {
    public void test() {
        String input = "you got beautiful eyes";
        String expected = "you gtbeaifules";

        char[] chars = input.toCharArray();
        int length = removeDups(chars);
        System.out.println("Expected: " + expected);
        System.out.println("Result  : " + new String(chars, 0, length));
    }

    private int removeDups(char[] s) {
        if (s == null || s.length == 0)
            return 0;


        int writeIndex = 0;
        BitSet seenChars = new BitSet();

        for (int readIndex = 0; readIndex < s.length; readIndex++) {
            Character c = s[readIndex];
            if (seenChars.get(c))
                continue;
            System.out.printf("adding %s at the %d\n", c, writeIndex);
            seenChars.set(c);
            s[writeIndex++] = c;
        }
        return writeIndex;
    }
}
