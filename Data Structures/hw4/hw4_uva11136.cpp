#include<iostream>
#include<set>

using namespace std;

int main()
{
	int n;
	while (cin >> n)
	{
		if (!n)
			break;
		long long total = 0;
		multiset<int> bills;//由小到大
		for (int i = 0; i < n; ++i)
		{
			int dayBill;
			cin >> dayBill;
			int  bill;
			for (int j = 0; j < dayBill; ++j)
				cin >> bill, bills.insert(bill);

			auto billsBegin = bills.begin(), billsEnd = --bills.end();
			total += *billsEnd - *billsBegin;
			bills.erase(billsBegin), bills.erase(billsEnd);
		}
		cout << total << '\n';
	}
}