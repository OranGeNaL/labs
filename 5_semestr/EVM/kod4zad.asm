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

sEven:
LXI H, 08DF
MOV C, M
nextE:	lxi H,08E0
mov d,c
moveE: mov a,m
inx h
sub m
jnc endifE
add m
mov b,m
mov m,a
dcx h
mov m,b
inx h
endifE: dcr d
jnz moveE
dcr c
jnz nextE
RET


sOdd:
LXI H, 08EF
MOV C, M
next:	lxi H,08F0
mov d,c
move: mov a,m
inx h
CMP M
jc endif
mov b,m
mov m,a
dcx h
mov m,b
inx h
endif: dcr d
jnz move
dcr c
jnz next
RET