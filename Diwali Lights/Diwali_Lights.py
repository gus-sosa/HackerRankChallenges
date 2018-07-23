def getValue(n):
    return (2**n-1)%100000

t=int(input())
while t>0:
    t-=1
    n=int(input())
    print(getValue(n))
