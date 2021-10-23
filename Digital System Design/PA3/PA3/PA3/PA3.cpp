#include<iostream>
#include<fstream>
#include<string>
#include<vector>
#include<cmath>

using namespace std;

void merge(vector<vector<string>>& io, vector<vector<string>>& nodes, int node1, int node2)
{
	for (int i = 0; i < io.size(); ++i)
		for (int j = 0; j < io[i].size(); ++j)
			if (io[i][j] == nodes[node2][0])
				io[i][j] = nodes[node1][0];

	for (int i = 1; i < nodes[node2].size(); ++i)
		nodes[node1].emplace_back(nodes[node2][i]);

	auto it = nodes.begin();
	while ((*it).front() != nodes[node2][0])
		++it;
	nodes.erase(it);
}

bool nodeExist(vector<vector<string>>& io,string node)
{
	for (auto& i : io)
	{
		if (i[1] == node)
			return true;
	}
	return false;
}

bool inputEqual(string& a, string& b)
{
	for (int i = 0; i < a.length(); ++i)
	{
		if (a[i] == b[i] || (a[i] == '-' || b[i] == '-'))
			continue;
		return false;
	}
	return true;
}

int main()
{
	string input;
	ifstream inFile("t01.kiss", ios::in);

	while (inFile >> input)
	{
		int ii, o, p, s;
		string r;
		//讀檔
		if (input == ".e")
			break;
		if (input[0] != '.')
			while (inFile >> input)
			{
				if (input[0] != '.')
					continue;
				else
					break;
			}
		inFile >> ii;
		inFile >> input >> o;
		inFile >> input >> p;
		inFile >> input >> s;
		inFile >> input >> r;

		//將states存入vector
		vector<vector<string>> io(p);
		for (int j = 0; j < p; ++j)
			for (int k = 0; k < 4; ++k)
			{
				inFile >> input;
				io[j].emplace_back(input);
			}

		//將各個states與input存入vector
		vector<vector<string>> nodes;
		for (auto& i : io)
		{
			bool add = 0;
			for (auto& j : nodes)
				if (i[1] == j[0])
				{
					j.emplace_back(i[0]);
					add = 1;
				}
			if (!add)
			{
				nodes.emplace_back(vector<string>());
				nodes.back().emplace_back(i[1]);
				nodes.back().emplace_back(i[0]);
			}
		}

		//若兩個state的specified transitions沒有衝突，可以合併
		for (int i = 0; i < nodes.size(); ++i)
		{
			for (int j = i + 1; j < nodes.size(); ++j)
			{
				if (nodes[i].size() + nodes[j].size() < pow(2, ii) + 3)
				{
					bool equal = 0;
					for (int k = 0; k < nodes[i].size() && !equal; ++k)
						for (int l = 0; l < nodes[j].size() && !equal; ++l)
							if (nodes[i][k] == nodes[j][l])
								equal = 1;
					if (!equal)
					{
						if (nodes[j][0] == r)
							r = nodes[i][0];
						merge(io, nodes, i, j);
						--s;
						i = -1;
						break;
					}
				}
			}
		}

		//刪除相同input/output/next state的state
		for (int i = 0; i < io.size(); ++i)
			for (int j = i + 1; j < io.size(); ++j)
				if (inputEqual(io[i][0],io[j][0]) && io[i][2] == io[j][2] && io[i][3] == io[j][3])
				{
					string dNode = io[j][1];
					string eNode = io[i][1];
					auto it = io.begin();
					while ((*it) != io[j])
						++it;
					io.erase(it);
					--p;
					if (!nodeExist(io, dNode))
					{
						for (int k = 0; k < io.size(); ++k)
							for (int l = 0; l < io[k].size(); ++l)
								if (io[k][l] == dNode)
									io[k][l] = eNode;
						--s;
					}
				}

		//輸出簡化結果
		cout << ".i " << ii << "\n.o " << o << "\n.p " << p << "\n.s " << s << "\n.r " << r << '\n';
		for (auto& i : io)
		{
			for (auto& j : i)
				cout << j << " ";
			cout << '\n';
		}
	}
	cout << ".e\n";
	return 0;
}