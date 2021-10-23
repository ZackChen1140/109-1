#include<iostream>
#include<list>
#include<string>

using namespace std;

static auto __ = []
{
	ios_base::sync_with_stdio(false);
	cin.tie(0);
	cout.tie(0);
	return 0;
}();

int main()
{
	string input;
	while (getline(cin, input) && !input.empty())
	{
		list<char> output;
		auto it = output.end();
		for (size_t i = 0; i < input.length(); ++i)
		{
			if (input[i] == '[')
				it = output.begin();
			else if (input[i] == ']')
				it = output.end();
			else
				output.insert(it, input[i]);//不需要++it,因為insert的元素會在it前
		}

		for (auto& i : output)
			cout << i;
		cout << '\n';
	}
	return 0;
}