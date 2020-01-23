#pragma once
#include "letter.h"
class A :
	public Letter
{
public:
	A(void);
	~A(void);

	int index();

	bool isVowel();
};
