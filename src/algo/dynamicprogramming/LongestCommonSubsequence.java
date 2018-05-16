package algo.dynamicprogramming;

public class LongestCommonSubsequence {
    public void test() {
        String s1 = "AGGTAB", s2 = "GXTXAYB";

        System.out.println(find(s1, s2));
    }

    public String find(String s1, String s2) {
        // dp[i,j] =  (s1[i] == s2[j]) ? dp[i=1, j-1] + 1 : max(dp[i-1, j], dp[i, j-1])
        int m = s1.length();
        int n = s2.length();
        String state[][] = new String[m+1][n+1];

        for (int i = 0; i <= m; i++)
            for (int j = 0; j <= n; j++) {
                state[i][j] = (i == 0 || j == 0) ? ""
                : (s1.charAt(i-1) == s2.charAt(j-1)) ? state[i-1][j-1] + s1.charAt(i-1)
                : state[i-1][j].length() > state[i][j-1].length() ? state[i-1][j] : state[i][j-1];
            }
        return state[m][n];
    }
}
