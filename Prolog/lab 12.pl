%Greatest common divisor
gcd(0,X,X):-!.
gcd(X,Y,Z):- X1 is Y mod X, gcd(X1,X,Z).

%Check if number is prime
pr(X,X):-!.
pr(X,I):- X1 is X mod I, X1 \= 0, I1 is I + 1, pr(X,I1).
prost(X):-pr(X,2),!.

%Check if two numbers isn't coprime
not_coprime(X,Y):- gcd(X,Y,Z), Z \= 1.

%Find minimal divisor of number
md(1,_,1):-!.
md(X,I,Ans):-X1 is X mod I, X1 is 0, Ans is I,!.
md(X,I,Ans):-I1 is I + 1, md(X,I1,Ans).
mdiv(X,Ans):- md(X,2,Ans).

%Returns reversed list
r_l([],List,List):-!.
r_l([H|T],Blank,FinalList):- r_l(T,[H|Blank],FinalList).
reversed_list([H|T],FinalList):- r_l([H|T],[],FinalList),!.

%Returns the minimal element of the given list
min_in_l([],CurMin,CurMin):-!.
min_in_l([H|T],CurMin,Min):- H < CurMin, C is H, min_in_l(T,C,Min).
min_in_l([_|T],CurMin,Min):- min_in_l(T,CurMin,Min).
min_in_list([H|T],Min):-CurMin is H, min_in_l([H|T],CurMin,Min),!.


%Exercise 11 (up)
el_up(_,1,0):-!.
el_up(X,I,Ans):-  I1 is I - 1, el_up(X,I1,A),
    (Z is I1 mod 2, Z is 0, not_coprime(X,I1),
     Cur is 1; Cur is 0), Ans is A + Cur.

eleven_up(X,Ans):- el_up(X,X,Ans),!.

%Exercise 11(down)
el_down(_,1,Count,Count):-!.
el_down(X,I,Count,Ans):- I1 is I - 1, Z is I1 mod 2,
    Z is 0, not_coprime(X,I1), C is Count + 1, el_down(X,I1,C,Ans).
el_down(X,I,Count,Ans):- I1 is I - 1, el_down(X,I1,Count,Ans).

eleven_down(X,Ans):- el_down(X,X,0,Ans),!.

%Exercise 12
sum_dig_les_5(0,Sum,Sum):-!.
sum_dig_les_5(X,Sum,Ans):- Cur is X mod 10, Cur < 5, Nsum is Sum + Cur,
    X1 is X div 10, sum_dig_les_5(X1,Nsum,Ans).
sum_dig_les_5(X,Sum,Ans):- X1 is X div 10, sum_dig_les_5(X1,Sum,Ans).
sum_digits_lesser_5(X,Ans):-sum_dig_les_5(X,0,Ans),!.

tw(X,X,Max,Max):-!.
tw(X,I,Max,Ans):- not_coprime(X,I), mdiv(X,Div), I1 is I mod Div, I1 is 0,
    I > Max, Max1 is I, I2 is I + 1, tw(X,I2,Max1,Ans).
tw(X,I,Max,Ans):- I2 is I + 1, tw(X,I2, Max,Ans).
twelve(X,Ans):- tw(X,1,0,A1), sum_digits_lesser_5(X,A2), Ans is A1*A2,!.

%Exercise 13 (greatest n-pandigital number)

pan(X,X,X):-!.
pan(X,I,Ans):- I1 is I + 1, pan(X,I1,A),  Ans is A * 10 + I.
pan_d(X,Ans):- pan(X,1,Ans).


num_class(N,I,I):- X is N div I, X > 0, X < 10, !.
num_class(N,I,Ans):- X is N div I, X > 10, I1 is I * 10, num_class(N,I1,Ans).
num_class(N,I):- num_class(N,1,I).

in_number_exclude(N,X,N1,I):-
    X is N div I, X < 10, X > 0,
    N_cur is X * I, N1 is N - N_cur.
in_number_exclude(N,X,N1,I):- N > 10,
    N_cur is N div I, N_cur > 0, N_cur < 10,
    X1 is I * N_cur, Ncur is N - X1,
    I1 is I div 10,
    in_number_exclude(Ncur,X,N1cur,I1),
    X1div is X1 div 10, N1 is X1div + N1cur.
in_number_exclude(N,X,N1,I):-
    Num is N div I, Num > 10, I1 is I * 10,
    in_number_exclude(N,X,N1,I1).

in_number_exclude(Number,Digit,New_number):- in_number_exclude(Number,Digit,New_number,1).

perm_num(X,X,1):- !.
perm_num(Number,Permutation,I):-
    in_number_exclude(Number,Digit,New_number),I1 is I div 10,
    perm_num(New_number,P1,I1),X is Digit * I,Permutation is X + P1.

perm_num(Number,Permutation):-num_class(Number,I), perm_num(Number,Permutation,I).

p_dig(X,Ans):- perm_num(X,Ans), prost(Ans),!.
pandigit(X,Ans):-pan_d(X,X1), p_dig(X1,Ans).

%Exercise 14
%List length
l_l([],Ans,Ans):-!.
l_l([_|T],Count,Ans):-Cur_count is Count + 1, l_l(T,Cur_count,Ans).
list_lenght(List,Ans):- l_l(List,0,Ans).

%Exercise 15 (1.9)
ft([H|T],H,T):-!.
ft([H|T],Min,Ans):-H \= Min, ft(T,Min,Ans).
fithteen(List,Ans):- reversed_list(List,List1), min_in_list(List1,Min),
    ft(List1,Min,List2),reversed_list(List2,Ans),!.
