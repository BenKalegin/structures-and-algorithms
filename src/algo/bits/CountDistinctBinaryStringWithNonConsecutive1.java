package algo.bits;

import java.util.stream.Collectors;

/**
 * Given a positive integer N, count all possible distinct binary strings of length N such that there are no consecutive 1’s.
 */
public class CountDistinctBinaryStringWithNonConsecutive1 {

    public void test() {

        printResults(1);
        printResults(2);
        printResults(3);
        printResults(4);
        printResults(5);
    }

    private void printResults(int n) {
        long recursiveResult = findRecursive(n);
        long bruteforceResult = findBruteforce(n);
        long dynamicResult = findDynamic(n);
        System.out.println("" + n + " | bru: " + bruteforceResult + " rec: " + recursiveResult + " dyn: " + dynamicResult);
    }

    private long findDynamic(int n) {
        if (n == 0)
            return 0;

        // _X -> n
        // _X0 -> n
        // _X1 -> n+1 if (X) else n
        int dp1 = 1;
        int dp0 = 1;

        // dp1[i+1] = dp0[i]
        // dp0[i+1] = dp0[i] + dp1[i]

        for (int i = 2; i <= n; i++) {
            int savedp1 = dp1;
            dp1 = dp0;
            dp0 = dp0 + savedp1;
        }

        return dp0 + dp1;
    }

    private long findBruteforce(int n) {
        int result = 0;
        for (long i = 0; i < pow2(n); i++) {
            boolean priorBit = false;
            long value = i;
            for (int bit = 0; bit < n; bit++) {
                boolean lastBit = (value & 1) == 1;
                if (priorBit && lastBit) {
                    result++;
                    break;
                }
                value >>= 1;
                priorBit = lastBit;
            }
        }
        return pow2(n) - result;
    }

    private long pow2(int n) {
        return 1 << n;
    }

    private long findRecursive(int nBit) {
        //  X00  - same task 2 bit less
        //  x01 -  same task 1 bit less
        //  X10  - same task 2 bit less
        //  X11  - all rec combinations

        if (nBit == 0)
            return 1;

        if (nBit == 1)
            return 2;

        return findRecursive(nBit-2) + findRecursive(nBit-1);

        // 0 - count
        // 1
        //   0 - count
        //   1 - dont count

        //  000
        //  001
        //  010
        //  011
        //  100
        //  101
        //  110
        //  111
        //  3 -> 3
        //  0000
        //  0001
        //  0010
        //  0011
        //  0100
        //  0101
        //  0110
        //  0111
        //  1000
        //  1001
        //  1010
        //  1011
        //  1100
        //  1101
        //  1110
        //  1111
        // 4 -> 8

    }
}
