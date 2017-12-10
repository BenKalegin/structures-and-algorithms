package algo.dynamicprogramming;

import java.util.Arrays;

public class MinimumStepsToOne {
    // On a positive integer, you can perform any one of the following 3 steps.
    // 1.) Subtract 1 from it.  ( n = n - 1 )  ,
    // 2.) If its divisible by 2, divide by 2. ( if n % 2 == 0 , then n = n / 2  )
    // 3.) If its divisible by 3, divide by 3. ( if n % 3 == 0 , then n = n / 3  ).
    // Now the question is, given a positive integer n, find the minimum number of steps that takes n to 1
    //  eg: 1.)For n = 1 , output: 0  2.) For n = 4 , output: 2  ( 4  /2 = 2  /2 = 1 )    3.)  For n = 7 , output: 3  (  7  -1 = 6   /3 = 2   /2 = 1 )

    private int minPath(int number, int[] dp) {
        if (number == 1)
            return 0;

        if (dp[number] == 0) {
            dp[number] = minPath(number-1, dp);
            if (number % 2 == 0)
                dp[number] = Math.min(dp[number], minPath(number / 2, dp));
            if (number % 3 == 0)
                dp[number] = Math.min(dp[number], minPath(number / 3, dp));
            dp[number]++;
        }
        return dp[number];
    }

    private int solve(int number) {
       // top down

        // recurrency dp[n] = min(dp[n-1], dp[n/2]?, d[[n/3]]) + 1
        int[] dp = new int[number+1]; // problem could be big allocation
        return minPath(number, dp);
    }

    public void test() {
        System.out.println( 11 + " -> " + solve(11));
        System.out.println( 12 + " -> " + solve(12));
        System.out.println( 13 + " -> " + solve(13));
    }

}
