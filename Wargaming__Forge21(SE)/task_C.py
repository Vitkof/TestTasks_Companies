from dataclasses import dataclass

''''
    3  2  4  1  1
    2  2  3  3
    1  2
    2  3
'''
INF = 0x3F3F3F3F  # константа-бесконечность
# для каждой вершины i в graph[i] хранятся номера рёбер, выходящих из неё
graph = {}

# все рёбра лежат в общем списке rows
rows = []
src, drain = (-1, 99), (0, 0)
n, m, k, a, b = map(int, input().split())

# наихудшее время, когда все K чел. на N этаже, и N-1 пары лифтов
TIME = 2*n + k - m - 2
prev = {}
dist = {}


def read_lifts():
    lst = []
    for j in range(m):  # номер пары лифтов
        A, B = map(int, input().split())
        if A < B:       # [(2, 1), (3, 2)]
            A, B = B, A
        lst.append((A, B))
    return lst


@dataclass
class Row:
    u: tuple
    v: tuple
    cap: int
    cost: int
    flow: int


def available(i):
    return rows[i].cap - rows[i].flow


def target(i):
    return rows[i].v


def source(i):
    return rows[i].u


def cost(i):
    return rows[i].cost


def add_row(tm, u, v, cap, cst):
    r1 = Row((tm, u), (tm+1, v), cap, cst, 0)
    r2 = Row((tm+1, v), (tm, u), 0, -cst, 0)
    graph[(tm, u)].append(len(rows))
    rows.append(r1)
    graph[(tm+1, v)].append(len(rows))
    rows.append(r2)


def add_lift_rows(tm, lst):
    for l in lst:
        for ppl in range(k):
            # мн-во ребер обозначающее лифтовую перевозку
            # 2 чел. в лифте - это 2 ребра с весами b, 3b из {b, 3b, 5b, 7b...2k-b}
            add_row(tm, l[0], l[1], 1, ppl * 2 + b)

            if l[1] != 1:  # с 1 на N этаж ребро ненужно
                add_row(tm, l[1], l[0], 1, ppl*2 + b)


def add_drain_row(tm):
    if tm != 0:
        r1 = Row((tm, 1), drain, INF, tm * a, 0)
        r2 = Row(drain, (tm, 1), 0, -tm * a, 0)
        graph[(tm, 1)].append(len(rows))
        rows.append(r1)
        graph[drain].append(len(rows))
        rows.append(r2)


def add_waiting_rows(tm):
    for u in range(2, n+1):
        add_row(tm, u, u, INF, 0)


def add_rows_from_source(lst):
    for v in set(lst):
        add_row(-1, 99, v, lst.count(v), 0)


def path_cost(path):
    return sum(map(cost, path))


def restore_path(u):
    path = []
    while prev[u] is not None:
        r = prev[u]
        path.append(r)
        u = source(r)
    return path


def path_capacity(path):
    return min(map(available, path))


def push(i, flw):
    rows[i].flow += flw
    rows[i^1].flow -= flw


def push_path(path, flw):
    for row_i in path:
        push(row_i, flw)


def find_path(s):
    dist[s] = 0

    for i in range(n):

        for r in range(len(rows)):
            u = source(r)
            v = target(r)
            w = cost(r)

            if dist[u] is not None and available(r) > 0:
                if dist[v] is None or dist[v] > dist[u] + w:
                    dist[v] = dist[u] + w
                    prev[v] = r


def main():

    if n < 2 or n > 50:
        return 'введено N не из диапазона [2, 50]'
    if m < n - 1 or m > 50:
        return 'введено M не из диапазона [n-1, 50]'
    if k < 1 or k > 50:
        return 'введено K не из диапазона [1, 50]'
    if a < 1 or a > 50:
        return 'введено A не из диапазона [1, 50]'
    if b < 1 or b > 50:
        return 'введено B не из диапазона [1, 50]'

    def build_network():
        add_rows_from_source(floor_numbers)
        for i in range(TIME):
            add_drain_row(i)
            if i < TIME-1:  # в посл. i_времени не нужны ребра лифтов и ожиданий вниз
                add_waiting_rows(i)
                add_lift_rows(i, lifts)

    def busacker_gowen(s, t):
        res_flow = 0
        res_cost = 0

        while True:
            prev.update({s: None, t: None})
            dist.update({s: None, t: None})
            for tm in range(TIME):
                for v in range(1, n + 1):
                    prev[(tm, v)] = None
                    dist[(tm, v)] = None

            find_path(s)
            if dist[t] is None:
                break

            path = restore_path(t)
            flow = path_capacity(path)
            pcost = path_cost(path)
            push_path(path, flow)
            res_flow += flow
            res_cost += flow * pcost

        return res_cost

    floor_numbers = list(map(int, input().split()))
    lifts = read_lifts()
    graph[src] = []
    graph[drain] = []
    for ti in range(TIME):
        for flr in range(1, n + 1):
            graph[(ti, flr)] = []
    del graph[(0, 1)]
    build_network()
    print(busacker_gowen(src, drain))


if __name__ == '__main__':
    main()
