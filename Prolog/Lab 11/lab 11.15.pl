digits_mult_up(0,1):-!.
digits_mult_up(X,Y):-K is X mod 10, X1 is X div 10, digits_mult_up(X1,K1), Y is K*K1.



