LDA 08FF
MOV C, A
beg:
LXI H, 08FF
MOV A, L
ADD C
MOV L, A
INR H
MOV A, M
MOV D, A
LXI H, 08F0

MOV E, M
ANA E
JPO bz

LXI H, 08F1
MOV E, M
MOV A, D
ANA E
JPE even
ANA E
JPO odd
moved:
DCR C
JNZ beg

HLT

even:
LXI H, 08FE
MOV A, M
INR M
LXI H, 0980
ADD L
MOV L, A
MOV B, D
MOV A, M
ADD L
MOV L, A
MOV M, B
JMP moved

odd:
LXI H, 08FD
MOV A, M
INR M
LXI H, 0A00
ADD L
MOV L, A
MOV B, D
MOV A, M
ADD L
MOV L, A
MOV M, B
JMP moved

bz:
LXI H, 08FC
MOV A, M
INR M
LXI H, 0A80
ADD L
MOV L, A
MOV B, D
MOV A, M
ADD L
MOV L, A
MOV M, B
JMP moved
