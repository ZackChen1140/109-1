#include<iostream>
#include<queue>
#include<vector>

using namespace std;

int main()
{
	int n;
	cin >> n;
	int b, sg, sb;
	while (n--)
	{
		cin >> b >> sg >> sb;
		priority_queue<int> sgq, sbq;
		int inp;
		for (int i = 0; i < sg; ++i)
		{
			cin >> inp;
			sgq.push(inp);
		}
		for (int i = 0; i < sb; ++i)
		{
			cin >> inp;
			sbq.push(inp);
		}

		while (!sgq.empty() && !sbq.empty())
		{
			vector<int> battle;
			for (int i = 0; i < b; ++i)
			{
				if (sgq.empty() || sbq.empty())
					break;
				battle.emplace_back(sgq.top() - sbq.top());
				sgq.pop(), sbq.pop();
			}
			for (auto& it : battle)
			{
				if (it > 0)
					sgq.push(it);
				else if (it < 0)
					sbq.push(-it);
			}
		}

		if (sgq.empty() && sbq.empty())
			cout << "green and blue died\n";
		else if (sgq.empty())
		{
			cout << "blue wins\n";
			while (!sbq.empty())
			{
				cout << sbq.top() << '\n';
				sbq.pop();
			}
		}
		else if (sbq.empty())
		{
			cout << "green wins\n";
			while (!sgq.empty())
			{
				cout << sgq.top() << '\n';
				sgq.pop();
			}
		}
		if (n)
			cout << '\n';
	}
	return 0;
}