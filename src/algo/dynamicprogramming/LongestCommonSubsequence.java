package algo.dynamicprogramming;

public class LongestCommonSubsequence {
    public LongestCommonSubsequence() {
    }

    public int find(String s1, String s2) {
        // dp[i,j] =  (s1[i] == s2[j]) ? dp[i=1, j-1] + 1 : max(dp[i-1, j], dp[i, j-1])
        int m = s1.length();
        int n = s2.length();
        int state[][] = new int[m+1][n+1];

        for (int i = 0; i <= m; i++)
            for (int j = 0; j <= n; j++) {
                state[i][j] = (i == 0 || j == 0) ? 0
                : (s1.charAt(i-1) == s2.charAt(j-1)) ? state[i-1][j-1] + 1
                : Math.max(state[i-1][j], state[i][j-1]);
            }
        return state[m][n];
    }
}
