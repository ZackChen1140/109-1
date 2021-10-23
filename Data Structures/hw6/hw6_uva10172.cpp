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

int main()
{
	int t;
	int n, s, q;
	cin >> t;
	while (t--)
	{
		cin >> n >> s >> q;
		queue<int> stations[100];
		int cargoesN, cargo;
		for (int i = 0; i < n; ++i)
		{
			cin >> cargoesN;
			for (int j = 0; j < cargoesN; ++j)
			{
				cin >> cargo;
				stations[i].emplace(cargo - 1);
			}
		}
		int minute = 0;
		stack<int> carrier;
		int pos = 0;
		while (true)
		{
			//���f�C�n�`�N�Y�Kqueue�w���A�Y��n��cargo���ت��a���i���f
			while (!carrier.empty() && (stations[pos].size() < q || carrier.top() == pos))
			{
				if (carrier.top() != pos)
					stations[pos].emplace(carrier.top());
				carrier.pop();
				++minute;
			}

			//�˳f
			while (!stations[pos].empty() && carrier.size() < s)
			{
				carrier.emplace(stations[pos].front());
				stations[pos].pop();
				++minute;
			}

			//�P�_�f���O�_�e��
			bool clear = carrier.empty();
			for (int i = 0; i < n && clear; ++i)//�o��k�����
				if (!stations[i].empty())
					clear = 0;
			if (clear)
				break;

			//��s��m
			pos = (pos + 1) % n;
			minute += 2;
		}
		cout << minute << '\n';
	}
	return 0;
}