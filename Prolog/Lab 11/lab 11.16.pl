digits_mult_down(0,N,N):-!.
digits_mult_down(X,N,Ini):-Temp is X mod 10, Ini1 is Ini * Temp, X1 is X div 10, digits_mult_down(X1,N,Ini1).
digits_mult_down(X,N):-digits_mult_down(X,N,1).
