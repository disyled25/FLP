max_digit_div3_u(0,0):-!.
max_digit_div3_u(X,Max):- Dig is X mod 10,X1 is X div 10, max_digit_div3_u(X1,Max1), Temp is Dig mod 3,((Temp \= 0,Dig>Max1, Max is Dig); Max is Max1).
max_digit_div3_up(X,Max):- max_digit_div3_u(X,Max),!.
