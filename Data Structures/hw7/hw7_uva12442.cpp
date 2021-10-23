#include<iostream>
#include<vector>
#include<climits>

using namespace std;

vector<int> addr;
vector<bool> visited, dfsV;

int dfs(int u)
{
	if (dfsV[u]) return 0;
	visited[u] = dfsV[u] = true;
	return 1 + dfs(addr[u]);
}

int main()
{
	int t, n, Case = 0;
	cin >> t;
	while (t--)
	{
		cin >> n;

		addr.assign(n + 1, 0);

		int u, v;
		for (int i = 0; i < n; ++i)
		{
			cin >> u >> v;
			addr[u] = v;
		}

		visited.assign(n + 1, false);
		int max = INT_MIN;
		int maxA;
		for (int i = 1; i <= n; ++i)
		{
			if (visited[i])
				continue;
			dfsV.assign(n + 1, false);
			int l = dfs(i);
			if (l > max) max = l, maxA = i;
		}

		cout << "Case " << ++Case << ": " << maxA << '\n';
	}
	return 0;
}