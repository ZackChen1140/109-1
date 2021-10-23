#include <iostream>
#include <queue>

using namespace std;

struct reg {
	int num;
	int period;
	int time;

	//¥H¤U­n­I
	bool operator<(const reg& r) const
	{
		return (time > r.time) || (time == r.time && num > r.num);
	}
};

int main()
{
	string input;
	int regNum, p;
	priority_queue<reg> regs;
	while (cin >> input && input != "#")
	{
		cin >> regNum >> p;
		regs.push({ regNum,p,p });
	}
	int run;
	cin >> run;
	while (run--)
	{
		cout << regs.top().num << '\n';
		reg newReg = regs.top();
		newReg.time += newReg.period;
		regs.pop();
		regs.push(newReg);
	}
	return 0;
}