#define _USE_MATH_DEFINES

#include<iostream>
#include<fstream>
#include<cmath>
#include<sstream>
#include<iomanip>
#include<list>
#include<queue>

using namespace std;

const int N = 4096;
const float PI = M_PI;

void bitrp(float xreal[], float ximag[], int n);
void FFT(float xreal[], float ximag[], int n);

int main(int argc, char* argv[])
{
    //ifstream inFile("ex2.csv", ios::in);
    ifstream inFile(argv[1], ios::in);
    list<queue<float>> iv;

    string s1, s2;
    float p;
    while (inFile >> s1)
    {
        queue<float> v;
        stringstream ss1;
        ss1 << s1;
        while (getline(ss1, s2, ','))
        {
            stringstream ss2;
            ss2 << s2;
            ss2 >> p;
            v.emplace(p);
        }
        iv.emplace_back(v);
    }

    int data = 0;
    for (auto& i : iv)
    {
        cout << "Data " << ++data << " :\n";
        float xreal[N] = {}, ximag[N] = {};
        int size = i.size();
        for (int j = 0; j < size; ++j)
            xreal[j] = i.front(), i.pop();
        FFT(xreal, ximag, size);
        for (int j = 0; j < size; ++j)
            cout << setprecision(4) << fixed << xreal[j] << " " << ximag[j] << '\n';
        if (i != iv.back())
            cout << '\n';
    }
    return 0;
}

void bitrp(float xreal[], float ximag[], int n)
{
    int i, j, a, b, p;

    for (i = 1, p = 0; i < n; i *= 2)
        ++p;
    for (i = 0; i < n; ++i)
    {
        a = i, b = 0;
        for (j = 0; j < p; ++j)
            b = (b << 1) + (a & 1), a >>= 1;
        if (b > i)
            swap(xreal[i], xreal[b]), swap(ximag[i], ximag[b]);
    }
}

void FFT(float xreal[], float ximag[], int n)
{
    float wreal[N / 2], wimag[N / 2], treal, timag, ureal, uimag, arg;
    int m, k, j, t, index1, index2;

    bitrp(xreal, ximag, n);

    arg = -2 * PI / n;
    treal = cos(arg), timag = sin(arg);
    wreal[0] = 1, wimag[0] = 0;
    for (j = 1; j < n / 2; ++j)
        wreal[j] = wreal[j - 1] * treal - wimag[j - 1] * timag, wimag[j] = wreal[j - 1] * timag + wimag[j - 1] * treal;

    for (m = 2; m <= n; m *= 2)
        for (k = 0; k < n; k += m)
            for (j = 0; j < m / 2; ++j)
            {
                t = n * j / m;

                index1 = k + j, index2 = index1 + m / 2;
                treal = wreal[t] * xreal[index2] - wimag[t] * ximag[index2];
                timag = wreal[t] * ximag[index2] + wimag[t] * xreal[index2];
                ureal = xreal[index1], uimag = ximag[index1];
                xreal[index1] = ureal + treal, ximag[index1] = uimag + timag;
                xreal[index2] = ureal - treal, ximag[index2] = uimag - timag;
            }
}