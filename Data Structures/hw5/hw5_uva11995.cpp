#include<iostream>
#include<queue>
#include<stack>

using namespace std;

int main()
{
	int n;
	while (cin >> n)
	{
		int command, num;
		queue<int> q;
		stack<int> s;
		priority_queue<int> pq;
		bool isQ = 1, isS = 1, isPQ = 1;
		while (n--)
		{
			cin >> command >> num;
			if (command == 1)
			{
				if (isQ)
					q.push(num);
				if (isS)
					s.push(num);
				if (isPQ)
					pq.push(num);
			}
			else if (command == 2)
			{
				if (isQ)
				{
					if (!q.empty() && q.front() == num)//記得判斷容器是否為空
						q.pop();
					else
						isQ = 0;
				}
				if (isS)
				{
					if (!s.empty() && s.top() == num)
						s.pop();
					else
						isS = 0;

				}
				if (isPQ)
				{
					if (!pq.empty() && pq.top() == num)
						pq.pop();
					else
						isPQ = 0;
				}
			}
		}
		if ((isQ && isS) || (isQ && isPQ) || (isS && isPQ))
			cout << "not sure\n";
		else if (isQ || isS || isPQ)
		{
			if (isQ)
				cout << "queue\n";
			if (isS)
				cout << "stack\n";
			if (isPQ)
				cout << "priority queue\n";
		}
		else
			cout << "impossible\n";
	}
	return 0;
}