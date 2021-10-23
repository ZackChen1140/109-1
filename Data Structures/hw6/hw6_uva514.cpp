#include<iostream>
#include<queue>
#include<stack>

using namespace std;

static auto __ = []
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);
	cout.tie(0);
	return 0;
}();

//�J����stack�A�X����queue
//���N��Jpush�iqueue
//stack�C��push��A�Y���top�ۦP�hpop���줣�P�ά���
int main()
{
	int in1;
	while (cin >> in1 && in1)
	{
		int in2;
		while (cin >> in2 && in2)
		{
			queue<int> os;
			stack<int> is;
			os.emplace(in2);
			for (int i = 1; i < in1; ++i)
				cin >> in2, os.emplace(in2);

			for (int i = 0; i < in1 + 1; ++i)
			{
				is.emplace(i);
				while (!is.empty() && !os.empty() && is.top() == os.front())
					os.pop(), is.pop();
			}

			if (os.empty())
				cout << "Yes\n";
			else
				cout << "No\n";
		}
		cout << '\n';
	}
	return 0;
}