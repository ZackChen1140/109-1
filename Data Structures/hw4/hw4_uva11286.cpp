#include<iostream>
#include<vector>
#include<unordered_map>
#include<string>
#include<algorithm>

using namespace std;

string combineCN(vector<string>& classNum)
{
	string sortedStr;
	sort(classNum.begin(), classNum.end());
	for (auto& it : classNum)
		sortedStr += it;

	return sortedStr;
}

int main()
{
	int n;
	while (cin >> n && n)
	{
		unordered_map<string, int> classes;
		vector<string> classNum(5);
		for (int i = 0; i < n; ++i)
		{
			for (int j = 0; j < 5; ++j)
				cin >> classNum[j];
			++classes[combineCN(classNum)];
		}

		int max = 0;
		int total = 0;
		for (auto& it : classes)
		{
			if (it.second > max)
			{
				max = it.second;
				total = max;
			}
			else if (it.second == max)
				total += max;
		}
		cout << total << '\n';
	}
	return 0;
}