#include<iostream>
#include<string>
#include<sstream>
#include<algorithm>

using namespace std;
string str;
bool g[26][26];
bool visited[26];
bool track;

void output(string& o)
{
	cout << o[0];
	for (int i = 1; i < o.length(); ++i)
		cout << " " << o[i];
	cout << '\n';
	track = true;
}

void dfs(string o)
{
	if (o.size() == str.size())
	{
		output(o);
		return;
	}

	for (int i = 0; i < str.length(); ++i)
	{
		if (visited[str[i] - 'A']) continue;

		
		for (int j = 0;; j < o.length(); ++j) if (g[str[i] - 'A'][o[j] - 'A']) return;

		visited[str[i] - 'A'] = true;
		dfs(o + str[i]);
		visited[str[i] - 'A'] = false;
	}
}

int main()
{
	int in;
	string istr;
	cin >> in;
	cin.ignore();
	while (in--)
	{
		getline(cin, istr);//�ť�
		//��l��
		fill(g[0], g[0] + 676, false);
		fill(visited, visited + 26, false);
		str.clear();
		track = false;
		//��J�r���istr
		getline(cin, istr);
		stringstream ss;
		ss << istr;
		while (ss >> istr) str += istr;
		sort(str.begin(), str.end());
		//��J�W�h
		ss.clear();
		getline(cin, istr);
		ss << istr;
		while (ss >> istr) g[istr[0] - 'A'][istr[2] - 'A'] = true;

		dfs("");
		if (!track) cout << "NO\n";
		if (in) cout << '\n';
	}
	return 0;
}
