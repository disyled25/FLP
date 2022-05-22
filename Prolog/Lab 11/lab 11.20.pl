fib_d(1,A,A,_):-!.
fib_d(N,A,F1,F2):- N1 is N - 1, F3 is F1 + F2, fib_d(N1,A,F2,F3).
fib_down(N,Ans):- fib_d(N,Ans,1,1), !.
