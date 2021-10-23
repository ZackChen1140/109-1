#include<iostream>
#include<list>
#include<unordered_map>

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
	int p, c, n = 0;
	while (cin >> p >> c)
	{
		if (!p || !c)
			break;
		list<int> seq;
		unordered_map<int, list<int>::iterator> numberP;
		for (int i = 0; i < (p > c ? c : p); ++i)
			numberP[i + 1] = seq.insert(seq.end(), i + 1);

		cout << "Case " << ++n << ":\n";
		char action;
		while (c--)
		{
			cin >> action;
			if (action == 'N')
			{
				cout << seq.front() << '\n';
				numberP[seq.front()] = seq.insert(seq.end(), seq.front());
				seq.erase(seq.begin());
			}
			else if (action == 'E')
			{
				int number;
				cin >> number;
				if (numberP.find(number) != numberP.end())
					seq.erase(numberP[number]);
				numberP[number] = seq.insert(seq.begin(), number);
			}
		}
	}
}