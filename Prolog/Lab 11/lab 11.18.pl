max_digit_div3_d(0,Max,Max):-!.
max_digit_div3_d(X,Max,Ans):- Dig is X mod 10,X1 is X div 10,Temp is Dig mod 3,Temp \= 0,Dig>Max, max_digit_div3_d(X1,Dig,Ans).
max_digit_div3_d(X,Max,Ans):-X1 is X div 10, max_digit_div3_d(X1,Max,Ans).
max_digit_div3_down(X,Max):-max_digit_div3_d(X,-1,Max),!.
