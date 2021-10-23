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
	int n;
	while (cin >> n)
	{
		if (!n)
			break;
		priority_queue<int, vector<int>, greater<int>> numbers;
		int num;
		while (n--)
		{
			cin >> num;
			numbers.push(num);
		}
		int cost = 0;
		while (numbers.size() > 1)
		{
			int top = numbers.top();
			numbers.pop();
			top += numbers.top();
			numbers.pop();
			cost += top;
			numbers.push(top);
		}
		cout << cost << '\n';
	}
	return 0;
}