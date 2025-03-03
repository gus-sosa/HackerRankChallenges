package BetweenTwoSets;

import java.util.Collections;
import java.util.List;

public class Result {
    /*
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     * 1. INTEGER_ARRAY a
     * 2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<Integer> a, List<Integer> b) {
        Integer minInB = getMinInList(b);
        int count = 0;
        for (int i = 1; i <= minInB; i++) {
            if (satisfyA(i, a) && satisfayB(i, b)) {
                count++;
            }
        }
        return count;
    }

    private static boolean satisfayB(int num, List<Integer> b) {
        for (Integer v : b) {
            if (v % num != 0) {
                return false;
            }
        }
        return true;
    }

    private static boolean satisfyA(int num, List<Integer> a) {
        for (Integer v : a) {
            if (num % v != 0) {
                return false;
            }
        }
        return true;
    }

    private static Integer getMinInList(List<Integer> b) {
        return Collections.min(b);
    }
}
