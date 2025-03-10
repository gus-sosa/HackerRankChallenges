package SubarrayDivision;

import java.util.List;

public class SubarrayDivision {
    public static void main(String[] args) {
        List<Integer> s = List.of(1, 2, 1, 3, 2);
        int d = 3;
        int m = 2;
        int expectedResult = 2;
        int result = SubarrayDivision.birthday(s, d, m);
        if (result == expectedResult) {
            System.out.println("PASSED");
        } else {
            System.out.println("FAILED");
        }
    }

    public static int birthday(List<Integer> s, int d, int m) {
        int count = 0;
        int currentSum = 0;
        for (int i = 0; i < m && i < s.size(); i++) {
            currentSum += s.get(i);
        }
        if (currentSum == d) {
            count++;
        }
        for (int i = m; i < s.size(); i++) {
            currentSum = currentSum - s.get(i - m) + s.get(i);
            if (currentSum == d) {
                count++;
            }
        }
        return count;
    }
}