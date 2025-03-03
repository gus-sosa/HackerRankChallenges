package BetweenTwoSets;

import java.io.*;
import java.util.*;
import java.util.stream.*;

public class BetweenTwoSets {
    public static void main(String[] args) throws IOException {
        runTest(List.of(2, 6), List.of(24, 36), 2);
        runTest(List.of(2, 4), List.of(16, 32, 96), 3);
    }

    private static void runTest(List<Integer> l1, List<Integer> l2, int expectedResult) {
        System.out.println("======START TEST========");
        String l1String = l1.stream()
                .map(String::valueOf)
                .collect(Collectors.joining(","));
        System.out.println("List l1 elements: " + l1String);
        String l2String = l2.stream()
                .map(String::valueOf)
                .collect(Collectors.joining(","));
        System.out.println("List l2 elements: " + l2String);
        System.out.println("Expected result: " + expectedResult);
        try {
            int result = Result.getTotalX(l1, l2);
            if (expectedResult == result) {
                System.out.println("----PASSED");
            } else {
                System.out.println(String.format("----FAILED: expected=[%d] and result=[%d]", expectedResult, result));
            }
        } catch (Exception e) {
            System.out.println(String.format("---ERROR: %s", e.getMessage()));
        }
        System.out.println("======END TEST========");
    }
}