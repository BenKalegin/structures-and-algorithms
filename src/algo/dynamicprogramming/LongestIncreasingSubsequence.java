package algo.dynamicprogramming;

public class LongestIncreasingSubsequence {

    private int solve(int[] numbers) {
        int n = numbers.length;
        int dp[] = new int[n];

        dp[0] = 1;
        int best = 1;
        for(int i = 1; i < n; i++) {
            dp[i] = numbers[i] > numbers[i-1] ? dp[i-1] + 1 : 1;
            if (dp[i] > best)
                best = dp[i];
        }
        return best;
    }

    public void test() {
        System.out.println(solve(new int[]{10, 22, 9, 33, 21, 50, 41, 60, 80} ));
    }
}
