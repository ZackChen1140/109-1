#include<iostream>
#include<vector>

using namespace std;

int r, c, m, n, w;
vector<vector<int>> map;

void dfs(int x, int y)
{
	if (x < 0 || x >= r || y < 0 || y >= c || map[x][y] == -1) return;

	if (map[x][y]++ != 0)
		return;

	int a = m, b = n;
	for (int i = 0; i < 2; ++i)
	{
		dfs(x + a, y + b);
		dfs(x - a, y - b);
		if (a && b)
		{
			dfs(x + a, y - b);
			dfs(x - a, y + b);
		}
		if (a == b)
			break;
		swap(a, b);
	}
}

int main()
{
	int t, Case = 0;
	cin >> t;
	while (t--)
	{
		cin >> r >> c >> m >> n >> w;
		map.assign(r, vector<int>(c));
		int wx, wy;
		while (w--)
		{
			cin >> wx >> wy;
			map[wx][wy] = -1;
		}

		dfs(0, 0);
		map[0][0]--;

		int odd = 0, even = 0;
		for (auto& i : map)
			for (auto& j : i)
				if (j > 0)
				{
					if (j % 2 == 0)
						even++;
					else
						odd++;
				}

		if (map[0][0] == 0)
			++even;

		cout << "Case " << ++Case << ": " << even << " " << odd << '\n';
	}
	return 0;
}