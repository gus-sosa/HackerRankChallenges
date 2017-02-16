"""
Detect a cycle in a linked list. Note that the head pointer may be 'None' if the list is empty.

A Node is defined as: 
"""
class Node(object):
    def __init__(self, data = None, next_node = None):
        self.data = data
        self.next = next_node

def has_cycle(head):
    visited = {}
    while head:
        visited[head]=1
        if visited.get(head.next,0) != 0:
            return True
        head = head.next
    return False

    ###I think this is a solution, but it did not work
    #if head is None:
    #    return False
    #if hasattr(head,'mark'):
    #    return True
    #head.mark=True;
    #return has_cycle(head.next)
    

if __name__=="__main__":
    a=Node(1)
    b=Node(2)
    c=Node(3)
    a.next=b
    b.next=c
    print(has_cycle(a))
    
    