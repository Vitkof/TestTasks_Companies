Your program should get two parameters from command line:
- string of size N^2, that describes square matrix of characters N*N;
- string that describes given word.
The first string is converting to matrix using the following rule. String "QWEASDZXC" forms the matrix:
 ``['Q','W','E',  ``
 
  ``'A','S','D',  ``
 
  ``'Z','X','C']  ``
   
 
Your program should print to the console the sequence of cells those build the given word.
Every next character of word can be placed just in the neighbor cell: on the top, on the bottom, on the left or on the right from the cell with previous character.
E.g. if it is given matrix "QLGNAEKIRLRNGEAE" and word "KING", then sequence of cells will be [1,2]->[1,3]->[0,3]->[0,2].
After solving the task test it carefully with different examples.
Send us in email:
- source code
- spent time

Be sure to optimize the program code, but in such a way that it does not take much time.
