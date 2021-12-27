from math import pi, sqrt, cos, acos, sin
''''
    1    2
    1.0   0.0  0.0
    0.0   0.0  2.0
'''


def main():
    chunks = input().split()
    r = int(chunks[0])  # радиус основания
    h = int(chunks[1])  # высота конуса
    O = (0, 0, 0)  # центр основания и СК
    V = (0, 0, h)  
    L = sqrt(r**2 + h**2)
    
    chunks = input().split()
    pt1 = tuple(
        [
            float(chunks[0]),
            float(chunks[1]),
            float(chunks[2])
        ]
    )
    chunks = input().split()
    pt2 = tuple(
        [
            float(chunks[0]),
            float(chunks[1]),
            float(chunks[2])
        ]
    )

    def near_point_arc(p):
        cos_P = p[0] / on_plane(p, O)
        sin_P = p[1] / on_plane(p, O)
        np = (cos_P * r, sin_P * r, 0)
        return np

    def middle_arc(p1, p2):
        angle_C1 = acos(p1[0] / r)
        if p1[1] < 0:
            angle_C1 = 2 * pi - angle_C1
        angle_C2 = acos(p2[0] / r)
        if p2[1] < 0:
            angle_C2 = 2 * pi - angle_C2

        angle_C = (angle_C1 + angle_C2) / 2
        c = (cos(angle_C) * r, sin(angle_C) * r, 0)
        return c

    def flank(p1, p2):
        d1 = on_space(p1, V)
        d2 = on_space(p2, V)
        if p1 == V or p2 == V:
            return d1 + d2

        # cosA = ((Op1')^2 + (Op2')^2 - p1'p2') / 2* Op1' * Op2'
        # O - центр основания, p1' - проекция точки p1 на основание
        alpha = acos((on_plane(p1, O) ** 2 + on_plane(p2, O) ** 2 - on_plane(p1, p2) ** 2) /
                     (2 * on_plane(p1, O) * on_plane(p2, O)))
        if alpha > pi:
            alpha = 2 * pi - alpha
        psi = alpha * r / L
        return sqrt(d1 ** 2 + d2 ** 2 - 2 * d1 * d2 * cos(psi))

    def flank_plus_base(p1, p2):
        # 1й arg-боковая, 2й- в основании, иначе меняем местами
        if p2[2] != 0:
            p1, p2 = p2, p1

        if p2 == O:  # (0, 0, 0)
            return r + L - on_space(p1, V)

        c1 = near_point_arc(p1)
        c2 = near_point_arc(p2)

        path1 = flank(p1, c1) + on_plane(p2, c1)
        path2 = flank(p1, c2) + on_plane(p2, c2)

        while abs(path1 - path2) >= 0.00000001:
            if path1 < path2:
                c2 = middle_arc(c1, c2)
                path2 = flank(p1, c2) + on_plane(p2, c2)
            else:
                c1 = middle_arc(c1, c2)
                path1 = flank(p1, c1) + on_plane(p2, c1)

        return min(path1, path2)

    def third_case(p1, p2):
        # А) flank()
        path0 = flank(p1, p2)

        # B) 2_flank+base(), когда точки боковой близко от основания
        c1 = near_point_arc(p1)
        c2 = near_point_arc(p2)
        c2 = middle_arc(c1, c2)

        path1 = flank(p1, c1) + flank_plus_base(p2, c1)
        path2 = flank(p1, c2) + flank_plus_base(p2, c2)

        while abs(path1-path2) > 0.00000001:
            if path1 < path2:
                c2 = middle_arc(c1, c2)
                path2 = flank(p1, c2) + flank_plus_base(p2, c2)
            else:
                c1 = middle_arc(c1, c2)
                path1 = flank(p1, c1) + flank_plus_base(p2, c1)

        return min(path0, path1, path2)

    # 2 точки в основании конуса
    if pt1[2] == 0 and pt2[2] == 0:
        return on_plane(pt1, pt2)

    # 1 в основании, 1 на боковой
    elif (pt1[2] == 0) ^ (pt2[2] == 0):
        if pt1 == V or pt2 == V:
            return L + r - on_plane(pt1, O) - on_plane(pt2, O)

        return flank_plus_base(pt1, pt2)

    # 2 точки на боковой поверхности
    else:
        if pt1 == V or pt2 == V:
            return on_space(pt1, pt2)

        return third_case(pt1, pt2)


def on_plane(a, b):
    return sqrt((a[0]-b[0])**2 + (a[1]-b[1])**2)


def on_space(a, b):
    return sqrt((a[0]-b[0])**2 + (a[1]-b[1])**2 + (a[2]-b[2])**2)


if __name__ == '__main__':
    print('%.8f' % main())
