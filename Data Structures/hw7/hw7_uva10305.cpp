#include<iostream>
#include<vector>
#include<list>

using namespace std;

vector<int> g[101];
bool link[101];
bool visited[101];
list<int> o;

void dfs(int t)
{
	if (visited[t]) return;
	visited[t] = true;
	for (auto& i : g[t])
		dfs(i);
	o.push_front(t);
}

int main()
{
	int n, m, a, b;
	while (cin >> n >> m && (n || m))
	{
		fill(g, g + 101, vector<int>());
		fill(link, link + 101, false);
		fill(visited, visited + 101, false);
		o.clear();

		for (int i = 0; i < m; ++i)
		{
			cin >> a >> b;
			g[a].push_back(b);
			link[b] = true;
		}

		for (int i = 1; i <= n; ++i)
			if (!link[i])
				dfs(i);

		cout << o.front();
		for (auto it = ++o.begin(); it != o.end(); ++it)
			cout << " " << *it;
		cout << '\n';
	}
	return 0;
}