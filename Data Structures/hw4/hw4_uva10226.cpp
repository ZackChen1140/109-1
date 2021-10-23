#include<iostream>
#include<string>
#include<map>
#include<iomanip>

using namespace std;

int main()
{
	int n;
	string space;
	string tree;
	cin >> n;
	cin.ignore();
	getline(cin, space);
	while (n--)
	{
		map<string, double> trees;
		double total = 0;
		while (getline(cin, tree) && tree != "")
		{
			++trees[tree];
			++total;
		}

		for (auto& i : trees)
			cout << i.first << " " << setprecision(4) << fixed << (i.second / total) * 100 << '\n';
		if (n)
			cout << '\n';
	}
	return 0;
}