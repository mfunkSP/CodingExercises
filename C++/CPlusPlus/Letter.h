#pragma once

class Letter
{
public:
	Letter(void);
	~Letter(void);
	
	virtual int index() = 0;

	virtual bool isVowel();
};

