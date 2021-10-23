#include<iostream>
#include<vector>
#include<stack>
#include<string>

using namespace std;

static auto __ = []
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);
	cout.tie(0);
	return 0;
}();

void add(vector<stack<char>>& v, char ch)
{
	for (auto& i : v)
	{
		if (ch <= i.top())
		{
			i.emplace(ch);
			return;
		}
	}

	stack<char> s;
	s.emplace(ch);
	v.emplace_back(s);
	return;
}

int main()
{
	string input;
	int Case = 0;
	while (cin >> input && input != "end")
	{
		vector<stack<char>> v;
		for (int i = 0; i < input.length(); ++i)
			add(v, input[i]);
		cout << "Case " << ++Case << ": " << v.size() << '\n';
	}
	return 0;
}