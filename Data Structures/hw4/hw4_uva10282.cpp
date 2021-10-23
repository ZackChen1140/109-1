#include<iostream>
#include<string>
#include<unordered_map>
#include<sstream>

using namespace std;

int main()
{
	string input;
	unordered_map<string, string> dictionary;
	while (getline(cin, input) && input != "")
	{
		stringstream ss;
		ss << input;
		string key, str;
		ss >> str >> key;
		dictionary[key] = str;
	}

	while (getline(cin, input) && input != "")
	{
		auto it = dictionary.find(input);
		cout << (it == dictionary.end() ? "eh" : (*it).second) << '\n';
	}
	return 0;
}