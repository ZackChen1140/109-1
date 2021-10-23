#include<iostream>
#include<vector>

using namespace std;

static auto __ = []()
{
	std::ios_base::sync_with_stdio(false);
	std::cin.tie(nullptr);
	std::cout.tie(nullptr);
	return 0;
}();

int main()
{
	int n;
	cin >> n;
	while (n--)
	{
		int snowN;
		cin >> snowN;
		vector<int> snows;
		int snow, maxsnow = 0;
		while (snowN--)
		{
			cin >> snow;
			for (size_t i = 0; i < snows.size(); ++i)//­n¥Îsize_t «z¹À¥À¨aWhy
			{
				if (snows[i] == snow)
				{
					if (snows.size() > maxsnow)
						maxsnow = snows.size();
					vector<int> newSnows;
					for (++i; i < snows.size(); ++i)
						newSnows.emplace_back(snows[i]);
					snows = newSnows;
					break;
				}
			}
			snows.emplace_back(snow);
		}
		if (snows.size() > maxsnow)
			maxsnow = snows.size();
		cout << maxsnow << '\n';
	}
	return 0;
}