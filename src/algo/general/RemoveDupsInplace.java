package algo.general;

import java.util.HashSet;

public class RemoveDupsInplace {
    public void test() {
        String s = "asdfsdgaf";
        char[] chars = s.toCharArray();
        String result = new String(chars, 0, removeDups(chars));
        System.out.println(s);
        System.out.println(result);
    }

    private int removeDups(char[] s) {
        HashSet<Character> seenChars = new HashSet<>();
        int length = 0;
        for (int i = 0; i < s.length; i++) {
            char c = s[i];
            if (!seenChars.contains(c)) {
                seenChars.add(c);
                s[length++] = c;
            }
        }
        return length;

    }
}
