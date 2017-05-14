class node:
    def __init__(self, data,left=None,right=None):
        self.data = data
        self.left = left
        self.right = right

cache = {}
def checkRec(root,min,max):
    if root is None:
        return True
    if cache.has_key(root.data) or (min != None and root.data < min) or (max != None and root.data > max):
        return False
    cache[root.data] = True
    return ((root.left == None or root.left.data < root.data) and (root.right == None or root.right.data > root.data) and checkRec(root.left,min,root.data) and checkRec(root.right,root.data,max))
    

def check_binary_search_tree_(root):
    if root is None:
        return True
    cache[root.data] = True
    return checkRec(root.left,None,root.data) and checkRec(root.right,root.data,None)

if __name__ == "__main__":
    a = node(4,node(2,node(1),node(3)),node(6,node(5),node(7)))
    print(check_binary_search_tree_(a))