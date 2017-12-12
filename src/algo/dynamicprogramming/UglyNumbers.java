package algo.dynamicprogramming;

import java.util.HashMap;

public class UglyNumbers {
    private boolean isUgly(int n, HashMap<Integer, Boolean> knownUglyNumbers) {
        Boolean cached = knownUglyNumbers.get(n);
        if (cached != null)
            return cached;

        boolean result = false;

        if (n % 2 == 0) {
            result = isUgly(n / 2, knownUglyNumbers);
        }
        else if (n % 3 == 0)
            result = isUgly(n/3, knownUglyNumbers);
        if (n % 5 == 0)
            return isUgly(n/5, knownUglyNumbers);

        knownUglyNumbers.put(n, result);
        return result;
    }

    private int solve(int n) {
        // Ugly numbers are numbers whose only prime factors are 2, 3 or 5.
        // The sequence 1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, … shows the first 11 ugly numbers.
        // By convention, 1 is included.
        // Given a number n, the task is to find n’th Ugly number.`

        int uglyNumber = 1;
        HashMap<Integer, Boolean> knownUglyNumbers = new HashMap<>();
        knownUglyNumbers.put(1, true);

        if (n == 1)
            return 1;

        for (int i = 2; i < n*n; i++)
            if (isUgly(i, knownUglyNumbers)) {
                if (++uglyNumber == n)
                    return i;
            }
        throw new RuntimeException("unexpected");
    }

    public void test() {
        System.out.println("5: "  + solve(5));
        System.out.println("6: "  + solve(6));
        System.out.println("150: "  + solve(150));
    }
}
