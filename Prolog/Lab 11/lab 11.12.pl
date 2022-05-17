man(tom).
man(alex).
man(felix).
man(john).
man(andrei).
man(george).
man(jeff).
man(vlad).
man(gregory).

woman(lydia).
woman(alina).
woman(sally).
woman(katya).
woman(alice).
woman(amelia).
woman(julia).
woman(emily).

parent(tom,sally).
parent(tom,john).
parent(tom,andrei).
parent(lydia,sally).
parent(lydia,john).
parent(lydia,andrei).

parent(alex,katya).
parent(alex,george).
parent(alina,katya).
parent(alina,george).

parent(felix,amelia).
parent(felix,jeff).
parent(sally,amelia).
parent(sally,jeff).

parent(andrei,vlad).
parent(andrei,gregory).
parent(andrei,julia).
parent(katya,vlad).
parent(katya,gregory).
parent(katya,julia).

parent(george,emily).
parent(alice,emily).

wife(X) :- parent(X,Y),parent(Z,Y),woman(Z),write(Z).
wife(X,Y) :- parent(Y,Z),parent(X,Z),woman(X).
