using System;
using System.IO;

class Solution {

  class SinglyLinkedListNode {
    public int data;
    public SinglyLinkedListNode next;

    public SinglyLinkedListNode(int nodeData) {
      this.data = nodeData;
      this.next = null;
    }
  }

  class SinglyLinkedList {
    public SinglyLinkedListNode head;
    public SinglyLinkedListNode tail;

    public SinglyLinkedList() {
      this.head = null;
      this.tail = null;
    }

    public void InsertNode(int nodeData) {
      SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

      if (this.head == null) {
        this.head = node;
      } else {
        this.tail.next = node;
      }

      this.tail = node;
    }
  }

  static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter) {
    while (node != null) {
      textWriter.Write(node.data);

      node = node.next;

      if (node != null) {
        textWriter.Write(sep);
      }
    }
  }

  // Complete the findMergeNode function below.

  /*
   * For your reference:
   *
   * SinglyLinkedListNode {
   *     int data;
   *     SinglyLinkedListNode next;
   * }
   *
   */
  static int findMergeNode(SinglyLinkedListNode head1, SinglyLinkedListNode head2) {
    int result = -1;
    while (head1 != null && result == -1) {
      if (isInList(head1, head2)) {
        result = head1.data;
      }
      head1 = head1.next;
    }
    return result;
  }

  private static bool isInList(SinglyLinkedListNode node, SinglyLinkedListNode listHead) {
    while (listHead != null) {
      if (node == listHead) {
        return true;
      }
      listHead = listHead.next;
    }
    return false;
  }

  static void Main(string[] args) {
    TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

    int tests = Convert.ToInt32(Console.ReadLine());

    for (int testsItr = 0; testsItr < tests; testsItr++) {
      int index = Convert.ToInt32(Console.ReadLine());

      SinglyLinkedList llist1 = new SinglyLinkedList();

      int llist1Count = Convert.ToInt32(Console.ReadLine());

      for (int i = 0; i < llist1Count; i++) {
        int llist1Item = Convert.ToInt32(Console.ReadLine());
        llist1.InsertNode(llist1Item);
      }

      SinglyLinkedList llist2 = new SinglyLinkedList();

      int llist2Count = Convert.ToInt32(Console.ReadLine());

      for (int i = 0; i < llist2Count; i++) {
        int llist2Item = Convert.ToInt32(Console.ReadLine());
        llist2.InsertNode(llist2Item);
      }

      SinglyLinkedListNode ptr1 = llist1.head;
      SinglyLinkedListNode ptr2 = llist2.head;

      for (int i = 0; i < llist1Count; i++) {
        if (i < index) {
          ptr1 = ptr1.next;
        }
      }

      for (int i = 0; i < llist2Count; i++) {
        if (i != llist2Count - 1) {
          ptr2 = ptr2.next;
        }
      }

      ptr2.next = ptr1;

      int result = findMergeNode(llist1.head, llist2.head);

      textWriter.WriteLine(result);
    }

    textWriter.Flush();
    textWriter.Close();
  }
}