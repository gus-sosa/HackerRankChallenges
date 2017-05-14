from functools import cmp_to_key

class Player:
    def __init__(self, name, score):
        self.name = name
        self.score = score

    def __repr__(self):
        return repr((self.score,self.name))

    def comparator(a, b):
        cmpResult=-(0 if a.score==b.score else (1 if a.score>b.score else -1))
        if cmpResult!=0:
            return cmpResult
        return 0 if a.name==b.name else (1 if a.name>b.name else -1)

n = int(input())
data = []
for i in range(n):
    name, score = input().split()
    score = int(score)
    player = Player(name, score)
    data.append(player)

data = sorted(data, key=cmp_to_key(Player.comparator))
for i in data:
    print(i.name, i.score)
