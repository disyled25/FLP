digits_mult_up(0,N,N):-!.
digits_mult_up(X,N,Ini):-Temp is X mod 10, Ini1 is Ini * Temp, X1 is X div 10, digits_mult_up(X1,N,Ini1).
digits_mult_up(X):-digits_mult_up(X,N,1), write(N).


