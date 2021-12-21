from operator import itemgetter


def main():
    chunks = input().split()
    n = int(chunks[0])  # какой пришла
    m = int(chunks[1])  # после нее пришли
    rank = n - 1
    before = [0] * rank
    after = []

    for i in range(rank):
        before[i] = int(input())
    input()  # ввод неинтересного для нас время обслуживания самой АДы

    for j in range(m):
        chunks = input().split()
        after.append(
            tuple(
                [
                    int(chunks[0]),
                    int(chunks[1]),
                    int(chunks[2])
                ]
            )
        )

    curr = -1  # позиция прохода по BEFORE-списку
    past = 0
    time = 0
    after.sort(key=itemgetter(1))

    for person in after:
        index = person[0]

        while past <= person[1] and curr < rank:
            curr += 1
            past += before[curr]

        if curr + index >= rank or index == -1:
            continue

        if curr == rank:
            break

        before[index + curr] += person[2]

    for el in before:
        time += el
        print(time)

    print(time)
    return


if __name__ == '__main__':
    main()
