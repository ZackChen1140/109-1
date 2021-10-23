#include<iostream>
#include<queue>
#include<string>
#include<climits>

using namespace std;

static auto __ = []
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);
	cout.tie(0);
	return 0;
}();

int main()
{
	int testN;
	cin >> testN;
	int n, t, m;
	while (testN--)
	{
		cin >> n >> t >> m;
		queue<pair<int, int>> q[2];
		vector<int> arriveTime(m);
		int T;
		string location;
		for (int i = 0; i < m; ++i)
		{
			cin >> T >> location;
			location == "left" ? q[0].emplace(i, T) : q[1].emplace(i, T);
		}

		int ferryLoc = 0, time = 0;
		while (!q[0].empty() || !q[1].empty())
		{
			//這段背下來
			int closest = INT_MAX;
			if (!q[0].empty()) closest = q[0].front().second;
			if (!q[1].empty()) closest = min(closest, q[1].front().second);
			time = max(time, closest);

			//記得不能超過最大乘載量
			int carN = 0;
			while (!q[ferryLoc].empty() && carN < n && q[ferryLoc].front().second <= time)
			{
				arriveTime[q[ferryLoc].front().first] = time + t;
				q[ferryLoc].pop();
				++carN;
			}


			ferryLoc = (ferryLoc + 1) % 2;
			time += t;
		}
		for (int i = 0; i < m; ++i)
			cout << arriveTime[i] << '\n';
		if (testN)
			cout << '\n';
	}
	return 0;
}