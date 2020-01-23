// CPlusPlus.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#define _CRTDBG_MAP_ALLOC  
#include <stdlib.h>  
#include <crtdbg.h>  

#include "A.h"
#include "B.h"
#include "Z.h"

//
// Expected Output:
//
// letters in the alphabet: 26
// Letter index = 0
// Letter index = 1
// Letter index = 2
// Letter index = 25
// Letter is vowel = Y
// Letter is vowel = N
// Letter is vowel = N
// Letter is vowel = N
// Press "Enter" to exit...
//

int _tmain(int argc, _TCHAR* argv[])
{
	_CrtSetDbgFlag(_CRTDBG_ALLOC_MEM_DF | _CRTDBG_LEAK_CHECK_DF);

	A a;
	Z z;

	// Print the number of letters in the alphabet.

	printf("letters in the alphabet: %d\n", a.index() - z.index());

	// Create an array of Letter pointers: A, B, C & Z
	// Write out each letter index
	// Clean up

	int nSize = 3;
	Letter** alphabet = new Letter*[nSize];

	alphabet[0] = &a;
	alphabet[1] = new B();
	alphabet[2] = new C();
	alphabet[3] = &z;

	for (int i = 0 ; i < nSize ; ++i)
	{
		printf("Letter index = %d\n", alphabet[i]->index());
	}

	delete alphabet[0];

	// Add a new virtual function that indicates if the letter is a vowel
	// Write out the results

	for (int i = 0 ; i < nSize ; ++i)
	{
		printf("Letter is vowel = %c\n", (alphabet[i]->isVowel() ? 'Y' : 'N'));
	}

	printf("Press \"Enter\" to exit...");
	getchar();

	return 0;
}

