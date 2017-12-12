package algo.dynamicprogramming;

public class LongestRepeatedSubsequence {

    private int solve(String s) {
        //"AABEBCDD" => "ABD"
        // dp[i,j] = string[i] == string[j] && i != j?  dp[i-1, j-1] :  max(dp[i-1, j], dp[i, j-1])
        int n = s.length();
        int dp[][] = new int[n][n];

        dp[0][0] = 0;
        for (int i = 0; i < n; i++)
            for(int j = 1; j < n; j++)
                dp[i][j] = s.charAt(i) == s.charAt(j) && i != j
                        ? (i > 0 ? dp[i-1][j-1]: 0) + 1
                        : Math.max(i > 0 ? dp[i-1][j] : 0, dp[i][j-1]);
        return dp[n-1][n-1];
    }

    public void test() {
        System.out.println("AABEBCDD: " + solve("AABEBCDD"));
        System.out.println("AABCEBCDD: " + solve("AABCEBCDD"));
        System.out.println("AA: " + solve("AA"));
    }

}
