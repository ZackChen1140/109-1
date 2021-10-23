#include<iostream>
#include<string>
#include<vector>
#include<list>

using namespace std;

vector<vector<int>> g(26, vector<int>());
int pri[26] = {};//1沒有大於其他，2有大於其他
list<char> o;
bool visited[26] = {};

void dfs(int c)
{
	if (visited[c]) return;
	visited[c] = true;
	for (auto& i : g[c])
		dfs(i);
	o.push_front(c + 'A');
}

int main()
{
	string s1, s2;
	cin >> s1;
	while (cin >> s2 && s2 != "#")
	{
		int l = min(s1.length(), s2.length());
		for (int i = 0; i < l; ++i)
		{
			if (!pri[s1[i] - 'A']) pri[s1[i] - 'A'] = 1;
			if (!pri[s2[i] - 'A']) pri[s2[i] - 'A'] = 1;
			if (s1[i] != s2[i])
			{
				g[s1[i] - 'A'].push_back(s2[i] - 'A');
				pri[s2[i] - 'A'] = 2;
				break;
			}
		}
		s1 = s2;
	}

	for (int i = 0; i < 26; ++i)
		if (pri[i] == 1)
			dfs(i);

	for (auto& i : o)
		cout << i;
	cout << '\n';
	return 0;
}