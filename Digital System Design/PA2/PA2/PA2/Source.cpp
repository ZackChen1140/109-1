#include<iostream>
#include<fstream>
using namespace std;

void outPut11(int r)
{
    if (r == 0)
        cout << "2 0 2 2" << endl;
    if (r == 1)
        cout << "0 2 2 2" << endl;
    if (r == 2)
        cout << "2 1 2 2" << endl;
    if (r == 3)
        cout << "1 2 2 2" << endl;
}
void outPut12(int r)
{
    if (r == 0)
        cout << "0 2 2 2" << endl;
    if (r == 1)
        cout << "2 1 2 2" << endl;
    if (r == 2)
        cout << "1 2 2 2" << endl;
    if (r == 3)
        cout << "2 0 2 2" << endl;

}
void outPut21(int c)
{
    if (c == 0)
        cout << "2 2 2 0" << endl;
    if (c == 1)
        cout << "2 2 0 2" << endl;
    if (c == 2)
        cout << "2 2 2 1" << endl;
    if (c == 3)
        cout << "2 2 1 2" << endl;
}
void outPut22(int c)
{
    if (c == 0)
        cout << "2 2 0 2" << endl;
    if (c == 1)
        cout << "2 2 2 1" << endl;
    if (c == 2)
        cout << "2 2 1 2" << endl;
    if (c == 3)
        cout << "2 2 2 0" << endl;
}
void outPut31(int r)
{
    if (r == 0)
        cout << "0 0 2 2" << endl;
    if (r == 1)
        cout << "0 1 2 2" << endl;
    if (r == 2)
        cout << "1 1 2 2" << endl;
    if (r == 3)
        cout << "1 0 2 2" << endl;
}
void outPut32(int c)
{
    if (c == 0)
        cout << "2 2 0 0" << endl;
    if (c == 1)
        cout << "2 2 0 1" << endl;
    if (c == 2)
        cout << "2 2 1 1" << endl;
    if (c == 3)
        cout << "2 2 1 0" << endl;
}
void outPut33(int r, int c)
{
    if (r == 0)
    {
        if (c == 0)
            cout << "2 0 2 0" << endl;
        if (c == 1)
            cout << "2 0 0 2" << endl;
        if (c == 2)
            cout << "2 0 2 1" << endl;
        if (c == 3)
            cout << "2 0 1 2" << endl; 
    }
    if (r == 1)
    {
        if (c == 0)
            cout << "0 2 2 0" << endl;
        if (c == 1)
            cout << "0 2 0 2" << endl;
        if (c == 2)
            cout << "0 2 2 1" << endl;
        if (c == 3)
            cout << "0 2 1 2" << endl;
    }
    if (r == 2)
    {
        if (c == 0)
            cout << "2 1 2 0" << endl;
        if (c == 1)
            cout << "2 1 0 2" << endl;
        if (c == 2)
            cout << "2 1 2 1" << endl;
        if (c == 3)
            cout << "2 1 1 2" << endl;
    }
    if (r == 3)
    {
        if (c == 0)
            cout << "1 2 2 0" << endl;
        if (c == 1)
            cout << "1 2 0 2" << endl;
        if (c == 2)
            cout << "1 2 2 1" << endl;
        if (c == 3)
            cout << "1 2 1 2" << endl;
    }

}
void outPut34(int r, int c)
{
    if (r == 0)
    {
        if (c == 0)
            cout << "2 0 0 2" << endl;
        if (c == 1)
            cout << "2 0 2 1" << endl;
        if (c == 2)
            cout << "2 0 1 2" << endl;
        if (c == 4)
            cout << "2 0 2 0" << endl;
    }
    if (r == 1)
    {
        if (c == 0)
            cout << "0 2 0 2" << endl;
        if (c == 1)
            cout << "0 2 2 1" << endl;
        if (c == 2)
            cout << "0 2 1 2" << endl;
        if (c == 4)
            cout << "0 2 2 0" << endl;
    }
    if (r == 2)
    {
        if (c == 0)
            cout << "2 1 0 2" << endl;
        if (c == 1)
            cout << "2 1 2 1" << endl;
        if (c == 2)
            cout << "2 1 1 2" << endl;
        if (c == 4)
            cout << "2 1 2 0" << endl;
    }
    if (r == 3)
    {
        if (c == 0)
            cout << "1 2 0 2" << endl;
        if (c == 1)
            cout << "1 2 2 1" << endl;
        if (c == 2)
            cout << "1 2 1 2" << endl;
        if (c == 4)
            cout << "1 2 2 0" << endl;
    }
}
void outPut35(int r, int c)
{
    if (r == 0)
    {
        if (c == 0)
            cout << "0 2 2 0" << endl;
        if (c == 1)
            cout << "0 2 0 2" << endl;
        if (c == 2)
            cout << "0 2 2 1" << endl;
        if (c == 3)
            cout << "0 2 1 2" << endl;
    }
    if (r == 1)
    {
        if (c == 0)
            cout << "2 1 2 0" << endl;
        if (c == 1)
            cout << "2 1 0 2" << endl;
        if (c == 2)
            cout << "2 1 2 1" << endl;
        if (c == 3)
            cout << "2 1 1 2" << endl;
    }
    if (r == 2)
    {
        if (c == 0)
            cout << "1 2 2 0" << endl;
        if (c == 1)
            cout << "1 2 0 2" << endl;
        if (c == 2)
            cout << "1 2 2 1" << endl;
        if (c == 3)
            cout << "1 2 1 2" << endl;
    }
    if (r == 3)
    {
        if (c == 0)
            cout << "2 0 2 0" << endl;
        if (c == 1)
            cout << "2 0 0 2" << endl;
        if (c == 2)
            cout << "2 0 2 1" << endl;
        if (c == 3)
            cout << "2 0 1 2" << endl;
    }
}
void outPut36(int r,int c)
{
    if (r == 0)
    {
        if(c==0)
            cout << "0 2 0 2" << endl;
        if(c==1)
            cout << "0 2 2 1" << endl;
        if(c==2)
            cout << "0 2 1 2" << endl;
        if(c==4)
            cout << "0 2 2 0" << endl;
    }
    if (r == 1)
    {
        if (c == 0)
            cout << "2 1 0 2" << endl;
        if (c == 1)
            cout << "2 1 2 1" << endl;
        if (c == 2)
            cout << "2 1 1 2" << endl;
        if (c == 4)
            cout << "2 1 2 0" << endl;
    }
    if (r == 2)
    {
        if (c == 0)
            cout << "1 2 0 2" << endl;
        if (c == 1)
            cout << "1 2 2 1" << endl;
        if (c == 2)
            cout << "1 2 1 2" << endl;
        if (c == 4)
            cout << "1 2 2 0" << endl;
    }
    if (r == 3)
    {
        if (c == 0)
            cout << "2 0 0 2" << endl;
        if (c == 1)
            cout << "2 2 2 1" << endl;
        if (c == 2)
            cout << "2 2 1 2" << endl;
        if (c == 4)
            cout << "2 2 2 0" << endl;
    }
}
int main()
{
	ifstream inFile("Case1", ios::in);
    if (!inFile)
    {
        cout << "File count not be find\n";
        exit(0);
    }
    char s;
    inFile.read((char*)(&s), sizeof(char));
    int sInt = s - '0';
    for (int i = 0; i < sInt; ++i)
    {
        cout << "#" << i + 1 << endl;
        char kMap[4][4] = {
        '1','0','1','1',
        '0','1','1','0', 
        '0','1','1','0', 
        '1','1','1','1'};
        /*for(int r=0;r<4;++r)
            for(int c=0;c<4;++c)
                inFile.read((char*)(&kMap[r][c]), sizeof(char));*/
        bool cont = 1;
        char orinum = kMap[3][3];
        for (int r = 0; r < 4; ++r)
            for (int c = 0; c < 4; ++c)
            {
                if (kMap[r][c] == '0')
                    kMap[3][3] = '0';
                if (r == 3 && c == 3 && kMap[3][3] == '1')
                {
                    cout << "2 2 2 2" << endl;
                    cont = 0;
                }
                    
            }
        if (!cont)
            continue;
        kMap[3][3] = orinum;
        for (int r = 0; r < 4; ++r)
            for (int c = 0; c < 4; ++c)
            {
                if (kMap[r][c] == '1')
                {
                    //橫的8個上
                    bool circle = 0;
                    for (int ri = 0; ri < 4; ri += 3)
                    {
                        bool isZero = 0;
                        for (int ci = 0; ci < 4; ++ci)
                            if (kMap[(r + ri) % 4][(c + ci) % 4] == '0')
                            {
                                isZero = 1;
                                break;
                            }
                        if (isZero)
                            break;
                        if (ri)
                        {
                            outPut11(r);
                            for (int r2 = 0; r2 < 4; r2 += 3)
                                for (int c2 = 0; c2 < 4; ++c2)
                                    kMap[(r + r2) % 4][(c + c2) % 4] = '2';
                            circle = 1;
                        }
                    }
                    if (circle)
                        continue;
                    //橫的8個下
                    for (int ri = 0; ri < 2; ++ri)
                    {
                        bool isZero = 0;
                        for (int ci = 0; ci < 4; ++ci)
                            if (kMap[(r + ri) % 4][(c + ci) % 4] == '0')
                            {
                                isZero = 1;
                                break;
                            }
                        if (isZero)
                            break;
                        if (ri)
                        {
                            outPut12(r);
                            for (int r2 = 0; r2 < 2; ++r2)
                                for (int c2 = 0; c2 < 4; ++c2)
                                    kMap[(r + r2) % 4][(c + c2) % 4] = '2';
                            circle = 1;
                        }   
                    }
                    if (circle)
                        continue;
                    //直的8個左
                    for (int ci = 0; ci < 4; ci+=3)
                    {
                        bool isZero = 0;
                        for (int ri = 0; ri < 4; ++ci)
                            if (kMap[(r + ri) % 4][(c + ci) % 4] == '0')
                            {
                                isZero = 1;
                                break;
                            }
                        if (isZero)
                            break;
                        if (ci)
                        {
                            outPut21(c);
                            for (int c2 = 0; c2 < 4; c2 += 3)
                                for (int r2 = 0; r2 < 4; ++r2)
                                    kMap[(r + r2) % 4][(c + c2) % 4] = '2';
                            circle = 1;
                        }
                    }
                    if (circle)
                        continue;
                    //直的8個右
                    for (int ci = 0; ci < 2; ++ci)
                    {
                        bool isZero = 0;
                        for (int ri = 0; ri < 4; ++ci)
                            if (kMap[(r + ri) % 4][(c + ci) % 4] == '0')
                            {
                                isZero = 1;
                                break;
                            }
                        if (isZero)
                            break;
                        if (ci)
                        {
                            outPut22(c);
                            for (int c2 = 0; c2 < 2; ++c2)
                                for (int r2 = 0; r2 < 4; ++r2)
                                    kMap[(r + r2) % 4][(c + c2) % 4] = '2';
                            circle = 1;
                        } 
                    }
                    if (circle)
                        continue;
                    //橫4個
                    bool isZeroO = 0;
                    for (int ci = 0; ci < 4; ++ci)
                        if (kMap[r][(c + ci) % 4] == '0')
                        {
                            isZeroO = 1;
                            break;
                        }
                    if (!isZeroO)
                    {
                        outPut31(r);
                        for (int c2 = 0; c2 < 4; ++c2)
                            kMap[r][(c + c2) % 4] = '2';
                        circle = 1;
                    }
                    if (circle)
                        continue;
                    //直4個
                    isZeroO = 0;
                    for (int ri = 0; ri < 4; ++ri)
                        if (kMap[(r+ri)%4][c] == '0')
                        {
                            isZeroO = 1;
                            break;
                        }
                    if (!isZeroO)
                    {
                        outPut32(c);
                        for(int r2=0;r2<4;++r2)
                            kMap[(r+r2)%4][c] = '2';
                        circle = 1;
                    }
                    isZeroO = 0;
                    if (circle)
                        continue;
                    //左上4個
                    for (int ri = 0; ri < 4; ri+=3)
                    {
                        bool isZero = 0;
                        for (int ci = 0; ci < 4; ci += 3)
                        {
                            if (kMap[(r + ri) % 4][(c + ci) % 4] == '0')
                            {
                                isZero = 1;
                                break;
                            }
                        }
                        if (isZero)
                            break;
                        if (ri)
                        {
                            outPut33(r, c);
                            for (int r2 = 0; r2 < 4; r2+=3)
                                for (int c2 = 0; c2 < 4; c2+=3)
                                    kMap[(r + r2) % 4][(c + c2) % 4] = '2';
                            circle = 1;
                        }
                    }
                    if (circle)
                        continue;
                    //右上4個
                    for (int ri = 0; ri < 4; ri += 3)
                    {
                        bool isZero = 0;
                        for (int ci = 0; ci < 2; ++ci)
                            if (kMap[(r + ri) % 4][(c + ci) % 4] == '0')
                            {
                                isZero = 1;
                                break;
                            }
                        if (isZero)
                            break;
                        if (ri)
                        {
                            outPut34(r, c);
                            for (int r2 = 0; r2 < 4; r2 += 3)
                                for (int c2 = 0; c2 < 2; ++c2)
                                    kMap[(r + r2) % 4][(c + c2) % 4] = '2';
                            circle = 1;
                        }
                    }
                    if (circle)
                        continue;
                    //左下4個
                    for (int ri = 0; ri < 2; ++ri)
                    {
                        bool isZero = 0;
                        for (int ci = 0; ci < 4; ci+=3)
                            if (kMap[(r + ri) % 4][(c + ci) % 4] == '0')
                            {
                                isZero = 1;
                                break;
                            }
                        if (isZero)
                            break;
                        if (ri)
                        {
                            outPut35(r, c);
                            for (int r2 = 0; r2 < 2; ++r2)
                                for (int c2 = 0; c2 < 4; c2+=3)
                                    kMap[(r + r2) % 4][(c + c2) % 4] = '2';
                            circle = 1;
                        }
                    }
                    if (circle)
                        continue;
                    //右下4個
                    for (int ri = 0; ri < 2; ++ri)
                    {
                        bool isZero = 0;
                        for (int ci = 0; ci < 2; ++ci)
                            if (kMap[(r + ri) % 4][(c + ci) % 4] == '0')
                            {
                                isZero = 1;
                                break;
                            }
                        if (isZero)
                            break;
                        if (ri)
                        {
                            outPut36(r, c);
                            for (int r2 = 0; r2 < 2; ++r2)
                                for (int c2 = 0; c2 < 2; ++c2)
                                    kMap[(r + r2) % 4][(c + c2) % 4] = '2';
                            circle = 1;
                        }
                    }
                    if (circle)
                        continue;
                    //橫的2個
                    
                    
                }
            }

    }
}