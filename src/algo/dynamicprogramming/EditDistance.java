package algo.dynamicprogramming;

public class EditDistance {
    public void test() {
        String s1 = "sunday";
        String s2 = "saturday";
         //       i--^

        // 00+00
        // 00-00
        // 00100

        System.out.println(solve(s1, s2));

    }

    private int solve(String s1, String s2) {
        int[][] dp = new int[s1.length()+1][s2.length()+1];

        for(int i1 = 0; i1 <= s1.length(); i1++)
            for(int i2 = 0; i2 <= s2.length(); i2++) {
                if (i1 == 0) // nothing left of s1
                    dp[i1][i2] = i2;
                else if (i2 == 0) // nothing left of s1
                    dp[i1][i2] = i1;
                else if (s1.charAt(i1-1) == s2.charAt(i2-1))
                    dp[i1][i2] = dp[i1-1][i2-1];
                else
                    dp[i1][i2] = 1 + min(dp[i1-1][i2], dp[i1-1][i2-1], dp[i1][i2-1]);
            }
        return dp[s1.length()][s2.length()];
    }


    private int min(int i1, int i2, int i3) {
        return Math.min(i1, Math.min(i2, i3));
    }

}
