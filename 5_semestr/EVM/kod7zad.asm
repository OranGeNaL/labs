LDA 0880
MOV C, A
beg:
LXI H, 0880
MOV A, L
ADD C
MOV L, A
MOV A, M
MOV D, A
ANA E
JPE even
ANA E
JPO odd
moved:
DCR C
JNZ beg

CALL sEven
CALL sOdd

HLT



even:
LXI H, 08DF
INR M
MOV B, D
MOV A, M
ADD L
MOV L, A
MOV M, B
JMP moved

odd:
LXI H, 08EF
INR M
MOV B, D
MOV A, M
ADD L
MOV L, A
MOV M, B
JMP moved
