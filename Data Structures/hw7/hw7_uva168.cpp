#include<iostream>
#include<string>
#include<vector>

using namespace std;

vector<vector<int>> map;
int c;
int step;
vector<bool> candle;

void dfs(int m, int t)
{
	if (step && step % c == 0)
	{
		cout << char(t + 'A') << " ";
		candle[t] = true;
	}


	for (auto& i : map[m])
	{
		if (!candle[i] && i != t)
		{
			step++;
			dfs(i, m);
			return;
		}
	}
	cout << '/' << char(m + 'A') << '\n';
}

int main()
{
	string input;
	while (cin >> input && input != "#")
	{
		map.assign(26, vector<int>());
		candle.assign(26, false);
		step = 0;
		for (int i = 0; i < input.length(); ++i)
		{
			if (input[i] == ':')
			{
				int j = i + 1;
				while (input[j] != ';' && input[j] != '.')
				{
					map[input[i - 1] - 'A'].push_back(input[j] - 'A');
					++j;
				}
			}
		}
		char mch, tch;
		cin >> mch >> tch >> c;
		int m = mch - 'A', t = tch - 'A';
		dfs(m, t);
	}
	return 0;
}