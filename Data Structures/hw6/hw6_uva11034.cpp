#include<iostream>
#include<queue>

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
	int inputNum;
	cin >> inputNum;
	int l, m;
	while (inputNum--)
	{
		cin >> l >> m;
		queue<int> parkVeh[2];
		int parkL;
		string sides;
		for (int i = 0; i < m; ++i)
		{
			cin >> parkL >> sides;
			sides == "left" ? parkVeh[0].push(parkL) : parkVeh[1].push(parkL);
		}

		int curPos = 0;
		int ferryMove = 0;
		while (!parkVeh[0].empty() || !parkVeh[1].empty())
		{
			int L = l * 100;
			while (!parkVeh[curPos].empty() && parkVeh[curPos].front() <= L)
				L -= parkVeh[curPos].front(), parkVeh[curPos].pop();
			curPos = (curPos + 1) % 2;
			++ferryMove;
		}
		cout << ferryMove << '\n';
	}
	return 0;
}