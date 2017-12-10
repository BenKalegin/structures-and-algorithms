package algo;

import algo.backtrack.ChessKnightTour;
import algo.dynamicprogramming.LongestCommonSubsequence;
import algo.dynamicprogramming.LongestIncreasingSubsequence;
import algo.dynamicprogramming.MaximalSquareSubmatrixConsistingOfOnes;
import algo.dynamicprogramming.MinimumStepsToOne;

public class Main {

    public static void main(String[] args) {
        new MinimumStepsToOne().test();
        //new LongestIncreasingSubsequence().test();

        //new MaximalSquareSubmatrixConsistingOfOnes().test();
        //testLongestCommonSubsequence();

        if (false)
	        new ChessKnightTour(5).findPossiblePaths();
    }

    private static void testLongestCommonSubsequence() {

        String s1 = "ABCDE";
        String s2 = "CE";
        System.out.println(s1 + " " + s2 + " = " + new LongestCommonSubsequence().find(s1, s2));
    }
}

