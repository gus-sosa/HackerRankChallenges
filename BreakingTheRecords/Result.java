package BreakingTheRecords;

import java.util.List;

class Result {

    /*
     * Complete the 'breakingRecords' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY scores as parameter.
     */

    public static List<Integer> breakingRecords(List<Integer> scores) {
        Integer minCount = 0;
        Integer min = scores.get(0);
        Integer maxCount = 0;
        Integer max = scores.get(0);
        for (Integer val : scores) {
            if (val < min) {
                min = val;
                minCount++;
            }
            if (val > max) {
                max = val;
                maxCount++;
            }
        }
        return List.of(maxCount, minCount);
    }
}