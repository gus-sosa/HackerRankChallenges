package main

import (
	"bufio"
	"fmt"
	"io"
	"os"
	"strconv"
	"strings"
)

/*
 * Complete the 'isBalanced' function below.
 *
 * The function is expected to return a STRING.
 * The function accepts STRING s as parameter.
 */

func isBalanced(s string) string {
	st := make([]int32, 0)
	for _, v := range s {
		if isOpen(v) {
			st = push(st, v)
		} else {
			if len(st) == 0 {
				return "NO"
			}
			top, newst := pop(st)
			st = newst
			if !isMatch(top, v) {
				return "NO"
			}
		}
	}
	if len(st) > 0 {
		return "NO"
	}
	return "YES"
}

func isOpen(v int32) bool {
	return v == int32("("[0]) || v == int32("["[0]) || v == int32("{"[0])
}

func isMatch(open, close int32) bool {
	return (open == int32("("[0]) && close == int32(")"[0])) || (open == int32("["[0]) && close == int32("]"[0])) || (open == int32("{"[0]) && close == int32("}"[0]))
}

func push(s []int32, v int32) []int32 {
	return append(s, v)
}

func pop(s []int32) (int32, []int32) {
	retVal := s[len(s)-1]
	s = s[0 : len(s)-1]
	return retVal, s
}

func main() {
	reader := bufio.NewReaderSize(os.Stdin, 16*1024*1024)

	stdout, err := os.Create(os.Getenv("OUTPUT_PATH"))
	checkError(err)

	defer stdout.Close()

	writer := bufio.NewWriterSize(stdout, 16*1024*1024)

	tTemp, err := strconv.ParseInt(strings.TrimSpace(readLine(reader)), 10, 64)
	checkError(err)
	t := int32(tTemp)

	for tItr := 0; tItr < int(t); tItr++ {
		s := readLine(reader)

		result := isBalanced(s)

		fmt.Fprintf(writer, "%s\n", result)
	}

	writer.Flush()
}

func readLine(reader *bufio.Reader) string {
	str, _, err := reader.ReadLine()
	if err == io.EOF {
		return ""
	}

	return strings.TrimRight(string(str), "\r\n")
}

func checkError(err error) {
	if err != nil {
		panic(err)
	}
}
