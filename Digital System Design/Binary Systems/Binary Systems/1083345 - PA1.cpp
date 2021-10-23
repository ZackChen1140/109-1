#include<iostream>
#include<string>
#include<cmath>
#include<vector>
using namespace std;

char n[62] = { '0','1','2','3','4','5','6','7','8','9'
,'A','B','C','D','E','F','G','H','I','J','K', 'L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
,'a','b','c','d','e', 'f','g','h','i','j','k','l','m','n','o', 'p','q','r','s','t','u','v','w','x','y', 'z' };


bool rNumCheck(string rNum, int r)
{
	for (int i = 0; i < rNum.length(); ++i)
		if (rNum[i] >= n[r])
			return false;
	return true;
}

string rNumConvert(string rNum)
{
	int t = 0;
	for (int i = 0; i < rNum.length(); ++i)
	{
		if (rNum[i] > 64)
		{
			if (rNum[i] > 96)
				rNum[i] -= 6;
			rNum[i] -= 7;
		}
		rNum[i] += t;
		t = (rNum[i] - '0') / 10;
		rNum[i] = (rNum[i] % 10) + '0';
		if (i == rNum.length() - 1 && t > 0)
		{
			string rNumP;
			rNumP.resize(rNum.length() * 2);
			for (int j = 0; j < rNumP.length(); ++j)
			{
				if (j < rNum.length())
					rNumP[j] = rNum[j];
				else
					rNumP[j] = 0;
			}
			rNum = rNumP;
		}
	}
	while (rNum[rNum.length() - 1] == 0)
		rNum.pop_back();
	return rNum;
}

int main()
{
	string rNum;
	int decimalNum;
	int mode;
	int r;
	do
	{
		cout << ">>r is ";
		cin >> r;
	} while (r < 2 || r>62);
	while (true)
	{
		do
		{
			cout << ">>Which mode?\n>>";
			cin >> mode;
		} while (mode < 0 || mode>1);
		if (mode)
		{
			do
			{
				cout << ">>Value ?\n>>";
				cin >> rNum;
			} while(!rNumCheck(rNum, r));
			string rNumP = rNum;
			for (int i = 0; i < rNum.length(); ++i)
				rNumP[i] = rNum[rNum.length() - i - 1];
			rNum = rNumConvert(rNumP);
			/*int ans = 0;
			for (int i = rNum.length() - 1; i >= 0; --i)
				for (int j = 0; j < 63; ++j)
					if (rNum[i] == n[j])
						ans += j * pow(r, rNum.length() - i - 1);*/
			cout << ">>Result: ";
			for (int i = rNum.length() - 1; i >= 0; --i)
				cout << rNum[i];
			cout << endl;

		}
		else
		{
			do
			{
				cout << ">>Value ?\n<<";
				cin >> decimalNum;
			} while (decimalNum < 1);
			vector<char> ans;
			int ansSize = 1;
			while (decimalNum != 0)
			{
				ans.resize(ansSize);
				ans[ansSize - 1] = n[decimalNum % r];
				decimalNum /= r;
				++ansSize;
			}
			--ansSize;
			cout << ">>Result: ";
			for (int i = ansSize - 1; i >= 0; --i)
				cout << ans[i];
			cout << endl;
		}
	}
	return 0;
}
