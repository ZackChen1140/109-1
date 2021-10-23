#include<iostream>
#include<string>
#include<stack>

using namespace std;

static auto __ = []
{
	ios_base::sync_with_stdio(0);
	cin.tie(0);
	cout.tie(0);
	return 0;
}();

string sw, tw;
stack<char> s;
//­IÃz
void DFS(int swi, int twi, string output)
{
	if (twi == tw.length())
	{
		cout << output << '\n';
		return;
	}

	if (swi < sw.length())
	{
		s.push(sw[swi]);
		DFS(swi + 1, twi, output + (output.empty() ? "i" : " i"));
		s.pop();
	}

	if (!s.empty() && s.top() == tw[twi])
	{
		char sTop = s.top();
		s.pop();
		DFS(swi, twi + 1, output + (output.empty() ? "o" : " o"));
		s.push(sTop);
	}
}

int main()
{
	while (cin >> sw >> tw)
	{
		while (!s.empty())
			s.pop();
		cout << "[\n";
		if (!sw.empty() && sw.length() == tw.length())
			DFS(0, 0, "");
		cout << "]\n";
	}
	return 0;
}