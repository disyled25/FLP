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

%Returns the minimal element of the given list and it's index
min_in_l([],CurMin,CurMin,_,I,I):-!.
min_in_l([H|T],CurMin,Min,I1,_,I):- H < CurMin, C is H, I2 is I1 + 1,
    Temp1 is I2, min_in_l(T,C,Min,I2,Temp1,I).
min_in_l([_|T],CurMin,Min,I1,Temp,I):- I2 is I1 + 1, min_in_l(T,CurMin,Min,I2,Temp,I).
min_in_list([H|T],Min,I):-CurMin is H, min_in_l(T,CurMin,Min,1,_,I),!.

%Returns the maximal element of the given list and it's index
max_in_l([],CurMax,CurMax,_,I,I):-!.
max_in_l([H|T],CurMax,Max,I1,_,I):- H > CurMax, C is H, I2 is I1 + 1,
    Temp1 is I2, max_in_l(T,C,Max,I2,Temp1,I).
max_in_l([_|T],CurMax,Max,I1,Temp,I):- I2 is I1 + 1, max_in_l(T,CurMax,Max,I2,Temp,I).
max_in_list([H|T],Max,I):-CurMax is H, max_in_l(T,CurMax,Max,1,_,I),!.

%Returns the interval of the given list
l_in_i([],List,_,_,_,List):-!.
l_in_i([H|T],List1,I1,I2,Icur,Ans):- Icur > I1, Icur < I2, Cur is Icur + 1,
    l_in_i(T,[H|List1],I1,I2,Cur,Ans).
l_in_i([_|T],List1,I1,I2,Icur,Ans):-Cur is Icur + 1, l_in_i(T,List1,I1,I2,Cur,Ans).
list_in_interval(List,I1,I2,Ans):- l_in_i(List,[],I1,I2,1,Ans1), reversed_list(Ans1,Ans),!.

%Counts the number of occurrences of an element in a list
c_e_in_l([],_,Ans,Ans):-!.
c_e_in_l([H|T],Elem,Count,Ans):- H is Elem, Cur is Count + 1, c_e_in_l(T,Elem,Cur,Ans).
c_e_in_l([_|T],Elem,Count,Ans):-c_e_in_l(T,Elem,Count,Ans).
count_elem_in_list(List, Elem, Ans):-c_e_in_l(List,Elem,0,Ans),!.

%Removes an element from the list
in_list_exclude([H|T],H,T).
in_list_exclude([H|T],X,[H|Tail]):- in_list_exclude(T,X,Tail).

%----------------------------------------------------------------------

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

in_number_exclude(Number,Digit,New_number):- num_class(Number,I), in_number_exclude(Number,Digit,New_number,I).

perm_num(X,X,1):- !.
perm_num(Number,Permutation,I):-
    in_number_exclude(Number,Digit,New_number),I1 is I div 10,
    perm_num(New_number,P1,I1),X is Digit * I,Permutation is X + P1.

perm_num(Number,Permutation):-num_class(Number,I), perm_num(Number,Permutation,I).

p_dig(X,Ans):- pan_d(X,X1), perm_num(X1,Ans), prost(Ans),!.
p_dig(X,Ans):- X1 is X - 1, p_dig(X1,Ans).
pandigit(Ans):- p_dig(9,Ans).

%Exercise 14
%List length
l_l([],Ans,Ans):-!.
l_l([_|T],Count,Ans):-Cur_count is Count + 1, l_l(T,Cur_count,Ans).
list_lenght(List,Ans):- l_l(List,0,Ans).

%Exercise 15 (1.9)
ft([H|T],H,T):-!.
ft([H|T],Min,Ans):-H \= Min, ft(T,Min,Ans).
fifteen(List,Ans):- reversed_list(List,List1), min_in_list(List1,Min,_),
    ft(List1,Min,List2),reversed_list(List2,Ans),!.

%Exercise 16 (1.12)
sixteen(List,Ans):- min_in_list(List,_,I), max_in_list(List,_, I1),
    (I<I1,list_in_interval(List,I,I1,Ans);list_in_interval(List,I1,I,Ans)),!.

%Exercise 17 (1.22)
seventeen(List,I1,I2,Ans):- min_in_list(List,Min,_),list_in_interval(List,I1,I2,List1),
    count_elem_in_list(List1,Min,Ans),!.

%Exercise 18 (1.24)
eighteen(List,Ans,Ans1):- max_in_list(List,Ans,_),in_list_exclude(List,Ans,List1),
    max_in_list(List1,Ans1,_),!.

%Exercise 19 (1.31)
c_even_in_l([],Count,Count):-!.
c_even_in_l([H|T],Cur,Count):- Even is H mod 2, Even is 0, C is Cur + 1,
    c_even_in_l(T,C,Count).
c_even_in_l([_|T],Cur,Count):- c_even_in_l(T,Cur,Count).
count_even_in_list(List,Ans):-c_even_in_l(List,0,Ans),!.

%Exercise 20 (1.34)
l_in_s([],List,_,_,_,List):-!.
l_in_s([H|T],List1,I1,I2,Icur,Ans):- Icur >= I1, Icur =< I2, Cur is Icur + 1,
    l_in_s(T,[H|List1],I1,I2,Cur,Ans).
l_in_s([_|T],List1,I1,I2,Icur,Ans):-Cur is Icur + 1, l_in_s(T,List1,I1,I2,Cur,Ans).
list_in_segment(List,I1,I2,Ans):- l_in_s(List,[],I1,I2,1,Ans1), reversed_list(Ans1,Ans),!.
