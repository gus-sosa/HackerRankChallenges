package BreakingTheRecords;

import java.util.Arrays;
import java.util.List;

public class BreakingTheRecords {
    public static void main(String[] args) {
        runTest(List.of(12, 24, 10, 24), 1, 1);
        runTest(List.of(10, 5, 20, 20, 4, 5, 2, 25, 1), 2, 4);
    }

    private static void runTest(List<Integer> list, int expectedResultMax, int expectedResultMin) {
        System.out.println("=====START TEST========");
        String listString = String.join(", ", list.stream().map(String::valueOf).toArray(String[]::new));
        System.out.println("---list: " + listString);
        System.out.println("---expectedResultMax: " + expectedResultMax);
        System.out.println("---expectedResultMin: " + expectedResultMin);
        try {
            List<Integer> result = Result.breakingRecords(list);
            if (result.get(0) == expectedResultMax && result.get(1) == expectedResultMin) {
                System.out.println("---->PASSED");
            } else {
                System.out.println("---->FAILED, result="
                        + String.join(",", result.stream().map(i -> i.toString()).toArray(String[]::new)));
            }
        } catch (Exception e) {
            System.out.println("--->ERROR: " + e.getMessage());
        }
        System.out.println("=====END TEST========");
    }
}