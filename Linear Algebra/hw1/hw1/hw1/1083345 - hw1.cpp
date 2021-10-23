#include<iostream>
#include<fstream>
#include<cmath>

using namespace std;

char get_word(char binaryNum[8])
{
	char word = 0;
	for (int i = 0; i < 8; ++i)
	{
		word += (binaryNum[i] + 1) * pow(2, 7 - i);
	}
	if (word < 32 || word>126)
		word = NULL;
	return word;
}

int main(int argc, char* argv[])
{
	ifstream fin;
	fin.open("test1.bmp", ios::binary);
	fin.seekg(54, ios::beg);//14 + 40;

	char b[8];
	int i = 0;
	while (fin.get(b[i]).get(b[i]).get(b[i]))
	{
		if (i == 7)
		{
			if (get_word(b) == NULL)break;
			else cout << get_word(b);
			i = 0;
		}
		else
			++i;
	}
	return 0;
}