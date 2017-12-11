package algo.dynamicprogramming;

import java.util.Arrays;

public class LargestSumContiguousSubarray {
    private int solve(int[] numbers) {
        // recurrence: dp[i] = a[i] + dp[i-1] > 0 ? dp[i-1] : 0

        int n = numbers.length;
        int[] dp = new int[n];

        dp[0] = numbers[0];
        for(int i = 1; i < numbers.length; i++) {
            if (dp[i-1] >= 0)
                dp[i] = dp[i-1] + numbers[i];
            else
                dp[i] = numbers[i];
        }
        return Arrays.stream(dp).max().getAsInt();
    }

    public void test() {
        int[] numbers = new int[] {-2, -3, 4, -1, -2, 1, 5, -3};
        System.out.println("Lasrgest sum for array " + numbers.toString() + " is " + solve(numbers));
    }
}
